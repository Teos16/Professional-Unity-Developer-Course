// /**
// * Code generation. Don't modify! 
// **/
//
// using Atomic.Entities;
// using static Atomic.Entities.EntityNames;
// using System.Runtime.CompilerServices;
// #if UNITY_EDITOR
// using UnityEditor;
// #endif
// using Game.Gameplay;
// using UnityEngine;
// using Atomic.Elements;
//
// namespace Game.Gameplay
// {
// #if UNITY_EDITOR
// 	[InitializeOnLoad]
// #endif
// 	public static class PlayerContextAPI
// 	{
// 		///Values
// 		public static readonly int Character; // IGameEntity
// 		public static readonly int Camera; // Camera
// 		public static readonly int InputMap; // InputMap
// 		public static readonly int Team; // IValue<TeamType>
// 		public static readonly int Score; // IReactiveVariable<int>
// 		public static readonly int RespawnCooldown; // ICooldown
//
// 		static PlayerContextAPI()
// 		{
// 			//Values
// 			Character = NameToId(nameof(Character));
// 			Camera = NameToId(nameof(Camera));
// 			InputMap = NameToId(nameof(InputMap));
// 			Team = NameToId(nameof(Team));
// 			Score = NameToId(nameof(Score));
// 			RespawnCooldown = NameToId(nameof(RespawnCooldown));
// 		}
//
//
// 		///Value Extensions
//
// 		#region Character
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static IGameEntity GetCharacter(this IPlayerContext entity) => entity.GetValue<IGameEntity>(Character);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static bool TryGetCharacter(this IPlayerContext entity, out IGameEntity value) => entity.TryGetValue(Character, out value);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static void AddCharacter(this IPlayerContext entity, IGameEntity value) => entity.AddValue(Character, value);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static bool HasCharacter(this IPlayerContext entity) => entity.HasValue(Character);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static bool DelCharacter(this IPlayerContext entity) => entity.DelValue(Character);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static void SetCharacter(this IPlayerContext entity, IGameEntity value) => entity.SetValue(Character, value);
//
// 		#endregion
//
// 		#region Camera
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static Camera GetCamera(this IPlayerContext entity) => entity.GetValue<Camera>(Camera);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static bool TryGetCamera(this IPlayerContext entity, out Camera value) => entity.TryGetValue(Camera, out value);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static void AddCamera(this IPlayerContext entity, Camera value) => entity.AddValue(Camera, value);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static bool HasCamera(this IPlayerContext entity) => entity.HasValue(Camera);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static bool DelCamera(this IPlayerContext entity) => entity.DelValue(Camera);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static void SetCamera(this IPlayerContext entity, Camera value) => entity.SetValue(Camera, value);
//
// 		#endregion
//
// 		#region InputMap
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static InputMap GetInputMap(this IPlayerContext entity) => entity.GetValue<InputMap>(InputMap);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static bool TryGetInputMap(this IPlayerContext entity, out InputMap value) => entity.TryGetValue(InputMap, out value);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static void AddInputMap(this IPlayerContext entity, InputMap value) => entity.AddValue(InputMap, value);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static bool HasInputMap(this IPlayerContext entity) => entity.HasValue(InputMap);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static bool DelInputMap(this IPlayerContext entity) => entity.DelValue(InputMap);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static void SetInputMap(this IPlayerContext entity, InputMap value) => entity.SetValue(InputMap, value);
//
// 		#endregion
//
// 		#region Team
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static IValue<TeamType> GetTeam(this IPlayerContext entity) => entity.GetValue<IValue<TeamType>>(Team);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static bool TryGetTeam(this IPlayerContext entity, out IValue<TeamType> value) => entity.TryGetValue(Team, out value);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static void AddTeam(this IPlayerContext entity, IValue<TeamType> value) => entity.AddValue(Team, value);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static bool HasTeam(this IPlayerContext entity) => entity.HasValue(Team);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static bool DelTeam(this IPlayerContext entity) => entity.DelValue(Team);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static void SetTeam(this IPlayerContext entity, IValue<TeamType> value) => entity.SetValue(Team, value);
//
// 		#endregion
//
// 		#region Score
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static IReactiveVariable<int> GetScore(this IPlayerContext entity) => entity.GetValue<IReactiveVariable<int>>(Score);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static bool TryGetScore(this IPlayerContext entity, out IReactiveVariable<int> value) => entity.TryGetValue(Score, out value);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static void AddScore(this IPlayerContext entity, IReactiveVariable<int> value) => entity.AddValue(Score, value);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static bool HasScore(this IPlayerContext entity) => entity.HasValue(Score);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static bool DelScore(this IPlayerContext entity) => entity.DelValue(Score);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static void SetScore(this IPlayerContext entity, IReactiveVariable<int> value) => entity.SetValue(Score, value);
//
// 		#endregion
//
// 		#region RespawnCooldown
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static ICooldown GetRespawnCooldown(this IPlayerContext entity) => entity.GetValue<ICooldown>(RespawnCooldown);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static bool TryGetRespawnCooldown(this IPlayerContext entity, out ICooldown value) => entity.TryGetValue(RespawnCooldown, out value);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static void AddRespawnCooldown(this IPlayerContext entity, ICooldown value) => entity.AddValue(RespawnCooldown, value);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static bool HasRespawnCooldown(this IPlayerContext entity) => entity.HasValue(RespawnCooldown);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static bool DelRespawnCooldown(this IPlayerContext entity) => entity.DelValue(RespawnCooldown);
//
// 		[MethodImpl(MethodImplOptions.AggressiveInlining)]
// 		public static void SetRespawnCooldown(this IPlayerContext entity, ICooldown value) => entity.SetValue(RespawnCooldown, value);
//
// 		#endregion
//     }
// }
