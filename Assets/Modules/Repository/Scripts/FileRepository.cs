using System;
using System.IO;
using System.Text;
using System.Threading;
using Cysharp.Threading.Tasks;
using Modules.Encryption;
using Modules.Hashing;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Modules.Repositories
{
    public sealed class FileRepository : IRepository
    {
        private readonly string _baseFilePath;
        private readonly IEncryptor _encryptor;
        private readonly IHashProvider _hashProvider;

        public FileRepository(string baseFilePath, IEncryptor encryptor = null, IHashProvider hashProvider = null)
        {
            _baseFilePath = baseFilePath;
            _encryptor = encryptor;
            _hashProvider = hashProvider;
        }

        // Save & Load

        public async UniTask<bool> Save(JObject data, int version, CancellationToken ct = default)
        {
            try
            {
                string filePath = BuildFilePath(version);

                byte[] bytes = await UniTask.RunOnThreadPool(
                    () => BuildSaveBody(data),
                    cancellationToken: ct);

                await File.WriteAllBytesAsync(filePath, bytes, ct);
                return true;
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Save cancelled");
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async UniTask<(bool, JObject)> Load(int version, CancellationToken ct = default)
        {
            string filePath = BuildFilePath(version);

            if (!File.Exists(filePath))
                return (false, null);

            try
            {
                byte[] bytes = await File.ReadAllBytesAsync(filePath, ct);

                return await UniTask.RunOnThreadPool(
                    () => ParseLoadBody(bytes),
                    cancellationToken: ct);
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Load cancelled");
                return (false, null);
            }
            catch
            {
                return (false, null);
            }
        }

        // File path builder

        private string BuildFilePath(int version)
        {
            string dir  = Path.GetDirectoryName(_baseFilePath);
            string name = Path.GetFileNameWithoutExtension(_baseFilePath);
            string ext  = Path.GetExtension(_baseFilePath);
            string path = Path.Combine(dir ?? string.Empty, $"{name}_v{version}{ext}");
            return path;
        }

        // Body serialization

        private byte[] BuildSaveBody(JObject data)
        {
            string dataJson = ToJson(data);
            var root = new JObject { ["data"] = data };

            if (_hashProvider != null)
                root["hash"] = _hashProvider.Compute(dataJson);

            byte[] bytes = Encoding.UTF8.GetBytes(ToJson(root));

            if (_encryptor != null)
                bytes = _encryptor.Encrypt(bytes);

            return bytes;
        }

        // Response parsing

        private (bool, JObject) ParseLoadBody(byte[] bytes)
        {
            if (_encryptor != null)
                bytes = _encryptor.Decrypt(bytes);

            JObject root = JObject.Parse(Encoding.UTF8.GetString(bytes));

            if (root["data"] is not JObject data)
                return (false, null);

            if (_hashProvider != null && !VerifyHash(data, root["hash"]?.ToString()))
            {
                Debug.LogError("Hash verification failed");
                return (false, null);
            }

            return (true, data);
        }

        // Helpers

        private static string ToJson(JObject obj) =>
            obj.ToString(Newtonsoft.Json.Formatting.None);

        private bool VerifyHash(JObject data, string savedHash) =>
            !string.IsNullOrEmpty(savedHash) && _hashProvider.Verify(ToJson(data), savedHash);
    }
}