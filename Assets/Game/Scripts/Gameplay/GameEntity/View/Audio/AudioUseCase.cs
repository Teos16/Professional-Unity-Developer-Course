using System.Linq;
using UnityEngine;

namespace Game.Gameplay
{
    public static class AudioUseCase
    {
        public static AudioClip GetRandom(this AudioClip[] clips)
        {
            return clips[Random.Range(0, clips.Length)];
        }

        public static AudioClip GetRandomExcept(this AudioClip[] clips, AudioClip exclude)
        {
            if (clips.Length <= 1)
                return clips[0];

            AudioClip[] available = clips.Where(c => c != exclude).ToArray();
            return available[Random.Range(0, available.Length)];
        }

        public static void SetRandomPitch(this AudioSource source, float min, float max) => 
            source.pitch = Random.Range(min, max);
    }
}