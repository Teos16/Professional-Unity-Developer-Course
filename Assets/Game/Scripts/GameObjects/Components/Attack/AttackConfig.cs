using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "AttackConfig", menuName = "Game/AttackConfig")]
    public sealed class AttackConfig : ScriptableObject
    {
        [field: SerializeField] public bool CanDamage { get; private set; }
        [field: SerializeField, ShowIf("CanDamage")] public int Damage { get; private set; } = 1;
        [field: SerializeField] public bool CanPush { get; private set; }
        [field: SerializeField, ShowIf("CanPush")] public MoveRigidbodyConfig PushConfig { get; private set; }
        [field: SerializeField, ShowIf("CanPush")] public ForceMode ForceMode { get; private set; } = ForceMode.Push;
        [field: SerializeField, ShowIf("CanPushOrDamage")] public float Cooldown { get; private set; } = 0.1f;
        
        private bool CanPushOrDamage => CanPush || CanDamage;
    }
}