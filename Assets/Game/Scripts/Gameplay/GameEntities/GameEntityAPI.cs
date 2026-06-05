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
		public static readonly int FireCondition; // IExpression<bool>
		public static readonly int FireAction; // ICompositeAction
		public static readonly int FireEvent; // IEvent
		public static readonly int FireCooldown; // ICooldown
		public static readonly int MoveRequest; // IRequest<Vector3>
		public static readonly int MoveCondition; // IExpression<Vector3,bool>
		public static readonly int MoveAction; // ICompositeAction<Vector3,float>
		public static readonly int MoveEvent; // IEvent<Vector3>
		public static readonly int MoveSpeed; // IValue<float>
		public static readonly int MoveTime; // IVariable<float>
		public static readonly int MoveDuration; // IValue<float>
		public static readonly int RotateRequest; // IRequest<Vector3>
		public static readonly int RotateCondition; // IExpression<Vector3,bool>
		public static readonly int RotateAction; // ICompositeAction<Vector3,float>
		public static readonly int RotateEvent; // IEvent<Vector3>
		public static readonly int RotationSpeed; // IValue<float>
		public static readonly int InteractCondition; // IExpression<IGameEntity,bool>
		public static readonly int InteractAction; // ICompositeAction<IGameEntity>
		public static readonly int InteractEvent; // IEvent<IGameEntity>
		public static readonly int TargetInteractible; // IVariable<IGameEntity>
		public static readonly int Health; // IReactiveVariable<int>
		public static readonly int MaxHealth; // IValue<int>
		public static readonly int TakeDamageAction; // ICompositeAction<int>
		public static readonly int TakeDamageEvent; // IEvent<int>
		public static readonly int DeathEvent; // IEvent
		public static readonly int Team; // IReactiveVariable<TeamType>
		public static readonly int ActivateAction; // IAction
		public static readonly int DeactivateAction; // IAction
		public static readonly int Weapon; // IReactiveVariable<IWeaponEntity>
		public static readonly int WeaponPrefab; // WeaponEntity
		public static readonly int CurrentTransport; // IVariable<IGameEntity>
		public static readonly int ExitPoint; // Transform
		public static readonly int Lifetime; // ICooldown
		public static readonly int DestroyAction; // IAction
		public static readonly int RespawnAction; // IAction
		public static readonly int Ammo; // IVariable<int>
		public static readonly int Damage; // IValue<int>
		public static readonly int Target; // IVariable<IGameEntity>
		public static readonly int Trigger; // TriggerEvents

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
			FireCondition = NameToId(nameof(FireCondition));
			FireAction = NameToId(nameof(FireAction));
			FireEvent = NameToId(nameof(FireEvent));
			FireCooldown = NameToId(nameof(FireCooldown));
			MoveRequest = NameToId(nameof(MoveRequest));
			MoveCondition = NameToId(nameof(MoveCondition));
			MoveAction = NameToId(nameof(MoveAction));
			MoveEvent = NameToId(nameof(MoveEvent));
			MoveSpeed = NameToId(nameof(MoveSpeed));
			MoveTime = NameToId(nameof(MoveTime));
			MoveDuration = NameToId(nameof(MoveDuration));
			RotateRequest = NameToId(nameof(RotateRequest));
			RotateCondition = NameToId(nameof(RotateCondition));
			RotateAction = NameToId(nameof(RotateAction));
			RotateEvent = NameToId(nameof(RotateEvent));
			RotationSpeed = NameToId(nameof(RotationSpeed));
			InteractCondition = NameToId(nameof(InteractCondition));
			InteractAction = NameToId(nameof(InteractAction));
			InteractEvent = NameToId(nameof(InteractEvent));
			TargetInteractible = NameToId(nameof(TargetInteractible));
			Health = NameToId(nameof(Health));
			MaxHealth = NameToId(nameof(MaxHealth));
			TakeDamageAction = NameToId(nameof(TakeDamageAction));
			TakeDamageEvent = NameToId(nameof(TakeDamageEvent));
			DeathEvent = NameToId(nameof(DeathEvent));
			Team = NameToId(nameof(Team));
			ActivateAction = NameToId(nameof(ActivateAction));
			DeactivateAction = NameToId(nameof(DeactivateAction));
			Weapon = NameToId(nameof(Weapon));
			WeaponPrefab = NameToId(nameof(WeaponPrefab));
			CurrentTransport = NameToId(nameof(CurrentTransport));
			ExitPoint = NameToId(nameof(ExitPoint));
			Lifetime = NameToId(nameof(Lifetime));
			DestroyAction = NameToId(nameof(DestroyAction));
			RespawnAction = NameToId(nameof(RespawnAction));
			Ammo = NameToId(nameof(Ammo));
			Damage = NameToId(nameof(Damage));
			Target = NameToId(nameof(Target));
			Trigger = NameToId(nameof(Trigger));
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

		#region FireCondition

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<bool> GetFireCondition(this IGameEntity entity) => entity.GetValue<IExpression<bool>>(FireCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireCondition(this IGameEntity entity, out IExpression<bool> value) => entity.TryGetValue(FireCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireCondition(this IGameEntity entity, IExpression<bool> value) => entity.AddValue(FireCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireCondition(this IGameEntity entity) => entity.HasValue(FireCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireCondition(this IGameEntity entity) => entity.DelValue(FireCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireCondition(this IGameEntity entity, IExpression<bool> value) => entity.SetValue(FireCondition, value);

		#endregion

		#region FireAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction GetFireAction(this IGameEntity entity) => entity.GetValue<ICompositeAction>(FireAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireAction(this IGameEntity entity, out ICompositeAction value) => entity.TryGetValue(FireAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireAction(this IGameEntity entity, ICompositeAction value) => entity.AddValue(FireAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireAction(this IGameEntity entity) => entity.HasValue(FireAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireAction(this IGameEntity entity) => entity.DelValue(FireAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireAction(this IGameEntity entity, ICompositeAction value) => entity.SetValue(FireAction, value);

		#endregion

		#region FireEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetFireEvent(this IGameEntity entity) => entity.GetValue<IEvent>(FireEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireEvent(this IGameEntity entity, out IEvent value) => entity.TryGetValue(FireEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireEvent(this IGameEntity entity, IEvent value) => entity.AddValue(FireEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireEvent(this IGameEntity entity) => entity.HasValue(FireEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireEvent(this IGameEntity entity) => entity.DelValue(FireEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireEvent(this IGameEntity entity, IEvent value) => entity.SetValue(FireEvent, value);

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

		#region MoveCondition

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<Vector3,bool> GetMoveCondition(this IGameEntity entity) => entity.GetValue<IExpression<Vector3,bool>>(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveCondition(this IGameEntity entity, out IExpression<Vector3,bool> value) => entity.TryGetValue(MoveCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveCondition(this IGameEntity entity, IExpression<Vector3,bool> value) => entity.AddValue(MoveCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveCondition(this IGameEntity entity) => entity.HasValue(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveCondition(this IGameEntity entity) => entity.DelValue(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveCondition(this IGameEntity entity, IExpression<Vector3,bool> value) => entity.SetValue(MoveCondition, value);

		#endregion

		#region MoveAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction<Vector3,float> GetMoveAction(this IGameEntity entity) => entity.GetValue<ICompositeAction<Vector3,float>>(MoveAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveAction(this IGameEntity entity, out ICompositeAction<Vector3,float> value) => entity.TryGetValue(MoveAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveAction(this IGameEntity entity, ICompositeAction<Vector3,float> value) => entity.AddValue(MoveAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveAction(this IGameEntity entity) => entity.HasValue(MoveAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveAction(this IGameEntity entity) => entity.DelValue(MoveAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveAction(this IGameEntity entity, ICompositeAction<Vector3,float> value) => entity.SetValue(MoveAction, value);

		#endregion

		#region MoveEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<Vector3> GetMoveEvent(this IGameEntity entity) => entity.GetValue<IEvent<Vector3>>(MoveEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveEvent(this IGameEntity entity, out IEvent<Vector3> value) => entity.TryGetValue(MoveEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveEvent(this IGameEntity entity, IEvent<Vector3> value) => entity.AddValue(MoveEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveEvent(this IGameEntity entity) => entity.HasValue(MoveEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveEvent(this IGameEntity entity) => entity.DelValue(MoveEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveEvent(this IGameEntity entity, IEvent<Vector3> value) => entity.SetValue(MoveEvent, value);

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

		#region MoveTime

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<float> GetMoveTime(this IGameEntity entity) => entity.GetValue<IVariable<float>>(MoveTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveTime(this IGameEntity entity, out IVariable<float> value) => entity.TryGetValue(MoveTime, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveTime(this IGameEntity entity, IVariable<float> value) => entity.AddValue(MoveTime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveTime(this IGameEntity entity) => entity.HasValue(MoveTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveTime(this IGameEntity entity) => entity.DelValue(MoveTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveTime(this IGameEntity entity, IVariable<float> value) => entity.SetValue(MoveTime, value);

		#endregion

		#region MoveDuration

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetMoveDuration(this IGameEntity entity) => entity.GetValue<IValue<float>>(MoveDuration);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveDuration(this IGameEntity entity, out IValue<float> value) => entity.TryGetValue(MoveDuration, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveDuration(this IGameEntity entity, IValue<float> value) => entity.AddValue(MoveDuration, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveDuration(this IGameEntity entity) => entity.HasValue(MoveDuration);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveDuration(this IGameEntity entity) => entity.DelValue(MoveDuration);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveDuration(this IGameEntity entity, IValue<float> value) => entity.SetValue(MoveDuration, value);

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

		#region RotateCondition

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<Vector3,bool> GetRotateCondition(this IGameEntity entity) => entity.GetValue<IExpression<Vector3,bool>>(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateCondition(this IGameEntity entity, out IExpression<Vector3,bool> value) => entity.TryGetValue(RotateCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateCondition(this IGameEntity entity, IExpression<Vector3,bool> value) => entity.AddValue(RotateCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateCondition(this IGameEntity entity) => entity.HasValue(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateCondition(this IGameEntity entity) => entity.DelValue(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateCondition(this IGameEntity entity, IExpression<Vector3,bool> value) => entity.SetValue(RotateCondition, value);

		#endregion

		#region RotateAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction<Vector3,float> GetRotateAction(this IGameEntity entity) => entity.GetValue<ICompositeAction<Vector3,float>>(RotateAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateAction(this IGameEntity entity, out ICompositeAction<Vector3,float> value) => entity.TryGetValue(RotateAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateAction(this IGameEntity entity, ICompositeAction<Vector3,float> value) => entity.AddValue(RotateAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateAction(this IGameEntity entity) => entity.HasValue(RotateAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateAction(this IGameEntity entity) => entity.DelValue(RotateAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateAction(this IGameEntity entity, ICompositeAction<Vector3,float> value) => entity.SetValue(RotateAction, value);

		#endregion

		#region RotateEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<Vector3> GetRotateEvent(this IGameEntity entity) => entity.GetValue<IEvent<Vector3>>(RotateEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateEvent(this IGameEntity entity, out IEvent<Vector3> value) => entity.TryGetValue(RotateEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateEvent(this IGameEntity entity, IEvent<Vector3> value) => entity.AddValue(RotateEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateEvent(this IGameEntity entity) => entity.HasValue(RotateEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateEvent(this IGameEntity entity) => entity.DelValue(RotateEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateEvent(this IGameEntity entity, IEvent<Vector3> value) => entity.SetValue(RotateEvent, value);

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

		#region InteractCondition

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<IGameEntity,bool> GetInteractCondition(this IGameEntity entity) => entity.GetValue<IExpression<IGameEntity,bool>>(InteractCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInteractCondition(this IGameEntity entity, out IExpression<IGameEntity,bool> value) => entity.TryGetValue(InteractCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddInteractCondition(this IGameEntity entity, IExpression<IGameEntity,bool> value) => entity.AddValue(InteractCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractCondition(this IGameEntity entity) => entity.HasValue(InteractCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractCondition(this IGameEntity entity) => entity.DelValue(InteractCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInteractCondition(this IGameEntity entity, IExpression<IGameEntity,bool> value) => entity.SetValue(InteractCondition, value);

		#endregion

		#region InteractAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction<IGameEntity> GetInteractAction(this IGameEntity entity) => entity.GetValue<ICompositeAction<IGameEntity>>(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInteractAction(this IGameEntity entity, out ICompositeAction<IGameEntity> value) => entity.TryGetValue(InteractAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddInteractAction(this IGameEntity entity, ICompositeAction<IGameEntity> value) => entity.AddValue(InteractAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractAction(this IGameEntity entity) => entity.HasValue(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractAction(this IGameEntity entity) => entity.DelValue(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInteractAction(this IGameEntity entity, ICompositeAction<IGameEntity> value) => entity.SetValue(InteractAction, value);

		#endregion

		#region InteractEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<IGameEntity> GetInteractEvent(this IGameEntity entity) => entity.GetValue<IEvent<IGameEntity>>(InteractEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInteractEvent(this IGameEntity entity, out IEvent<IGameEntity> value) => entity.TryGetValue(InteractEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddInteractEvent(this IGameEntity entity, IEvent<IGameEntity> value) => entity.AddValue(InteractEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractEvent(this IGameEntity entity) => entity.HasValue(InteractEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractEvent(this IGameEntity entity) => entity.DelValue(InteractEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInteractEvent(this IGameEntity entity, IEvent<IGameEntity> value) => entity.SetValue(InteractEvent, value);

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

		#region TakeDamageAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction<int> GetTakeDamageAction(this IGameEntity entity) => entity.GetValue<ICompositeAction<int>>(TakeDamageAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTakeDamageAction(this IGameEntity entity, out ICompositeAction<int> value) => entity.TryGetValue(TakeDamageAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTakeDamageAction(this IGameEntity entity, ICompositeAction<int> value) => entity.AddValue(TakeDamageAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTakeDamageAction(this IGameEntity entity) => entity.HasValue(TakeDamageAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTakeDamageAction(this IGameEntity entity) => entity.DelValue(TakeDamageAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTakeDamageAction(this IGameEntity entity, ICompositeAction<int> value) => entity.SetValue(TakeDamageAction, value);

		#endregion

		#region TakeDamageEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<int> GetTakeDamageEvent(this IGameEntity entity) => entity.GetValue<IEvent<int>>(TakeDamageEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTakeDamageEvent(this IGameEntity entity, out IEvent<int> value) => entity.TryGetValue(TakeDamageEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTakeDamageEvent(this IGameEntity entity, IEvent<int> value) => entity.AddValue(TakeDamageEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTakeDamageEvent(this IGameEntity entity) => entity.HasValue(TakeDamageEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTakeDamageEvent(this IGameEntity entity) => entity.DelValue(TakeDamageEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTakeDamageEvent(this IGameEntity entity, IEvent<int> value) => entity.SetValue(TakeDamageEvent, value);

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

		#region RespawnAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetRespawnAction(this IGameEntity entity) => entity.GetValue<IAction>(RespawnAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRespawnAction(this IGameEntity entity, out IAction value) => entity.TryGetValue(RespawnAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRespawnAction(this IGameEntity entity, IAction value) => entity.AddValue(RespawnAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRespawnAction(this IGameEntity entity) => entity.HasValue(RespawnAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRespawnAction(this IGameEntity entity) => entity.DelValue(RespawnAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRespawnAction(this IGameEntity entity, IAction value) => entity.SetValue(RespawnAction, value);

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
    }
}
