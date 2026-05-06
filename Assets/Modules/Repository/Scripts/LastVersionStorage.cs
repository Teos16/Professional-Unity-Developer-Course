using UnityEngine;

namespace Modules.Repositories
{
    public sealed class LastVersionStorage : IVersionProvider
    {
        private const string VersionKey = "LastVersion";

        public int GetCurrentVersion() =>
            PlayerPrefs.GetInt(VersionKey, 0);

        public int GetNextVersion()
        {
            int next = GetCurrentVersion() + 1;
            PlayerPrefs.SetInt(VersionKey, next);
            PlayerPrefs.Save();
            return next;
        }
    }
}