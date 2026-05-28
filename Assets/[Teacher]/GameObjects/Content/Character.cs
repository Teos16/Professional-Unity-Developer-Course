// using UnityEngine;
//
// namespace SampleGame
// {
//     [RequireComponent(typeof(MoveRequestComponent), typeof(HealthComponent))]
//     public sealed class Character : MonoBehaviour, 
//         MoveRequestComponent.IAction, 
//         MoveRequestComponent.ICondition,
//         HealthComponent.IDamageHandler,
//         IDualFireComponent
//     {
//         private HealthComponent _healthComponent;
//         private MoveRequestComponent _moveRequestComponent;
//         private MoveTransformComponent _moveTransformComponent;
//         private RotateComponent _rotateComponent;
//         private ArmorComponent _armorComponent;
//         
//         [SerializeField]
//         private GameObject _leftWeapon;
//         
//         [SerializeField]
//         private GameObject _rightWeapon;
//
//         private void Awake()
//         {
//             _moveRequestComponent = this.GetComponent<MoveRequestComponent>();
//             _healthComponent = this.GetComponent<HealthComponent>();
//             _moveTransformComponent = this.GetComponent<MoveTransformComponent>();
//             _rotateComponent = this.GetComponent<RotateComponent>();
//             _armorComponent = this.GetComponent<ArmorComponent>();
//             
//             _moveRequestComponent.SetAction(this);
//             _moveRequestComponent.SetCondition(this);
//             
//             _healthComponent.SetDamageHandler(this);
//         }
//
//         public void FireLeft()
//         {
//             if (_healthComponent.IsAlive()) 
//                 _leftWeapon.GetComponent<FireRequestComponent>().Fire();
//         }
//
//         public void FireRight()
//         {
//             if (_healthComponent.IsAlive()) 
//                 _rightWeapon.GetComponent<FireRequestComponent>().Fire();
//         }
//         
//         private void OnEnable()
//         {
//             _healthComponent.OnHealthEmpty += this.OnHealthEmpty;
//         }
//
//         private void OnDisable()
//         {
//             _healthComponent.OnHealthEmpty -= this.OnHealthEmpty;
//         }
//
//         private void OnHealthEmpty() => this.gameObject.SetActive(false);
//
//         void MoveRequestComponent.IAction.Invoke(Vector3 direction)
//         {
//             _moveTransformComponent.MoveStep(direction);
//             _rotateComponent.RotateTowards(direction);
//         }
//
//         bool MoveRequestComponent.ICondition.Evaluate() => 
//             _healthComponent.IsAlive();
//
//         int HealthComponent.IDamageHandler.Handle(int damage)
//         {
//             Debug.Log($"Input damage {damage}");
//             int newDamage = _armorComponent.AbsorbDamage(damage);
//             Debug.Log($"New damage {newDamage}");
//             return newDamage;
//         }
//
//
//     
//     }
// }