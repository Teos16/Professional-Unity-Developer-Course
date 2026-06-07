/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using static Atomic.Entities.EntityNames;
using System.Runtime.CompilerServices;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using Atomic.Elements;
using Game;
using Game.Gameplay;
using System.Collections.Generic;
using System.IO;

namespace Game.Gameplay
{
#if UNITY_EDITOR
	[InitializeOnLoad]
#endif
	public static class GameEntityAPI
	{

		///Tags
		public static readonly int Moveable;
		public static readonly int Damageable;
		public static readonly int Interactible;
		public static readonly int Character;

		///Values
		public static readonly int Position; // IVariable<Vector3>
		public static readonly int Rotation; // IVariable<Quaternion>
		public static readonly int Transform; // Transform
		public static readonly int FireRequest; // IRequest
		public static readonly int FireCommand; // ICommand
		public static readonly int FireCooldown; // ICooldown
		public static readonly int MoveRequest; // IRequest<Vector3>
		public static readonly int MoveCommand; // ICommand<MoveArgs>
		public static readonly int MoveTime; // ICooldown
		public static readonly int MoveSpeed; // IValue<float>
		public static readonly int MoveSpeedMultiplier; // IExpression<float>
		public static readonly int RotateRequest; // IRequest<Vector3>
		public static readonly int RotateCommand; // ICommand<RotateArgs>
		public static readonly int RotationSpeed; // IValue<float>
		public static readonly int InteractCommand; // ICommand<IGameEntity>
		public static readonly int TargetInteractible; // IVariable<IGameEntity>
		public static readonly int Health; // IReactiveVariable<int>
		public static readonly int MaxHealth; // IValue<int>
		public static readonly int Armor; // IValue<float>
		public static readonly int ArmorMultiplier; // IExpression<float>
		public static readonly int TakeDamageCommand; // ICommand<int>
		public static readonly int DeathEvent; // IEvent
		public static readonly int RespawnCommand; // ICommand
		public static readonly int IsStunned; // IExpression<bool>
		public static readonly int Team; // IReactiveVariable<TeamType>
		public static readonly int ActivateAction; // IAction
		public static readonly int DeactivateAction; // IAction
		public static readonly int Weapon; // IReactiveVariable<IWeaponEntity>
		public static readonly int WeaponPrefab; // WeaponEntity
		public static readonly int CurrentTransport; // IVariable<IGameEntity>
		public static readonly int ExitPoint; // Transform
		public static readonly int Lifetime; // ICooldown
		public static readonly int DestroyAction; // IAction
		public static readonly int Effects; // IReactiveList<Effect>
		public static readonly int Effect; // IVariable<EffectConfig>
		public static readonly int Ammo; // IVariable<int>
		public static readonly int Damage; // IValue<int>
		public static readonly int DamageMultiplier; // IExpression<float>
		public static readonly int Target; // IVariable<IGameEntity>
		public static readonly int Trigger; // TriggerEvents
		public static readonly int VerticalSpeed; // IVariable<float>
		public static readonly int JumpRequest; // IRequest
		public static readonly int JumpCommand; // ICommand
		public static readonly int JumpForce; // IVariable<float>
		public static readonly int JumpCooldown; // ICooldown
		public static readonly int IsSheep; // IReactiveVariable<bool>
		public static readonly int Animator; // Animator

		static GameEntityAPI()
		{
			//Tags
			Moveable = NameToId(nameof(Moveable));
			Damageable = NameToId(nameof(Damageable));
			Interactible = NameToId(nameof(Interactible));
			Character = NameToId(nameof(Character));

			//Values
			Position = NameToId(nameof(Position));
			Rotation = NameToId(nameof(Rotation));
			Transform = NameToId(nameof(Transform));
			FireRequest = NameToId(nameof(FireRequest));
			FireCommand = NameToId(nameof(FireCommand));
			FireCooldown = NameToId(nameof(FireCooldown));
			MoveRequest = NameToId(nameof(MoveRequest));
			MoveCommand = NameToId(nameof(MoveCommand));
			MoveTime = NameToId(nameof(MoveTime));
			MoveSpeed = NameToId(nameof(MoveSpeed));
			MoveSpeedMultiplier = NameToId(nameof(MoveSpeedMultiplier));
			RotateRequest = NameToId(nameof(RotateRequest));
			RotateCommand = NameToId(nameof(RotateCommand));
			RotationSpeed = NameToId(nameof(RotationSpeed));
			InteractCommand = NameToId(nameof(InteractCommand));
			TargetInteractible = NameToId(nameof(TargetInteractible));
			Health = NameToId(nameof(Health));
			MaxHealth = NameToId(nameof(MaxHealth));
			Armor = NameToId(nameof(Armor));
			ArmorMultiplier = NameToId(nameof(ArmorMultiplier));
			TakeDamageCommand = NameToId(nameof(TakeDamageCommand));
			DeathEvent = NameToId(nameof(DeathEvent));
			RespawnCommand = NameToId(nameof(RespawnCommand));
			IsStunned = NameToId(nameof(IsStunned));
			Team = NameToId(nameof(Team));
			ActivateAction = NameToId(nameof(ActivateAction));
			DeactivateAction = NameToId(nameof(DeactivateAction));
			Weapon = NameToId(nameof(Weapon));
			WeaponPrefab = NameToId(nameof(WeaponPrefab));
			CurrentTransport = NameToId(nameof(CurrentTransport));
			ExitPoint = NameToId(nameof(ExitPoint));
			Lifetime = NameToId(nameof(Lifetime));
			DestroyAction = NameToId(nameof(DestroyAction));
			Effects = NameToId(nameof(Effects));
			Effect = NameToId(nameof(Effect));
			Ammo = NameToId(nameof(Ammo));
			Damage = NameToId(nameof(Damage));
			DamageMultiplier = NameToId(nameof(DamageMultiplier));
			Target = NameToId(nameof(Target));
			Trigger = NameToId(nameof(Trigger));
			VerticalSpeed = NameToId(nameof(VerticalSpeed));
			JumpRequest = NameToId(nameof(JumpRequest));
			JumpCommand = NameToId(nameof(JumpCommand));
			JumpForce = NameToId(nameof(JumpForce));
			JumpCooldown = NameToId(nameof(JumpCooldown));
			IsSheep = NameToId(nameof(IsSheep));
			Animator = NameToId(nameof(Animator));
		}


		///Tag Extensions

		#region Moveable

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveableTag(this IGameEntity entity) => entity.HasTag(Moveable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveableTag(this IGameEntity entity) => entity.AddTag(Moveable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveableTag(this IGameEntity entity) => entity.DelTag(Moveable);

		#endregion

		#region Damageable

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamageableTag(this IGameEntity entity) => entity.HasTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDamageableTag(this IGameEntity entity) => entity.AddTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamageableTag(this IGameEntity entity) => entity.DelTag(Damageable);

		#endregion

		#region Interactible

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractibleTag(this IGameEntity entity) => entity.HasTag(Interactible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddInteractibleTag(this IGameEntity entity) => entity.AddTag(Interactible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractibleTag(this IGameEntity entity) => entity.DelTag(Interactible);

		#endregion

		#region Character

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacterTag(this IGameEntity entity) => entity.HasTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCharacterTag(this IGameEntity entity) => entity.AddTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacterTag(this IGameEntity entity) => entity.DelTag(Character);

		#endregion


		///Value Extensions

		#region Position

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<Vector3> GetPosition(this IGameEntity entity) => entity.GetValue<IVariable<Vector3>>(Position);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPosition(this IGameEntity entity, out IVariable<Vector3> value) => entity.TryGetValue(Position, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPosition(this IGameEntity entity, IVariable<Vector3> value) => entity.AddValue(Position, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPosition(this IGameEntity entity) => entity.HasValue(Position);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPosition(this IGameEntity entity) => entity.DelValue(Position);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPosition(this IGameEntity entity, IVariable<Vector3> value) => entity.SetValue(Position, value);

		#endregion

		#region Rotation

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<Quaternion> GetRotation(this IGameEntity entity) => entity.GetValue<IVariable<Quaternion>>(Rotation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotation(this IGameEntity entity, out IVariable<Quaternion> value) => entity.TryGetValue(Rotation, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotation(this IGameEntity entity, IVariable<Quaternion> value) => entity.AddValue(Rotation, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotation(this IGameEntity entity) => entity.HasValue(Rotation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotation(this IGameEntity entity) => entity.DelValue(Rotation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotation(this IGameEntity entity, IVariable<Quaternion> value) => entity.SetValue(Rotation, value);

		#endregion

		#region Transform

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetTransform(this IGameEntity entity) => entity.GetValue<Transform>(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTransform(this IGameEntity entity, out Transform value) => entity.TryGetValue(Transform, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTransform(this IGameEntity entity, Transform value) => entity.AddValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTransform(this IGameEntity entity) => entity.HasValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTransform(this IGameEntity entity) => entity.DelValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTransform(this IGameEntity entity, Transform value) => entity.SetValue(Transform, value);

		#endregion

		#region FireRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetFireRequest(this IGameEntity entity) => entity.GetValue<IRequest>(FireRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireRequest(this IGameEntity entity, out IRequest value) => entity.TryGetValue(FireRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireRequest(this IGameEntity entity, IRequest value) => entity.AddValue(FireRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireRequest(this IGameEntity entity) => entity.HasValue(FireRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireRequest(this IGameEntity entity) => entity.DelValue(FireRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireRequest(this IGameEntity entity, IRequest value) => entity.SetValue(FireRequest, value);

		#endregion

		#region FireCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand GetFireCommand(this IGameEntity entity) => entity.GetValue<ICommand>(FireCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireCommand(this IGameEntity entity, out ICommand value) => entity.TryGetValue(FireCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireCommand(this IGameEntity entity, ICommand value) => entity.AddValue(FireCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireCommand(this IGameEntity entity) => entity.HasValue(FireCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireCommand(this IGameEntity entity) => entity.DelValue(FireCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireCommand(this IGameEntity entity, ICommand value) => entity.SetValue(FireCommand, value);

		#endregion

		#region FireCooldown

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICooldown GetFireCooldown(this IGameEntity entity) => entity.GetValue<ICooldown>(FireCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireCooldown(this IGameEntity entity, out ICooldown value) => entity.TryGetValue(FireCooldown, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireCooldown(this IGameEntity entity, ICooldown value) => entity.AddValue(FireCooldown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireCooldown(this IGameEntity entity) => entity.HasValue(FireCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireCooldown(this IGameEntity entity) => entity.DelValue(FireCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireCooldown(this IGameEntity entity, ICooldown value) => entity.SetValue(FireCooldown, value);

		#endregion

		#region MoveRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest<Vector3> GetMoveRequest(this IGameEntity entity) => entity.GetValue<IRequest<Vector3>>(MoveRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveRequest(this IGameEntity entity, out IRequest<Vector3> value) => entity.TryGetValue(MoveRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveRequest(this IGameEntity entity, IRequest<Vector3> value) => entity.AddValue(MoveRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveRequest(this IGameEntity entity) => entity.HasValue(MoveRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveRequest(this IGameEntity entity) => entity.DelValue(MoveRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveRequest(this IGameEntity entity, IRequest<Vector3> value) => entity.SetValue(MoveRequest, value);

		#endregion

		#region MoveCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand<MoveArgs> GetMoveCommand(this IGameEntity entity) => entity.GetValue<ICommand<MoveArgs>>(MoveCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveCommand(this IGameEntity entity, out ICommand<MoveArgs> value) => entity.TryGetValue(MoveCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveCommand(this IGameEntity entity, ICommand<MoveArgs> value) => entity.AddValue(MoveCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveCommand(this IGameEntity entity) => entity.HasValue(MoveCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveCommand(this IGameEntity entity) => entity.DelValue(MoveCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveCommand(this IGameEntity entity, ICommand<MoveArgs> value) => entity.SetValue(MoveCommand, value);

		#endregion

		#region MoveTime

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICooldown GetMoveTime(this IGameEntity entity) => entity.GetValue<ICooldown>(MoveTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveTime(this IGameEntity entity, out ICooldown value) => entity.TryGetValue(MoveTime, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveTime(this IGameEntity entity, ICooldown value) => entity.AddValue(MoveTime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveTime(this IGameEntity entity) => entity.HasValue(MoveTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveTime(this IGameEntity entity) => entity.DelValue(MoveTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveTime(this IGameEntity entity, ICooldown value) => entity.SetValue(MoveTime, value);

		#endregion

		#region MoveSpeed

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetMoveSpeed(this IGameEntity entity) => entity.GetValue<IValue<float>>(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveSpeed(this IGameEntity entity, out IValue<float> value) => entity.TryGetValue(MoveSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveSpeed(this IGameEntity entity, IValue<float> value) => entity.AddValue(MoveSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveSpeed(this IGameEntity entity) => entity.HasValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveSpeed(this IGameEntity entity) => entity.DelValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveSpeed(this IGameEntity entity, IValue<float> value) => entity.SetValue(MoveSpeed, value);

		#endregion

		#region MoveSpeedMultiplier

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<float> GetMoveSpeedMultiplier(this IGameEntity entity) => entity.GetValue<IExpression<float>>(MoveSpeedMultiplier);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveSpeedMultiplier(this IGameEntity entity, out IExpression<float> value) => entity.TryGetValue(MoveSpeedMultiplier, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveSpeedMultiplier(this IGameEntity entity, IExpression<float> value) => entity.AddValue(MoveSpeedMultiplier, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveSpeedMultiplier(this IGameEntity entity) => entity.HasValue(MoveSpeedMultiplier);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveSpeedMultiplier(this IGameEntity entity) => entity.DelValue(MoveSpeedMultiplier);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveSpeedMultiplier(this IGameEntity entity, IExpression<float> value) => entity.SetValue(MoveSpeedMultiplier, value);

		#endregion

		#region RotateRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest<Vector3> GetRotateRequest(this IGameEntity entity) => entity.GetValue<IRequest<Vector3>>(RotateRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateRequest(this IGameEntity entity, out IRequest<Vector3> value) => entity.TryGetValue(RotateRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateRequest(this IGameEntity entity, IRequest<Vector3> value) => entity.AddValue(RotateRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateRequest(this IGameEntity entity) => entity.HasValue(RotateRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateRequest(this IGameEntity entity) => entity.DelValue(RotateRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateRequest(this IGameEntity entity, IRequest<Vector3> value) => entity.SetValue(RotateRequest, value);

		#endregion

		#region RotateCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand<RotateArgs> GetRotateCommand(this IGameEntity entity) => entity.GetValue<ICommand<RotateArgs>>(RotateCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateCommand(this IGameEntity entity, out ICommand<RotateArgs> value) => entity.TryGetValue(RotateCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateCommand(this IGameEntity entity, ICommand<RotateArgs> value) => entity.AddValue(RotateCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateCommand(this IGameEntity entity) => entity.HasValue(RotateCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateCommand(this IGameEntity entity) => entity.DelValue(RotateCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateCommand(this IGameEntity entity, ICommand<RotateArgs> value) => entity.SetValue(RotateCommand, value);

		#endregion

		#region RotationSpeed

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetRotationSpeed(this IGameEntity entity) => entity.GetValue<IValue<float>>(RotationSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotationSpeed(this IGameEntity entity, out IValue<float> value) => entity.TryGetValue(RotationSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotationSpeed(this IGameEntity entity, IValue<float> value) => entity.AddValue(RotationSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotationSpeed(this IGameEntity entity) => entity.HasValue(RotationSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotationSpeed(this IGameEntity entity) => entity.DelValue(RotationSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotationSpeed(this IGameEntity entity, IValue<float> value) => entity.SetValue(RotationSpeed, value);

		#endregion

		#region InteractCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand<IGameEntity> GetInteractCommand(this IGameEntity entity) => entity.GetValue<ICommand<IGameEntity>>(InteractCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInteractCommand(this IGameEntity entity, out ICommand<IGameEntity> value) => entity.TryGetValue(InteractCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddInteractCommand(this IGameEntity entity, ICommand<IGameEntity> value) => entity.AddValue(InteractCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractCommand(this IGameEntity entity) => entity.HasValue(InteractCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractCommand(this IGameEntity entity) => entity.DelValue(InteractCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInteractCommand(this IGameEntity entity, ICommand<IGameEntity> value) => entity.SetValue(InteractCommand, value);

		#endregion

		#region TargetInteractible

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<IGameEntity> GetTargetInteractible(this IGameEntity entity) => entity.GetValue<IVariable<IGameEntity>>(TargetInteractible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTargetInteractible(this IGameEntity entity, out IVariable<IGameEntity> value) => entity.TryGetValue(TargetInteractible, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTargetInteractible(this IGameEntity entity, IVariable<IGameEntity> value) => entity.AddValue(TargetInteractible, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTargetInteractible(this IGameEntity entity) => entity.HasValue(TargetInteractible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTargetInteractible(this IGameEntity entity) => entity.DelValue(TargetInteractible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTargetInteractible(this IGameEntity entity, IVariable<IGameEntity> value) => entity.SetValue(TargetInteractible, value);

		#endregion

		#region Health

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetHealth(this IGameEntity entity) => entity.GetValue<IReactiveVariable<int>>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IGameEntity entity, out IReactiveVariable<int> value) => entity.TryGetValue(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddHealth(this IGameEntity entity, IReactiveVariable<int> value) => entity.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IGameEntity entity) => entity.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IGameEntity entity) => entity.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IGameEntity entity, IReactiveVariable<int> value) => entity.SetValue(Health, value);

		#endregion

		#region MaxHealth

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetMaxHealth(this IGameEntity entity) => entity.GetValue<IValue<int>>(MaxHealth);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMaxHealth(this IGameEntity entity, out IValue<int> value) => entity.TryGetValue(MaxHealth, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMaxHealth(this IGameEntity entity, IValue<int> value) => entity.AddValue(MaxHealth, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMaxHealth(this IGameEntity entity) => entity.HasValue(MaxHealth);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMaxHealth(this IGameEntity entity) => entity.DelValue(MaxHealth);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMaxHealth(this IGameEntity entity, IValue<int> value) => entity.SetValue(MaxHealth, value);

		#endregion

		#region Armor

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetArmor(this IGameEntity entity) => entity.GetValue<IValue<float>>(Armor);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetArmor(this IGameEntity entity, out IValue<float> value) => entity.TryGetValue(Armor, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddArmor(this IGameEntity entity, IValue<float> value) => entity.AddValue(Armor, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasArmor(this IGameEntity entity) => entity.HasValue(Armor);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelArmor(this IGameEntity entity) => entity.DelValue(Armor);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetArmor(this IGameEntity entity, IValue<float> value) => entity.SetValue(Armor, value);

		#endregion

		#region ArmorMultiplier

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<float> GetArmorMultiplier(this IGameEntity entity) => entity.GetValue<IExpression<float>>(ArmorMultiplier);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetArmorMultiplier(this IGameEntity entity, out IExpression<float> value) => entity.TryGetValue(ArmorMultiplier, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddArmorMultiplier(this IGameEntity entity, IExpression<float> value) => entity.AddValue(ArmorMultiplier, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasArmorMultiplier(this IGameEntity entity) => entity.HasValue(ArmorMultiplier);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelArmorMultiplier(this IGameEntity entity) => entity.DelValue(ArmorMultiplier);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetArmorMultiplier(this IGameEntity entity, IExpression<float> value) => entity.SetValue(ArmorMultiplier, value);

		#endregion

		#region TakeDamageCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand<int> GetTakeDamageCommand(this IGameEntity entity) => entity.GetValue<ICommand<int>>(TakeDamageCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTakeDamageCommand(this IGameEntity entity, out ICommand<int> value) => entity.TryGetValue(TakeDamageCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTakeDamageCommand(this IGameEntity entity, ICommand<int> value) => entity.AddValue(TakeDamageCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTakeDamageCommand(this IGameEntity entity) => entity.HasValue(TakeDamageCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTakeDamageCommand(this IGameEntity entity) => entity.DelValue(TakeDamageCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTakeDamageCommand(this IGameEntity entity, ICommand<int> value) => entity.SetValue(TakeDamageCommand, value);

		#endregion

		#region DeathEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetDeathEvent(this IGameEntity entity) => entity.GetValue<IEvent>(DeathEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDeathEvent(this IGameEntity entity, out IEvent value) => entity.TryGetValue(DeathEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDeathEvent(this IGameEntity entity, IEvent value) => entity.AddValue(DeathEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDeathEvent(this IGameEntity entity) => entity.HasValue(DeathEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDeathEvent(this IGameEntity entity) => entity.DelValue(DeathEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDeathEvent(this IGameEntity entity, IEvent value) => entity.SetValue(DeathEvent, value);

		#endregion

		#region RespawnCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand GetRespawnCommand(this IGameEntity entity) => entity.GetValue<ICommand>(RespawnCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRespawnCommand(this IGameEntity entity, out ICommand value) => entity.TryGetValue(RespawnCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRespawnCommand(this IGameEntity entity, ICommand value) => entity.AddValue(RespawnCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRespawnCommand(this IGameEntity entity) => entity.HasValue(RespawnCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRespawnCommand(this IGameEntity entity) => entity.DelValue(RespawnCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRespawnCommand(this IGameEntity entity, ICommand value) => entity.SetValue(RespawnCommand, value);

		#endregion

		#region IsStunned

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<bool> GetIsStunned(this IGameEntity entity) => entity.GetValue<IExpression<bool>>(IsStunned);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetIsStunned(this IGameEntity entity, out IExpression<bool> value) => entity.TryGetValue(IsStunned, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddIsStunned(this IGameEntity entity, IExpression<bool> value) => entity.AddValue(IsStunned, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasIsStunned(this IGameEntity entity) => entity.HasValue(IsStunned);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelIsStunned(this IGameEntity entity) => entity.DelValue(IsStunned);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetIsStunned(this IGameEntity entity, IExpression<bool> value) => entity.SetValue(IsStunned, value);

		#endregion

		#region Team

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<TeamType> GetTeam(this IGameEntity entity) => entity.GetValue<IReactiveVariable<TeamType>>(Team);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTeam(this IGameEntity entity, out IReactiveVariable<TeamType> value) => entity.TryGetValue(Team, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTeam(this IGameEntity entity, IReactiveVariable<TeamType> value) => entity.AddValue(Team, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTeam(this IGameEntity entity) => entity.HasValue(Team);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTeam(this IGameEntity entity) => entity.DelValue(Team);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTeam(this IGameEntity entity, IReactiveVariable<TeamType> value) => entity.SetValue(Team, value);

		#endregion

		#region ActivateAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetActivateAction(this IGameEntity entity) => entity.GetValue<IAction>(ActivateAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetActivateAction(this IGameEntity entity, out IAction value) => entity.TryGetValue(ActivateAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddActivateAction(this IGameEntity entity, IAction value) => entity.AddValue(ActivateAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasActivateAction(this IGameEntity entity) => entity.HasValue(ActivateAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelActivateAction(this IGameEntity entity) => entity.DelValue(ActivateAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetActivateAction(this IGameEntity entity, IAction value) => entity.SetValue(ActivateAction, value);

		#endregion

		#region DeactivateAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetDeactivateAction(this IGameEntity entity) => entity.GetValue<IAction>(DeactivateAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDeactivateAction(this IGameEntity entity, out IAction value) => entity.TryGetValue(DeactivateAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDeactivateAction(this IGameEntity entity, IAction value) => entity.AddValue(DeactivateAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDeactivateAction(this IGameEntity entity) => entity.HasValue(DeactivateAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDeactivateAction(this IGameEntity entity) => entity.DelValue(DeactivateAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDeactivateAction(this IGameEntity entity, IAction value) => entity.SetValue(DeactivateAction, value);

		#endregion

		#region Weapon

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<IWeaponEntity> GetWeapon(this IGameEntity entity) => entity.GetValue<IReactiveVariable<IWeaponEntity>>(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWeapon(this IGameEntity entity, out IReactiveVariable<IWeaponEntity> value) => entity.TryGetValue(Weapon, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddWeapon(this IGameEntity entity, IReactiveVariable<IWeaponEntity> value) => entity.AddValue(Weapon, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWeapon(this IGameEntity entity) => entity.HasValue(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWeapon(this IGameEntity entity) => entity.DelValue(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWeapon(this IGameEntity entity, IReactiveVariable<IWeaponEntity> value) => entity.SetValue(Weapon, value);

		#endregion

		#region WeaponPrefab

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static WeaponEntity GetWeaponPrefab(this IGameEntity entity) => entity.GetValue<WeaponEntity>(WeaponPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWeaponPrefab(this IGameEntity entity, out WeaponEntity value) => entity.TryGetValue(WeaponPrefab, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddWeaponPrefab(this IGameEntity entity, WeaponEntity value) => entity.AddValue(WeaponPrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWeaponPrefab(this IGameEntity entity) => entity.HasValue(WeaponPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWeaponPrefab(this IGameEntity entity) => entity.DelValue(WeaponPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWeaponPrefab(this IGameEntity entity, WeaponEntity value) => entity.SetValue(WeaponPrefab, value);

		#endregion

		#region CurrentTransport

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<IGameEntity> GetCurrentTransport(this IGameEntity entity) => entity.GetValue<IVariable<IGameEntity>>(CurrentTransport);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCurrentTransport(this IGameEntity entity, out IVariable<IGameEntity> value) => entity.TryGetValue(CurrentTransport, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCurrentTransport(this IGameEntity entity, IVariable<IGameEntity> value) => entity.AddValue(CurrentTransport, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCurrentTransport(this IGameEntity entity) => entity.HasValue(CurrentTransport);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCurrentTransport(this IGameEntity entity) => entity.DelValue(CurrentTransport);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCurrentTransport(this IGameEntity entity, IVariable<IGameEntity> value) => entity.SetValue(CurrentTransport, value);

		#endregion

		#region ExitPoint

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetExitPoint(this IGameEntity entity) => entity.GetValue<Transform>(ExitPoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetExitPoint(this IGameEntity entity, out Transform value) => entity.TryGetValue(ExitPoint, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddExitPoint(this IGameEntity entity, Transform value) => entity.AddValue(ExitPoint, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasExitPoint(this IGameEntity entity) => entity.HasValue(ExitPoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelExitPoint(this IGameEntity entity) => entity.DelValue(ExitPoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetExitPoint(this IGameEntity entity, Transform value) => entity.SetValue(ExitPoint, value);

		#endregion

		#region Lifetime

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICooldown GetLifetime(this IGameEntity entity) => entity.GetValue<ICooldown>(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetLifetime(this IGameEntity entity, out ICooldown value) => entity.TryGetValue(Lifetime, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddLifetime(this IGameEntity entity, ICooldown value) => entity.AddValue(Lifetime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasLifetime(this IGameEntity entity) => entity.HasValue(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelLifetime(this IGameEntity entity) => entity.DelValue(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetLifetime(this IGameEntity entity, ICooldown value) => entity.SetValue(Lifetime, value);

		#endregion

		#region DestroyAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetDestroyAction(this IGameEntity entity) => entity.GetValue<IAction>(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDestroyAction(this IGameEntity entity, out IAction value) => entity.TryGetValue(DestroyAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDestroyAction(this IGameEntity entity, IAction value) => entity.AddValue(DestroyAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDestroyAction(this IGameEntity entity) => entity.HasValue(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDestroyAction(this IGameEntity entity) => entity.DelValue(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDestroyAction(this IGameEntity entity, IAction value) => entity.SetValue(DestroyAction, value);

		#endregion

		#region Effects

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveList<Effect> GetEffects(this IGameEntity entity) => entity.GetValue<IReactiveList<Effect>>(Effects);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetEffects(this IGameEntity entity, out IReactiveList<Effect> value) => entity.TryGetValue(Effects, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddEffects(this IGameEntity entity, IReactiveList<Effect> value) => entity.AddValue(Effects, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasEffects(this IGameEntity entity) => entity.HasValue(Effects);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelEffects(this IGameEntity entity) => entity.DelValue(Effects);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetEffects(this IGameEntity entity, IReactiveList<Effect> value) => entity.SetValue(Effects, value);

		#endregion

		#region Effect

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<EffectConfig> GetEffect(this IGameEntity entity) => entity.GetValue<IVariable<EffectConfig>>(Effect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetEffect(this IGameEntity entity, out IVariable<EffectConfig> value) => entity.TryGetValue(Effect, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddEffect(this IGameEntity entity, IVariable<EffectConfig> value) => entity.AddValue(Effect, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasEffect(this IGameEntity entity) => entity.HasValue(Effect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelEffect(this IGameEntity entity) => entity.DelValue(Effect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetEffect(this IGameEntity entity, IVariable<EffectConfig> value) => entity.SetValue(Effect, value);

		#endregion

		#region Ammo

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<int> GetAmmo(this IGameEntity entity) => entity.GetValue<IVariable<int>>(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAmmo(this IGameEntity entity, out IVariable<int> value) => entity.TryGetValue(Ammo, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAmmo(this IGameEntity entity, IVariable<int> value) => entity.AddValue(Ammo, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAmmo(this IGameEntity entity) => entity.HasValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAmmo(this IGameEntity entity) => entity.DelValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAmmo(this IGameEntity entity, IVariable<int> value) => entity.SetValue(Ammo, value);

		#endregion

		#region Damage

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetDamage(this IGameEntity entity) => entity.GetValue<IValue<int>>(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamage(this IGameEntity entity, out IValue<int> value) => entity.TryGetValue(Damage, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDamage(this IGameEntity entity, IValue<int> value) => entity.AddValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamage(this IGameEntity entity) => entity.HasValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamage(this IGameEntity entity) => entity.DelValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamage(this IGameEntity entity, IValue<int> value) => entity.SetValue(Damage, value);

		#endregion

		#region DamageMultiplier

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<float> GetDamageMultiplier(this IGameEntity entity) => entity.GetValue<IExpression<float>>(DamageMultiplier);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamageMultiplier(this IGameEntity entity, out IExpression<float> value) => entity.TryGetValue(DamageMultiplier, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDamageMultiplier(this IGameEntity entity, IExpression<float> value) => entity.AddValue(DamageMultiplier, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamageMultiplier(this IGameEntity entity) => entity.HasValue(DamageMultiplier);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamageMultiplier(this IGameEntity entity) => entity.DelValue(DamageMultiplier);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamageMultiplier(this IGameEntity entity, IExpression<float> value) => entity.SetValue(DamageMultiplier, value);

		#endregion

		#region Target

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<IGameEntity> GetTarget(this IGameEntity entity) => entity.GetValue<IVariable<IGameEntity>>(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTarget(this IGameEntity entity, out IVariable<IGameEntity> value) => entity.TryGetValue(Target, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTarget(this IGameEntity entity, IVariable<IGameEntity> value) => entity.AddValue(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTarget(this IGameEntity entity) => entity.HasValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTarget(this IGameEntity entity) => entity.DelValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTarget(this IGameEntity entity, IVariable<IGameEntity> value) => entity.SetValue(Target, value);

		#endregion

		#region Trigger

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TriggerEvents GetTrigger(this IGameEntity entity) => entity.GetValue<TriggerEvents>(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTrigger(this IGameEntity entity, out TriggerEvents value) => entity.TryGetValue(Trigger, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTrigger(this IGameEntity entity, TriggerEvents value) => entity.AddValue(Trigger, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTrigger(this IGameEntity entity) => entity.HasValue(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTrigger(this IGameEntity entity) => entity.DelValue(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTrigger(this IGameEntity entity, TriggerEvents value) => entity.SetValue(Trigger, value);

		#endregion

		#region VerticalSpeed

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<float> GetVerticalSpeed(this IGameEntity entity) => entity.GetValue<IVariable<float>>(VerticalSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetVerticalSpeed(this IGameEntity entity, out IVariable<float> value) => entity.TryGetValue(VerticalSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddVerticalSpeed(this IGameEntity entity, IVariable<float> value) => entity.AddValue(VerticalSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasVerticalSpeed(this IGameEntity entity) => entity.HasValue(VerticalSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelVerticalSpeed(this IGameEntity entity) => entity.DelValue(VerticalSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetVerticalSpeed(this IGameEntity entity, IVariable<float> value) => entity.SetValue(VerticalSpeed, value);

		#endregion

		#region JumpRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetJumpRequest(this IGameEntity entity) => entity.GetValue<IRequest>(JumpRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetJumpRequest(this IGameEntity entity, out IRequest value) => entity.TryGetValue(JumpRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddJumpRequest(this IGameEntity entity, IRequest value) => entity.AddValue(JumpRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasJumpRequest(this IGameEntity entity) => entity.HasValue(JumpRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelJumpRequest(this IGameEntity entity) => entity.DelValue(JumpRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetJumpRequest(this IGameEntity entity, IRequest value) => entity.SetValue(JumpRequest, value);

		#endregion

		#region JumpCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand GetJumpCommand(this IGameEntity entity) => entity.GetValue<ICommand>(JumpCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetJumpCommand(this IGameEntity entity, out ICommand value) => entity.TryGetValue(JumpCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddJumpCommand(this IGameEntity entity, ICommand value) => entity.AddValue(JumpCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasJumpCommand(this IGameEntity entity) => entity.HasValue(JumpCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelJumpCommand(this IGameEntity entity) => entity.DelValue(JumpCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetJumpCommand(this IGameEntity entity, ICommand value) => entity.SetValue(JumpCommand, value);

		#endregion

		#region JumpForce

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<float> GetJumpForce(this IGameEntity entity) => entity.GetValue<IVariable<float>>(JumpForce);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetJumpForce(this IGameEntity entity, out IVariable<float> value) => entity.TryGetValue(JumpForce, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddJumpForce(this IGameEntity entity, IVariable<float> value) => entity.AddValue(JumpForce, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasJumpForce(this IGameEntity entity) => entity.HasValue(JumpForce);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelJumpForce(this IGameEntity entity) => entity.DelValue(JumpForce);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetJumpForce(this IGameEntity entity, IVariable<float> value) => entity.SetValue(JumpForce, value);

		#endregion

		#region JumpCooldown

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICooldown GetJumpCooldown(this IGameEntity entity) => entity.GetValue<ICooldown>(JumpCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetJumpCooldown(this IGameEntity entity, out ICooldown value) => entity.TryGetValue(JumpCooldown, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddJumpCooldown(this IGameEntity entity, ICooldown value) => entity.AddValue(JumpCooldown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasJumpCooldown(this IGameEntity entity) => entity.HasValue(JumpCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelJumpCooldown(this IGameEntity entity) => entity.DelValue(JumpCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetJumpCooldown(this IGameEntity entity, ICooldown value) => entity.SetValue(JumpCooldown, value);

		#endregion

		#region IsSheep

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<bool> GetIsSheep(this IGameEntity entity) => entity.GetValue<IReactiveVariable<bool>>(IsSheep);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetIsSheep(this IGameEntity entity, out IReactiveVariable<bool> value) => entity.TryGetValue(IsSheep, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddIsSheep(this IGameEntity entity, IReactiveVariable<bool> value) => entity.AddValue(IsSheep, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasIsSheep(this IGameEntity entity) => entity.HasValue(IsSheep);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelIsSheep(this IGameEntity entity) => entity.DelValue(IsSheep);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetIsSheep(this IGameEntity entity, IReactiveVariable<bool> value) => entity.SetValue(IsSheep, value);

		#endregion

		#region Animator

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Animator GetAnimator(this IGameEntity entity) => entity.GetValue<Animator>(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimator(this IGameEntity entity, out Animator value) => entity.TryGetValue(Animator, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAnimator(this IGameEntity entity, Animator value) => entity.AddValue(Animator, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimator(this IGameEntity entity) => entity.HasValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimator(this IGameEntity entity) => entity.DelValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimator(this IGameEntity entity, Animator value) => entity.SetValue(Animator, value);

		#endregion
    }
}
