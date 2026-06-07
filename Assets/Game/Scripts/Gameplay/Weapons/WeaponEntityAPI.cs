/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using static Atomic.Entities.EntityNames;
using System.Runtime.CompilerServices;
#if UNITY_EDITOR
using UnityEditor;
#endif
using Game;
using Atomic.Elements;
using System.Collections.Generic;
using Game.Gameplay;

namespace Game.Gameplay
{
#if UNITY_EDITOR
	[InitializeOnLoad]
#endif
	public static class WeaponEntityAPI
	{
		///Values
		public static readonly int FireCommand; // ICommand
		public static readonly int FireCooldown; // ICooldown
		public static readonly int Owner; // IVariable<IGameEntity>
		public static readonly int Ammo; // IVariable<int>
		public static readonly int Health; // IReactiveVariable<int>
		public static readonly int Damage; // IValue<int>
		public static readonly int DynamicParameterNames; // IReadOnlyList<string>
		public static readonly int PickUpPrefab; // GameEntity

		static WeaponEntityAPI()
		{
			//Values
			FireCommand = NameToId(nameof(FireCommand));
			FireCooldown = NameToId(nameof(FireCooldown));
			Owner = NameToId(nameof(Owner));
			Ammo = NameToId(nameof(Ammo));
			Health = NameToId(nameof(Health));
			Damage = NameToId(nameof(Damage));
			DynamicParameterNames = NameToId(nameof(DynamicParameterNames));
			PickUpPrefab = NameToId(nameof(PickUpPrefab));
		}


		///Value Extensions

		#region FireCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand GetFireCommand(this IWeaponEntity entity) => entity.GetValueUnsafe<ICommand>(FireCommand);

		public static ref ICommand RefFireCommand(this IWeaponEntity entity) => ref entity.GetValueUnsafe<ICommand>(FireCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireCommand(this IWeaponEntity entity, out ICommand value) => entity.TryGetValueUnsafe(FireCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireCommand(this IWeaponEntity entity, ICommand value) => entity.AddValue(FireCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireCommand(this IWeaponEntity entity) => entity.HasValue(FireCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireCommand(this IWeaponEntity entity) => entity.DelValue(FireCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireCommand(this IWeaponEntity entity, ICommand value) => entity.SetValue(FireCommand, value);

		#endregion

		#region FireCooldown

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICooldown GetFireCooldown(this IWeaponEntity entity) => entity.GetValueUnsafe<ICooldown>(FireCooldown);

		public static ref ICooldown RefFireCooldown(this IWeaponEntity entity) => ref entity.GetValueUnsafe<ICooldown>(FireCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireCooldown(this IWeaponEntity entity, out ICooldown value) => entity.TryGetValueUnsafe(FireCooldown, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireCooldown(this IWeaponEntity entity, ICooldown value) => entity.AddValue(FireCooldown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireCooldown(this IWeaponEntity entity) => entity.HasValue(FireCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireCooldown(this IWeaponEntity entity) => entity.DelValue(FireCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireCooldown(this IWeaponEntity entity, ICooldown value) => entity.SetValue(FireCooldown, value);

		#endregion

		#region Owner

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<IGameEntity> GetOwner(this IWeaponEntity entity) => entity.GetValueUnsafe<IVariable<IGameEntity>>(Owner);

		public static ref IVariable<IGameEntity> RefOwner(this IWeaponEntity entity) => ref entity.GetValueUnsafe<IVariable<IGameEntity>>(Owner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetOwner(this IWeaponEntity entity, out IVariable<IGameEntity> value) => entity.TryGetValueUnsafe(Owner, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddOwner(this IWeaponEntity entity, IVariable<IGameEntity> value) => entity.AddValue(Owner, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasOwner(this IWeaponEntity entity) => entity.HasValue(Owner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelOwner(this IWeaponEntity entity) => entity.DelValue(Owner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetOwner(this IWeaponEntity entity, IVariable<IGameEntity> value) => entity.SetValue(Owner, value);

		#endregion

		#region Ammo

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<int> GetAmmo(this IWeaponEntity entity) => entity.GetValueUnsafe<IVariable<int>>(Ammo);

		public static ref IVariable<int> RefAmmo(this IWeaponEntity entity) => ref entity.GetValueUnsafe<IVariable<int>>(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAmmo(this IWeaponEntity entity, out IVariable<int> value) => entity.TryGetValueUnsafe(Ammo, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAmmo(this IWeaponEntity entity, IVariable<int> value) => entity.AddValue(Ammo, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAmmo(this IWeaponEntity entity) => entity.HasValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAmmo(this IWeaponEntity entity) => entity.DelValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAmmo(this IWeaponEntity entity, IVariable<int> value) => entity.SetValue(Ammo, value);

		#endregion

		#region Health

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetHealth(this IWeaponEntity entity) => entity.GetValueUnsafe<IReactiveVariable<int>>(Health);

		public static ref IReactiveVariable<int> RefHealth(this IWeaponEntity entity) => ref entity.GetValueUnsafe<IReactiveVariable<int>>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IWeaponEntity entity, out IReactiveVariable<int> value) => entity.TryGetValueUnsafe(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddHealth(this IWeaponEntity entity, IReactiveVariable<int> value) => entity.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IWeaponEntity entity) => entity.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IWeaponEntity entity) => entity.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IWeaponEntity entity, IReactiveVariable<int> value) => entity.SetValue(Health, value);

		#endregion

		#region Damage

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetDamage(this IWeaponEntity entity) => entity.GetValueUnsafe<IValue<int>>(Damage);

		public static ref IValue<int> RefDamage(this IWeaponEntity entity) => ref entity.GetValueUnsafe<IValue<int>>(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamage(this IWeaponEntity entity, out IValue<int> value) => entity.TryGetValueUnsafe(Damage, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDamage(this IWeaponEntity entity, IValue<int> value) => entity.AddValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamage(this IWeaponEntity entity) => entity.HasValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamage(this IWeaponEntity entity) => entity.DelValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamage(this IWeaponEntity entity, IValue<int> value) => entity.SetValue(Damage, value);

		#endregion

		#region DynamicParameterNames

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReadOnlyList<string> GetDynamicParameterNames(this IWeaponEntity entity) => entity.GetValueUnsafe<IReadOnlyList<string>>(DynamicParameterNames);

		public static ref IReadOnlyList<string> RefDynamicParameterNames(this IWeaponEntity entity) => ref entity.GetValueUnsafe<IReadOnlyList<string>>(DynamicParameterNames);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDynamicParameterNames(this IWeaponEntity entity, out IReadOnlyList<string> value) => entity.TryGetValueUnsafe(DynamicParameterNames, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDynamicParameterNames(this IWeaponEntity entity, IReadOnlyList<string> value) => entity.AddValue(DynamicParameterNames, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDynamicParameterNames(this IWeaponEntity entity) => entity.HasValue(DynamicParameterNames);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDynamicParameterNames(this IWeaponEntity entity) => entity.DelValue(DynamicParameterNames);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDynamicParameterNames(this IWeaponEntity entity, IReadOnlyList<string> value) => entity.SetValue(DynamicParameterNames, value);

		#endregion

		#region PickUpPrefab

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GameEntity GetPickUpPrefab(this IWeaponEntity entity) => entity.GetValueUnsafe<GameEntity>(PickUpPrefab);

		public static ref GameEntity RefPickUpPrefab(this IWeaponEntity entity) => ref entity.GetValueUnsafe<GameEntity>(PickUpPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPickUpPrefab(this IWeaponEntity entity, out GameEntity value) => entity.TryGetValueUnsafe(PickUpPrefab, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPickUpPrefab(this IWeaponEntity entity, GameEntity value) => entity.AddValue(PickUpPrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPickUpPrefab(this IWeaponEntity entity) => entity.HasValue(PickUpPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPickUpPrefab(this IWeaponEntity entity) => entity.DelValue(PickUpPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPickUpPrefab(this IWeaponEntity entity, GameEntity value) => entity.SetValue(PickUpPrefab, value);

		#endregion
    }
}
