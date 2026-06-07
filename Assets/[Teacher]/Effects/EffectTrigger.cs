// using UnityEngine;
//
// namespace Game.Gameplay
// {
//     public sealed class EffectTrigger : MonoBehaviour
//     {
//         [SerializeField]
//         private EffectConfig _effect;
//         
//         private void OnTriggerEnter(Collider other)
//         {
//             if (other.TryGetComponent(out IGameEntity entity)) 
//                 entity.ApplyEffect(_effect);
//         }
//     }
// }