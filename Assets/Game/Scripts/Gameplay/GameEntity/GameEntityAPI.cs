using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Event = Atomic.Elements.Event;

namespace Game.Gameplay
{
    public static class GameEntityAPI
    {
        // TAGS
        public static TagKey<IGameEntity> PlayerTag = new(nameof(PlayerTag));
        public static TagKey<IGameEntity> InteractableTag = new(nameof(InteractableTag));
        
        // TRANSFORM
        public static ValueKey<IGameEntity, IVariable<Vector3>> Position = new(nameof(Position));
        public static ValueKey<IGameEntity, IVariable<Quaternion>> Rotation = new(nameof(Rotation));
        public static ValueKey<IGameEntity, IVariable<Transform>> Transform = new(nameof(Transform));
        
        // MOVEMENT
        public static ValueKey<IGameEntity, IRequest<Vector3>> MoveRequest = new(nameof(MoveRequest));
        public static ValueKey<IGameEntity, ICommand<MoveArgs>> MoveCommand = new(nameof(MoveCommand));
        public static ValueKey<IGameEntity, ICooldown> MoveTime = new(nameof(MoveTime));
        public static ValueKey<IGameEntity, IReactiveVariable<Vector3>> MoveDirection = new(nameof(MoveDirection));
        
        // ROTATION
        public static ValueKey<IGameEntity, IRequest<Vector3>> RotateRequest = new(nameof(RotateRequest));
        public static ValueKey<IGameEntity, ICommand<RotateArgs>> RotateCommand = new(nameof(RotateCommand));
        public static ValueKey<IGameEntity, IValue<float>> RotationSpeed = new(nameof(RotationSpeed));
        
        // HEALTH & LIFETIME & DEATH
        public static ValueKey<IGameEntity, IReactiveVariable<int>> Health = new(nameof(Health));
        public static ValueKey<IGameEntity, IValue<int>> MaxHealth = new(nameof(MaxHealth));
        public static ValueKey<IGameEntity, IEvent> DeathEvent = new(nameof(DeathEvent));
        public static ValueKey<IGameEntity, ICommand> RespawnCommand = new(nameof(RespawnCommand));
        public static ValueKey<IGameEntity, ICooldown> Lifetime = new(nameof(Lifetime));
        public static ValueKey<IGameEntity, IAction> DestroyAction = new(nameof(DestroyAction));
        
        // ATTACK & DAMAGE
        public static ValueKey<IGameEntity, IReactiveVariable<Vector3>> AimDirection = new(nameof(AimDirection));
        public static ValueKey<IGameEntity, IVariable<IWeaponEntity>> Weapon = new(nameof(Weapon));
        public static ValueKey<IGameEntity, IRequest> AttackRequest = new(nameof(AttackRequest));
        public static ValueKey<IGameEntity, ICommand> AttackCommand = new(nameof(AttackCommand));
        public static ValueKey<IGameEntity, ICooldown> InitialAttackLag = new(nameof(InitialAttackLag));
        public static ValueKey<IGameEntity, ICommand<int>> TakeDamageCommand = new(nameof(TakeDamageCommand));
        public static ValueKey<IGameEntity, IValue<int>> Damage = new(nameof(Damage));

        // INTERACTION
        public static ValueKey<IGameEntity, ICommand<IGameEntity>> InteractCommand = new(nameof(InteractCommand));
        public static ValueKey<IGameEntity, CollisionEvents> CollisionEvents = new(nameof(CollisionEvents));
        public static ValueKey<IGameEntity, TriggerEvents> TriggerEvents = new(nameof(TriggerEvents));

        // TARGET
        public static ValueKey<IGameEntity, IVariable<IGameEntity>> Target = new(nameof(Target));
        public static ValueKey<IGameEntity, IPredicate<IGameEntity>> TargetDetectionType = new(nameof(TargetDetectionType));
        public static ValueKey<IGameEntity, IVariable<IGameEntity[]>> Agents = new(nameof(Agents));
        
        // MISC
        public static ValueKey<IGameEntity, IVariable<TeamType>> Team = new(nameof(Team));
        public static ValueKey<IGameEntity, IValue<Animator>> Animator = new(nameof(Animator));
        public static ValueKey<IGameEntity, IValue<AnimatorEventReceiver>> AnimatorEventReceiver = new(nameof(AnimatorEventReceiver));
    }
}