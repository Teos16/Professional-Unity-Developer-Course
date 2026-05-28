// using System;
// using UnityEngine;
//
// namespace SampleGame
// {
//     public sealed class HealthComponent : MonoBehaviour
//     {
//         public interface IDamageHandler
//         {
//             int Handle(int damage);
//         }
//         
//         public event Action OnHealthEmpty;
//
//         public bool IsEmpty => _hitPoints <= 0;
//
//         public bool IsAlive() => _hitPoints > 0;
//         
//         [SerializeField]
//         private int _hitPoints;
//
//         private IDamageHandler _damageHandler;
//
//         public void SetDamageHandler(IDamageHandler handler) => _damageHandler = handler;
//
//         public void TakeDamage(int damage)
//         {
//             if (this.IsEmpty)
//                 return;
//
//             if (_damageHandler != null) 
//                 damage = _damageHandler.Handle(damage);
//
//             if (damage <= 0)
//                 return;
//
//             _hitPoints = Mathf.Max(0, _hitPoints - damage);
//             if (_hitPoints <= 0) 
//                 this.OnHealthEmpty?.Invoke();
//         }
//     }
// }