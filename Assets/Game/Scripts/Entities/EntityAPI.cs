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

namespace Game
{
#if UNITY_EDITOR
	[InitializeOnLoad]
#endif
	public static class EntityAPI
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
		public static readonly int FireRequest; // IRequest
		public static readonly int FireCondition; // IExpression<bool>
		public static readonly int FireAction; // ICompositeAction
		public static readonly int FireEvent; // IEvent
		public static readonly int FireCooldown; // Cooldown
		public static readonly int Lifetime; // ICooldown
		public static readonly int DestroyAction; // IAction
		public static readonly int RespawnAction; // IAction
		public static readonly int InteractCondition; // IExpression<IEntity,bool>
		public static readonly int InteractAction; // ICompositeAction<IEntity>
		public static readonly int InteractEvent; // IEvent<IEntity>
		public static readonly int TargetInteractible; // IVariable<IEntity>
		public static readonly int Weapon; // IReactiveVariable<IEntity>
		public static readonly int PickUpPrefab; // SceneEntity
		public static readonly int WeaponPrefab; // SceneEntity
		public static readonly int Ammo; // IVariable<int>
		public static readonly int Damage; // IValue<int>
		public static readonly int Health; // IReactiveVariable<int>
		public static readonly int TakeDamageAction; // IAction<int>
		public static readonly int Target; // IVariable<IEntity>
		public static readonly int Trigger; // TriggerEvents
		public static readonly int Animator; // Animator
		public static readonly int CurrentCar; // IVariable<CarController>

		static EntityAPI()
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
			FireRequest = NameToId(nameof(FireRequest));
			FireCondition = NameToId(nameof(FireCondition));
			FireAction = NameToId(nameof(FireAction));
			FireEvent = NameToId(nameof(FireEvent));
			FireCooldown = NameToId(nameof(FireCooldown));
			Lifetime = NameToId(nameof(Lifetime));
			DestroyAction = NameToId(nameof(DestroyAction));
			RespawnAction = NameToId(nameof(RespawnAction));
			InteractCondition = NameToId(nameof(InteractCondition));
			InteractAction = NameToId(nameof(InteractAction));
			InteractEvent = NameToId(nameof(InteractEvent));
			TargetInteractible = NameToId(nameof(TargetInteractible));
			Weapon = NameToId(nameof(Weapon));
			PickUpPrefab = NameToId(nameof(PickUpPrefab));
			WeaponPrefab = NameToId(nameof(WeaponPrefab));
			Ammo = NameToId(nameof(Ammo));
			Damage = NameToId(nameof(Damage));
			Health = NameToId(nameof(Health));
			TakeDamageAction = NameToId(nameof(TakeDamageAction));
			Target = NameToId(nameof(Target));
			Trigger = NameToId(nameof(Trigger));
			Animator = NameToId(nameof(Animator));
			CurrentCar = NameToId(nameof(CurrentCar));
		}


		///Tag Extensions

		#region Moveable

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveableTag(this IEntity entity) => entity.HasTag(Moveable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveableTag(this IEntity entity) => entity.AddTag(Moveable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveableTag(this IEntity entity) => entity.DelTag(Moveable);

		#endregion

		#region Damageable

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamageableTag(this IEntity entity) => entity.HasTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDamageableTag(this IEntity entity) => entity.AddTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamageableTag(this IEntity entity) => entity.DelTag(Damageable);

		#endregion

		#region Interactible

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractibleTag(this IEntity entity) => entity.HasTag(Interactible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddInteractibleTag(this IEntity entity) => entity.AddTag(Interactible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractibleTag(this IEntity entity) => entity.DelTag(Interactible);

		#endregion

		#region Character

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacterTag(this IEntity entity) => entity.HasTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCharacterTag(this IEntity entity) => entity.AddTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacterTag(this IEntity entity) => entity.DelTag(Character);

		#endregion


		///Value Extensions

		#region Position

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<Vector3> GetPosition(this IEntity entity) => entity.GetValue<IVariable<Vector3>>(Position);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPosition(this IEntity entity, out IVariable<Vector3> value) => entity.TryGetValue(Position, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPosition(this IEntity entity, IVariable<Vector3> value) => entity.AddValue(Position, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPosition(this IEntity entity) => entity.HasValue(Position);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPosition(this IEntity entity) => entity.DelValue(Position);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPosition(this IEntity entity, IVariable<Vector3> value) => entity.SetValue(Position, value);

		#endregion

		#region Rotation

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<Quaternion> GetRotation(this IEntity entity) => entity.GetValue<IVariable<Quaternion>>(Rotation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotation(this IEntity entity, out IVariable<Quaternion> value) => entity.TryGetValue(Rotation, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotation(this IEntity entity, IVariable<Quaternion> value) => entity.AddValue(Rotation, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotation(this IEntity entity) => entity.HasValue(Rotation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotation(this IEntity entity) => entity.DelValue(Rotation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotation(this IEntity entity, IVariable<Quaternion> value) => entity.SetValue(Rotation, value);

		#endregion

		#region Transform

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetTransform(this IEntity entity) => entity.GetValue<Transform>(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTransform(this IEntity entity, out Transform value) => entity.TryGetValue(Transform, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTransform(this IEntity entity, Transform value) => entity.AddValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTransform(this IEntity entity) => entity.HasValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTransform(this IEntity entity) => entity.DelValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTransform(this IEntity entity, Transform value) => entity.SetValue(Transform, value);

		#endregion

		#region MoveRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest<Vector3> GetMoveRequest(this IEntity entity) => entity.GetValue<IRequest<Vector3>>(MoveRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveRequest(this IEntity entity, out IRequest<Vector3> value) => entity.TryGetValue(MoveRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveRequest(this IEntity entity, IRequest<Vector3> value) => entity.AddValue(MoveRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveRequest(this IEntity entity) => entity.HasValue(MoveRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveRequest(this IEntity entity) => entity.DelValue(MoveRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveRequest(this IEntity entity, IRequest<Vector3> value) => entity.SetValue(MoveRequest, value);

		#endregion

		#region MoveCondition

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<Vector3,bool> GetMoveCondition(this IEntity entity) => entity.GetValue<IExpression<Vector3,bool>>(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveCondition(this IEntity entity, out IExpression<Vector3,bool> value) => entity.TryGetValue(MoveCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveCondition(this IEntity entity, IExpression<Vector3,bool> value) => entity.AddValue(MoveCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveCondition(this IEntity entity) => entity.HasValue(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveCondition(this IEntity entity) => entity.DelValue(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveCondition(this IEntity entity, IExpression<Vector3,bool> value) => entity.SetValue(MoveCondition, value);

		#endregion

		#region MoveAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction<Vector3,float> GetMoveAction(this IEntity entity) => entity.GetValue<ICompositeAction<Vector3,float>>(MoveAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveAction(this IEntity entity, out ICompositeAction<Vector3,float> value) => entity.TryGetValue(MoveAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveAction(this IEntity entity, ICompositeAction<Vector3,float> value) => entity.AddValue(MoveAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveAction(this IEntity entity) => entity.HasValue(MoveAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveAction(this IEntity entity) => entity.DelValue(MoveAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveAction(this IEntity entity, ICompositeAction<Vector3,float> value) => entity.SetValue(MoveAction, value);

		#endregion

		#region MoveEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<Vector3> GetMoveEvent(this IEntity entity) => entity.GetValue<IEvent<Vector3>>(MoveEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveEvent(this IEntity entity, out IEvent<Vector3> value) => entity.TryGetValue(MoveEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveEvent(this IEntity entity, IEvent<Vector3> value) => entity.AddValue(MoveEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveEvent(this IEntity entity) => entity.HasValue(MoveEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveEvent(this IEntity entity) => entity.DelValue(MoveEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveEvent(this IEntity entity, IEvent<Vector3> value) => entity.SetValue(MoveEvent, value);

		#endregion

		#region MoveSpeed

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetMoveSpeed(this IEntity entity) => entity.GetValue<IValue<float>>(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveSpeed(this IEntity entity, out IValue<float> value) => entity.TryGetValue(MoveSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveSpeed(this IEntity entity, IValue<float> value) => entity.AddValue(MoveSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveSpeed(this IEntity entity) => entity.HasValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveSpeed(this IEntity entity) => entity.DelValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveSpeed(this IEntity entity, IValue<float> value) => entity.SetValue(MoveSpeed, value);

		#endregion

		#region MoveTime

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<float> GetMoveTime(this IEntity entity) => entity.GetValue<IVariable<float>>(MoveTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveTime(this IEntity entity, out IVariable<float> value) => entity.TryGetValue(MoveTime, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveTime(this IEntity entity, IVariable<float> value) => entity.AddValue(MoveTime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveTime(this IEntity entity) => entity.HasValue(MoveTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveTime(this IEntity entity) => entity.DelValue(MoveTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveTime(this IEntity entity, IVariable<float> value) => entity.SetValue(MoveTime, value);

		#endregion

		#region MoveDuration

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetMoveDuration(this IEntity entity) => entity.GetValue<IValue<float>>(MoveDuration);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveDuration(this IEntity entity, out IValue<float> value) => entity.TryGetValue(MoveDuration, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveDuration(this IEntity entity, IValue<float> value) => entity.AddValue(MoveDuration, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveDuration(this IEntity entity) => entity.HasValue(MoveDuration);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveDuration(this IEntity entity) => entity.DelValue(MoveDuration);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveDuration(this IEntity entity, IValue<float> value) => entity.SetValue(MoveDuration, value);

		#endregion

		#region RotateRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest<Vector3> GetRotateRequest(this IEntity entity) => entity.GetValue<IRequest<Vector3>>(RotateRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateRequest(this IEntity entity, out IRequest<Vector3> value) => entity.TryGetValue(RotateRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateRequest(this IEntity entity, IRequest<Vector3> value) => entity.AddValue(RotateRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateRequest(this IEntity entity) => entity.HasValue(RotateRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateRequest(this IEntity entity) => entity.DelValue(RotateRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateRequest(this IEntity entity, IRequest<Vector3> value) => entity.SetValue(RotateRequest, value);

		#endregion

		#region RotateCondition

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<Vector3,bool> GetRotateCondition(this IEntity entity) => entity.GetValue<IExpression<Vector3,bool>>(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateCondition(this IEntity entity, out IExpression<Vector3,bool> value) => entity.TryGetValue(RotateCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateCondition(this IEntity entity, IExpression<Vector3,bool> value) => entity.AddValue(RotateCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateCondition(this IEntity entity) => entity.HasValue(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateCondition(this IEntity entity) => entity.DelValue(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateCondition(this IEntity entity, IExpression<Vector3,bool> value) => entity.SetValue(RotateCondition, value);

		#endregion

		#region RotateAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction<Vector3,float> GetRotateAction(this IEntity entity) => entity.GetValue<ICompositeAction<Vector3,float>>(RotateAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateAction(this IEntity entity, out ICompositeAction<Vector3,float> value) => entity.TryGetValue(RotateAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateAction(this IEntity entity, ICompositeAction<Vector3,float> value) => entity.AddValue(RotateAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateAction(this IEntity entity) => entity.HasValue(RotateAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateAction(this IEntity entity) => entity.DelValue(RotateAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateAction(this IEntity entity, ICompositeAction<Vector3,float> value) => entity.SetValue(RotateAction, value);

		#endregion

		#region RotateEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<Vector3> GetRotateEvent(this IEntity entity) => entity.GetValue<IEvent<Vector3>>(RotateEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateEvent(this IEntity entity, out IEvent<Vector3> value) => entity.TryGetValue(RotateEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateEvent(this IEntity entity, IEvent<Vector3> value) => entity.AddValue(RotateEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateEvent(this IEntity entity) => entity.HasValue(RotateEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateEvent(this IEntity entity) => entity.DelValue(RotateEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateEvent(this IEntity entity, IEvent<Vector3> value) => entity.SetValue(RotateEvent, value);

		#endregion

		#region RotationSpeed

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetRotationSpeed(this IEntity entity) => entity.GetValue<IValue<float>>(RotationSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotationSpeed(this IEntity entity, out IValue<float> value) => entity.TryGetValue(RotationSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotationSpeed(this IEntity entity, IValue<float> value) => entity.AddValue(RotationSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotationSpeed(this IEntity entity) => entity.HasValue(RotationSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotationSpeed(this IEntity entity) => entity.DelValue(RotationSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotationSpeed(this IEntity entity, IValue<float> value) => entity.SetValue(RotationSpeed, value);

		#endregion

		#region FireRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetFireRequest(this IEntity entity) => entity.GetValue<IRequest>(FireRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireRequest(this IEntity entity, out IRequest value) => entity.TryGetValue(FireRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireRequest(this IEntity entity, IRequest value) => entity.AddValue(FireRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireRequest(this IEntity entity) => entity.HasValue(FireRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireRequest(this IEntity entity) => entity.DelValue(FireRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireRequest(this IEntity entity, IRequest value) => entity.SetValue(FireRequest, value);

		#endregion

		#region FireCondition

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<bool> GetFireCondition(this IEntity entity) => entity.GetValue<IExpression<bool>>(FireCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireCondition(this IEntity entity, out IExpression<bool> value) => entity.TryGetValue(FireCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireCondition(this IEntity entity, IExpression<bool> value) => entity.AddValue(FireCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireCondition(this IEntity entity) => entity.HasValue(FireCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireCondition(this IEntity entity) => entity.DelValue(FireCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireCondition(this IEntity entity, IExpression<bool> value) => entity.SetValue(FireCondition, value);

		#endregion

		#region FireAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction GetFireAction(this IEntity entity) => entity.GetValue<ICompositeAction>(FireAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireAction(this IEntity entity, out ICompositeAction value) => entity.TryGetValue(FireAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireAction(this IEntity entity, ICompositeAction value) => entity.AddValue(FireAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireAction(this IEntity entity) => entity.HasValue(FireAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireAction(this IEntity entity) => entity.DelValue(FireAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireAction(this IEntity entity, ICompositeAction value) => entity.SetValue(FireAction, value);

		#endregion

		#region FireEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetFireEvent(this IEntity entity) => entity.GetValue<IEvent>(FireEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireEvent(this IEntity entity, out IEvent value) => entity.TryGetValue(FireEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireEvent(this IEntity entity, IEvent value) => entity.AddValue(FireEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireEvent(this IEntity entity) => entity.HasValue(FireEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireEvent(this IEntity entity) => entity.DelValue(FireEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireEvent(this IEntity entity, IEvent value) => entity.SetValue(FireEvent, value);

		#endregion

		#region FireCooldown

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Cooldown GetFireCooldown(this IEntity entity) => entity.GetValue<Cooldown>(FireCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireCooldown(this IEntity entity, out Cooldown value) => entity.TryGetValue(FireCooldown, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireCooldown(this IEntity entity, Cooldown value) => entity.AddValue(FireCooldown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireCooldown(this IEntity entity) => entity.HasValue(FireCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireCooldown(this IEntity entity) => entity.DelValue(FireCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireCooldown(this IEntity entity, Cooldown value) => entity.SetValue(FireCooldown, value);

		#endregion

		#region Lifetime

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICooldown GetLifetime(this IEntity entity) => entity.GetValue<ICooldown>(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetLifetime(this IEntity entity, out ICooldown value) => entity.TryGetValue(Lifetime, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddLifetime(this IEntity entity, ICooldown value) => entity.AddValue(Lifetime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasLifetime(this IEntity entity) => entity.HasValue(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelLifetime(this IEntity entity) => entity.DelValue(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetLifetime(this IEntity entity, ICooldown value) => entity.SetValue(Lifetime, value);

		#endregion

		#region DestroyAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetDestroyAction(this IEntity entity) => entity.GetValue<IAction>(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDestroyAction(this IEntity entity, out IAction value) => entity.TryGetValue(DestroyAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDestroyAction(this IEntity entity, IAction value) => entity.AddValue(DestroyAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDestroyAction(this IEntity entity) => entity.HasValue(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDestroyAction(this IEntity entity) => entity.DelValue(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDestroyAction(this IEntity entity, IAction value) => entity.SetValue(DestroyAction, value);

		#endregion

		#region RespawnAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetRespawnAction(this IEntity entity) => entity.GetValue<IAction>(RespawnAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRespawnAction(this IEntity entity, out IAction value) => entity.TryGetValue(RespawnAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRespawnAction(this IEntity entity, IAction value) => entity.AddValue(RespawnAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRespawnAction(this IEntity entity) => entity.HasValue(RespawnAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRespawnAction(this IEntity entity) => entity.DelValue(RespawnAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRespawnAction(this IEntity entity, IAction value) => entity.SetValue(RespawnAction, value);

		#endregion

		#region InteractCondition

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<IEntity,bool> GetInteractCondition(this IEntity entity) => entity.GetValue<IExpression<IEntity,bool>>(InteractCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInteractCondition(this IEntity entity, out IExpression<IEntity,bool> value) => entity.TryGetValue(InteractCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddInteractCondition(this IEntity entity, IExpression<IEntity,bool> value) => entity.AddValue(InteractCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractCondition(this IEntity entity) => entity.HasValue(InteractCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractCondition(this IEntity entity) => entity.DelValue(InteractCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInteractCondition(this IEntity entity, IExpression<IEntity,bool> value) => entity.SetValue(InteractCondition, value);

		#endregion

		#region InteractAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction<IEntity> GetInteractAction(this IEntity entity) => entity.GetValue<ICompositeAction<IEntity>>(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInteractAction(this IEntity entity, out ICompositeAction<IEntity> value) => entity.TryGetValue(InteractAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddInteractAction(this IEntity entity, ICompositeAction<IEntity> value) => entity.AddValue(InteractAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractAction(this IEntity entity) => entity.HasValue(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractAction(this IEntity entity) => entity.DelValue(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInteractAction(this IEntity entity, ICompositeAction<IEntity> value) => entity.SetValue(InteractAction, value);

		#endregion

		#region InteractEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<IEntity> GetInteractEvent(this IEntity entity) => entity.GetValue<IEvent<IEntity>>(InteractEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInteractEvent(this IEntity entity, out IEvent<IEntity> value) => entity.TryGetValue(InteractEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddInteractEvent(this IEntity entity, IEvent<IEntity> value) => entity.AddValue(InteractEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractEvent(this IEntity entity) => entity.HasValue(InteractEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractEvent(this IEntity entity) => entity.DelValue(InteractEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInteractEvent(this IEntity entity, IEvent<IEntity> value) => entity.SetValue(InteractEvent, value);

		#endregion

		#region TargetInteractible

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<IEntity> GetTargetInteractible(this IEntity entity) => entity.GetValue<IVariable<IEntity>>(TargetInteractible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTargetInteractible(this IEntity entity, out IVariable<IEntity> value) => entity.TryGetValue(TargetInteractible, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTargetInteractible(this IEntity entity, IVariable<IEntity> value) => entity.AddValue(TargetInteractible, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTargetInteractible(this IEntity entity) => entity.HasValue(TargetInteractible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTargetInteractible(this IEntity entity) => entity.DelValue(TargetInteractible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTargetInteractible(this IEntity entity, IVariable<IEntity> value) => entity.SetValue(TargetInteractible, value);

		#endregion

		#region Weapon

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<IEntity> GetWeapon(this IEntity entity) => entity.GetValue<IReactiveVariable<IEntity>>(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWeapon(this IEntity entity, out IReactiveVariable<IEntity> value) => entity.TryGetValue(Weapon, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddWeapon(this IEntity entity, IReactiveVariable<IEntity> value) => entity.AddValue(Weapon, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWeapon(this IEntity entity) => entity.HasValue(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWeapon(this IEntity entity) => entity.DelValue(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWeapon(this IEntity entity, IReactiveVariable<IEntity> value) => entity.SetValue(Weapon, value);

		#endregion

		#region PickUpPrefab

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SceneEntity GetPickUpPrefab(this IEntity entity) => entity.GetValue<SceneEntity>(PickUpPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPickUpPrefab(this IEntity entity, out SceneEntity value) => entity.TryGetValue(PickUpPrefab, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPickUpPrefab(this IEntity entity, SceneEntity value) => entity.AddValue(PickUpPrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPickUpPrefab(this IEntity entity) => entity.HasValue(PickUpPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPickUpPrefab(this IEntity entity) => entity.DelValue(PickUpPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPickUpPrefab(this IEntity entity, SceneEntity value) => entity.SetValue(PickUpPrefab, value);

		#endregion

		#region WeaponPrefab

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SceneEntity GetWeaponPrefab(this IEntity entity) => entity.GetValue<SceneEntity>(WeaponPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWeaponPrefab(this IEntity entity, out SceneEntity value) => entity.TryGetValue(WeaponPrefab, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddWeaponPrefab(this IEntity entity, SceneEntity value) => entity.AddValue(WeaponPrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWeaponPrefab(this IEntity entity) => entity.HasValue(WeaponPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWeaponPrefab(this IEntity entity) => entity.DelValue(WeaponPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWeaponPrefab(this IEntity entity, SceneEntity value) => entity.SetValue(WeaponPrefab, value);

		#endregion

		#region Ammo

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<int> GetAmmo(this IEntity entity) => entity.GetValue<IVariable<int>>(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAmmo(this IEntity entity, out IVariable<int> value) => entity.TryGetValue(Ammo, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAmmo(this IEntity entity, IVariable<int> value) => entity.AddValue(Ammo, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAmmo(this IEntity entity) => entity.HasValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAmmo(this IEntity entity) => entity.DelValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAmmo(this IEntity entity, IVariable<int> value) => entity.SetValue(Ammo, value);

		#endregion

		#region Damage

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetDamage(this IEntity entity) => entity.GetValue<IValue<int>>(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamage(this IEntity entity, out IValue<int> value) => entity.TryGetValue(Damage, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDamage(this IEntity entity, IValue<int> value) => entity.AddValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamage(this IEntity entity) => entity.HasValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamage(this IEntity entity) => entity.DelValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamage(this IEntity entity, IValue<int> value) => entity.SetValue(Damage, value);

		#endregion

		#region Health

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetHealth(this IEntity entity) => entity.GetValue<IReactiveVariable<int>>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IEntity entity, out IReactiveVariable<int> value) => entity.TryGetValue(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddHealth(this IEntity entity, IReactiveVariable<int> value) => entity.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IEntity entity) => entity.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IEntity entity) => entity.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IEntity entity, IReactiveVariable<int> value) => entity.SetValue(Health, value);

		#endregion

		#region TakeDamageAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction<int> GetTakeDamageAction(this IEntity entity) => entity.GetValue<IAction<int>>(TakeDamageAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTakeDamageAction(this IEntity entity, out IAction<int> value) => entity.TryGetValue(TakeDamageAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTakeDamageAction(this IEntity entity, IAction<int> value) => entity.AddValue(TakeDamageAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTakeDamageAction(this IEntity entity) => entity.HasValue(TakeDamageAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTakeDamageAction(this IEntity entity) => entity.DelValue(TakeDamageAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTakeDamageAction(this IEntity entity, IAction<int> value) => entity.SetValue(TakeDamageAction, value);

		#endregion

		#region Target

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<IEntity> GetTarget(this IEntity entity) => entity.GetValue<IVariable<IEntity>>(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTarget(this IEntity entity, out IVariable<IEntity> value) => entity.TryGetValue(Target, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTarget(this IEntity entity, IVariable<IEntity> value) => entity.AddValue(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTarget(this IEntity entity) => entity.HasValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTarget(this IEntity entity) => entity.DelValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTarget(this IEntity entity, IVariable<IEntity> value) => entity.SetValue(Target, value);

		#endregion

		#region Trigger

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TriggerEvents GetTrigger(this IEntity entity) => entity.GetValue<TriggerEvents>(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTrigger(this IEntity entity, out TriggerEvents value) => entity.TryGetValue(Trigger, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTrigger(this IEntity entity, TriggerEvents value) => entity.AddValue(Trigger, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTrigger(this IEntity entity) => entity.HasValue(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTrigger(this IEntity entity) => entity.DelValue(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTrigger(this IEntity entity, TriggerEvents value) => entity.SetValue(Trigger, value);

		#endregion

		#region Animator

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Animator GetAnimator(this IEntity entity) => entity.GetValue<Animator>(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimator(this IEntity entity, out Animator value) => entity.TryGetValue(Animator, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAnimator(this IEntity entity, Animator value) => entity.AddValue(Animator, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimator(this IEntity entity) => entity.HasValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimator(this IEntity entity) => entity.DelValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimator(this IEntity entity, Animator value) => entity.SetValue(Animator, value);

		#endregion

		#region CurrentCar

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<CarController> GetCurrentCar(this IEntity entity) => entity.GetValue<IVariable<CarController>>(CurrentCar);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCurrentCar(this IEntity entity, out IVariable<CarController> value) => entity.TryGetValue(CurrentCar, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCurrentCar(this IEntity entity, IVariable<CarController> value) => entity.AddValue(CurrentCar, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCurrentCar(this IEntity entity) => entity.HasValue(CurrentCar);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCurrentCar(this IEntity entity) => entity.DelValue(CurrentCar);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCurrentCar(this IEntity entity, IVariable<CarController> value) => entity.SetValue(CurrentCar, value);

		#endregion
    }
}
