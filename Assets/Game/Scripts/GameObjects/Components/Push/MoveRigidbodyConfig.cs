using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "PushConfig", menuName = "Game/PushConfig")]
    public sealed class MoveRigidbodyConfig : ScriptableObject
    {
        [field : SerializeField] public Vector2 PushForce {get; private set;} = new(10f, 10f);
        [field : SerializeField] public float Cooldown { get; private set; } = 0.35f;
        [field : SerializeField] public float Lag { get; private set; } = 0f;
        [field : SerializeField] public float Duration { get; private set; } = 0.1f;
        [field : SerializeField] public ForceMode ForceMode { get; private set; } = ForceMode.Push;
    }
}