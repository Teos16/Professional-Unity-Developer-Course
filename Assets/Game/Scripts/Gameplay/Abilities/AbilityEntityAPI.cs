/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using static Atomic.Entities.EntityNames;
using System.Runtime.CompilerServices;
#if UNITY_EDITOR
using UnityEditor;
#endif
using Game.Gameplay;
using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
#if UNITY_EDITOR
	[InitializeOnLoad]
#endif
	public static class AbilityEntityAPI
	{
		///Values
		public static readonly int ClickRequest; // IRequest
		public static readonly int ClickCommand; // ICommand
		public static readonly int PointRequest; // IRequest<Vector3>
		public static readonly int PointCommand; // ICommand<Vector3>
		public static readonly int TargetRequest; // IRequest<IGameEntity>
		public static readonly int TargetCommand; // ICommand<IGameEntity>
		public static readonly int Charges; // IVariable<int>
		public static readonly int Cooldown; // ICooldown

		static AbilityEntityAPI()
		{
			//Values
			ClickRequest = NameToId(nameof(ClickRequest));
			ClickCommand = NameToId(nameof(ClickCommand));
			PointRequest = NameToId(nameof(PointRequest));
			PointCommand = NameToId(nameof(PointCommand));
			TargetRequest = NameToId(nameof(TargetRequest));
			TargetCommand = NameToId(nameof(TargetCommand));
			Charges = NameToId(nameof(Charges));
			Cooldown = NameToId(nameof(Cooldown));
		}


		///Value Extensions

		#region ClickRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetClickRequest(this IAbilityEntity entity) => entity.GetValue<IRequest>(ClickRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetClickRequest(this IAbilityEntity entity, out IRequest value) => entity.TryGetValue(ClickRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddClickRequest(this IAbilityEntity entity, IRequest value) => entity.AddValue(ClickRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasClickRequest(this IAbilityEntity entity) => entity.HasValue(ClickRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelClickRequest(this IAbilityEntity entity) => entity.DelValue(ClickRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetClickRequest(this IAbilityEntity entity, IRequest value) => entity.SetValue(ClickRequest, value);

		#endregion

		#region ClickCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand GetClickCommand(this IAbilityEntity entity) => entity.GetValue<ICommand>(ClickCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetClickCommand(this IAbilityEntity entity, out ICommand value) => entity.TryGetValue(ClickCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddClickCommand(this IAbilityEntity entity, ICommand value) => entity.AddValue(ClickCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasClickCommand(this IAbilityEntity entity) => entity.HasValue(ClickCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelClickCommand(this IAbilityEntity entity) => entity.DelValue(ClickCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetClickCommand(this IAbilityEntity entity, ICommand value) => entity.SetValue(ClickCommand, value);

		#endregion

		#region PointRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest<Vector3> GetPointRequest(this IAbilityEntity entity) => entity.GetValue<IRequest<Vector3>>(PointRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPointRequest(this IAbilityEntity entity, out IRequest<Vector3> value) => entity.TryGetValue(PointRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPointRequest(this IAbilityEntity entity, IRequest<Vector3> value) => entity.AddValue(PointRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPointRequest(this IAbilityEntity entity) => entity.HasValue(PointRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPointRequest(this IAbilityEntity entity) => entity.DelValue(PointRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPointRequest(this IAbilityEntity entity, IRequest<Vector3> value) => entity.SetValue(PointRequest, value);

		#endregion

		#region PointCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand<Vector3> GetPointCommand(this IAbilityEntity entity) => entity.GetValue<ICommand<Vector3>>(PointCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPointCommand(this IAbilityEntity entity, out ICommand<Vector3> value) => entity.TryGetValue(PointCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPointCommand(this IAbilityEntity entity, ICommand<Vector3> value) => entity.AddValue(PointCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPointCommand(this IAbilityEntity entity) => entity.HasValue(PointCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPointCommand(this IAbilityEntity entity) => entity.DelValue(PointCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPointCommand(this IAbilityEntity entity, ICommand<Vector3> value) => entity.SetValue(PointCommand, value);

		#endregion

		#region TargetRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest<IGameEntity> GetTargetRequest(this IAbilityEntity entity) => entity.GetValue<IRequest<IGameEntity>>(TargetRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTargetRequest(this IAbilityEntity entity, out IRequest<IGameEntity> value) => entity.TryGetValue(TargetRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTargetRequest(this IAbilityEntity entity, IRequest<IGameEntity> value) => entity.AddValue(TargetRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTargetRequest(this IAbilityEntity entity) => entity.HasValue(TargetRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTargetRequest(this IAbilityEntity entity) => entity.DelValue(TargetRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTargetRequest(this IAbilityEntity entity, IRequest<IGameEntity> value) => entity.SetValue(TargetRequest, value);

		#endregion

		#region TargetCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand<IGameEntity> GetTargetCommand(this IAbilityEntity entity) => entity.GetValue<ICommand<IGameEntity>>(TargetCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTargetCommand(this IAbilityEntity entity, out ICommand<IGameEntity> value) => entity.TryGetValue(TargetCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTargetCommand(this IAbilityEntity entity, ICommand<IGameEntity> value) => entity.AddValue(TargetCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTargetCommand(this IAbilityEntity entity) => entity.HasValue(TargetCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTargetCommand(this IAbilityEntity entity) => entity.DelValue(TargetCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTargetCommand(this IAbilityEntity entity, ICommand<IGameEntity> value) => entity.SetValue(TargetCommand, value);

		#endregion

		#region Charges

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<int> GetCharges(this IAbilityEntity entity) => entity.GetValue<IVariable<int>>(Charges);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCharges(this IAbilityEntity entity, out IVariable<int> value) => entity.TryGetValue(Charges, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCharges(this IAbilityEntity entity, IVariable<int> value) => entity.AddValue(Charges, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharges(this IAbilityEntity entity) => entity.HasValue(Charges);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharges(this IAbilityEntity entity) => entity.DelValue(Charges);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCharges(this IAbilityEntity entity, IVariable<int> value) => entity.SetValue(Charges, value);

		#endregion

		#region Cooldown

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICooldown GetCooldown(this IAbilityEntity entity) => entity.GetValue<ICooldown>(Cooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCooldown(this IAbilityEntity entity, out ICooldown value) => entity.TryGetValue(Cooldown, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCooldown(this IAbilityEntity entity, ICooldown value) => entity.AddValue(Cooldown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCooldown(this IAbilityEntity entity) => entity.HasValue(Cooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCooldown(this IAbilityEntity entity) => entity.DelValue(Cooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCooldown(this IAbilityEntity entity, ICooldown value) => entity.SetValue(Cooldown, value);

		#endregion
    }
}
