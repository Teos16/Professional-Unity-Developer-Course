using UnityEngine;

namespace Game.App
{
    public sealed class PrefsLevelRepository : ILevelRepository
    {
        private const string PrefsKey = "CurrentLevel";

        public bool LoadLevel(out int level)
        {
            if (PlayerPrefs.HasKey(PrefsKey))
            {
                level = PlayerPrefs.GetInt(PrefsKey, 0);
                Debug.Log($"Level Loaded: {level}");
                return true;
            }

            level = 0;
            return false;
        }

        public void Save(int level)
        {
            PlayerPrefs.SetInt(PrefsKey, level);
            Debug.Log($"Level Saved: {level}");
        }
    }
}