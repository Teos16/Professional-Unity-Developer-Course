using System;
using System.Text;
using System.Threading;
using Cysharp.Threading.Tasks;
using Modules.Encryption;
using Modules.Hashing;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace Modules.Repositories
{
    public sealed class RemoteRepository : IRepository
    {
        private readonly string _uri;
        private readonly IEncryptor _encryptor;
        private readonly IHashProvider _hashProvider;

        public RemoteRepository(string uri, IEncryptor encryptor = null, IHashProvider hashProvider = null)
        {
            _uri = uri;
            _encryptor = encryptor;
            _hashProvider = hashProvider;
        }
        
        // Save & Load
        
        public async UniTask<bool> Save(JObject gameData, int version, CancellationToken ct = default)
        {
            byte[] requestBytes = BuildSaveRequestBody(gameData);
            
            using UnityWebRequest request = BuildPutRequest(version, requestBytes);

            bool sent = await SendRequest(request, "Save", ct);

            return sent;
        }

        public async UniTask<(bool, JObject)> Load(int version, CancellationToken ct = default)
        {
            using UnityWebRequest request = BuildGetRequest(version);

            bool sent = await SendRequest(request, "Load", ct);
            if (!sent)
                return (false, null);

            string responseText = request.downloadHandler.text;
            
            try
            {
                return ParseLoadResponse(responseText);
            }
            catch (Exception e)
            {
                Debug.LogError($"Load parse error: {e.Message}");
                return (false, null);
            }
        }

        // Request builders

        private UnityWebRequest BuildPutRequest(int version, byte[] body)
        {
            var request = new UnityWebRequest($"{_uri}/save?version={version}", "PUT")
            {
                uploadHandler = new UploadHandlerRaw(body),
                downloadHandler = new DownloadHandlerBuffer()
            };
            request.SetRequestHeader("Content-Type", "application/json");
            return request;
        }

        private UnityWebRequest BuildGetRequest(int version)
        {
            var request = UnityWebRequest.Get($"{_uri}/load?version={version}");
            request.downloadHandler = new DownloadHandlerBuffer();
            return request;
        }

        // Body serialization

        private byte[] BuildSaveRequestBody(JObject gameData)
        {
            string dataJson = ToJson(gameData);

            var root = new JObject { ["data"] = gameData };

            if (_hashProvider != null)
                root["hash"] = _hashProvider.Compute(dataJson);

            byte[] bytes = Encoding.UTF8.GetBytes(ToJson(root));

            if (_encryptor != null)
                bytes = _encryptor.Encrypt(bytes);

            string encoded = Convert.ToBase64String(bytes);
            var wrapper = new JObject { ["data"] = encoded };

            return Encoding.UTF8.GetBytes(ToJson(wrapper));
        }
        
        // Response parsing
        
        private (bool, JObject) ParseLoadResponse(string responseText)
        {
            var response = JObject.Parse(responseText);
            string rawData = response["data"]?.ToString();

            if (string.IsNullOrEmpty(rawData))
                return (false, null);

            byte[] bytes = Convert.FromBase64String(rawData);

            if (_encryptor != null)
                bytes = _encryptor.Decrypt(bytes);

            JObject root = JObject.Parse(Encoding.UTF8.GetString(bytes));

            if (root["data"] is not JObject gameData)
                return (false, (JObject)null);

            if (_hashProvider != null && !VerifyHash(gameData, root["hash"]?.ToString()))
            {
                Debug.LogError("Hash verification failed");
                return (false, (JObject)null);
            }

            return (true, gameData);
        }

        // HTTP send

        private static async UniTask<bool> SendRequest(UnityWebRequest request, string context, CancellationToken ct)
        {
            try
            {
                await request.SendWebRequest().WithCancellation(ct);
            }
            catch (OperationCanceledException)
            {
                Debug.Log($"{context} cancelled");
                return false;
            }

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"{context} error: {request.error}");
                return false;
            }

            return true;
        }

        // Helpers

        private static string ToJson(JObject obj) =>
            obj.ToString(Newtonsoft.Json.Formatting.None);

        private bool VerifyHash(JObject data, string savedHash) =>
            !string.IsNullOrEmpty(savedHash) && _hashProvider.Verify(ToJson(data), savedHash);
    }
}