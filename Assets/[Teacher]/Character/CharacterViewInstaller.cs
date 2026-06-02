// using Atomic.Elements;
// using Atomic.Entities;
// using SampleGame;
// using UnityEngine;
//
// namespace Game
// {
//     public sealed class CharacterViewInstaller : SceneEntityInstaller
//     {
//         private static readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));
//         private static readonly int Death = Animator.StringToHash(nameof(Death));
//         private static readonly int Fire = Animator.StringToHash(nameof(Fire));
//
//         private readonly DisposableComposite _disposables = new();
//
//         [SerializeField]
//         private Animator _animator;
//
//         [SerializeField]
//         private GameObject _weaponView;
//
//         public override void Install(IEntity entity)
//         {
//             entity.WhenTick(_ => _animator.SetBool(IsMoving, entity.IsMoving()));
//             entity.GetWeapon().Observe(weapon =>
//             {
//                 Debug.Log($"HAS WEAPON {weapon != null}");
//                 _weaponView.SetActive(weapon != null);
//             }).AddTo(_disposables);
//             
//             entity.GetHealth().Subscribe(health =>
//             {
//                 if (health <= 0) _animator.SetTrigger(Death);
//             }).AddTo(_disposables);
//
//             entity.GetFireEvent().Subscribe(() => _animator.SetTrigger(Fire)).AddTo(_disposables);
//         }
//
//         public override void Uninstall(IEntity entity)
//         {
//             _disposables.Dispose();
//         }
//     }
// }