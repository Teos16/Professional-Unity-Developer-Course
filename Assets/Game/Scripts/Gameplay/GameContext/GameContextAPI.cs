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
using System.Collections.Generic;
using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
#if UNITY_EDITOR
	[InitializeOnLoad]
#endif
	public static class GameContextAPI
	{
		///Values
		public static readonly int BulletPool; // IEntityPool<IGameEntity>
		public static readonly int PrefabPool; // PrefabEntityPool
		public static readonly int WorldTransform; // Transform
		public static readonly int GameStartedEvent; // IEvent
		public static readonly int GameFinishedEvent; // IEvent
		public static readonly int GameTime; // IReactiveVariable<float>
		public static readonly int Players; // IDictionary<TeamType,IPlayerContext>
		public static readonly int Leaderboard; // IReactiveDictionary<TeamType,int>
		public static readonly int AllSpawnPoints; // Transform[]
		public static readonly int FreeSpawnPoints; // List<Transform>

		static GameContextAPI()
		{
			//Values
			BulletPool = NameToId(nameof(BulletPool));
			PrefabPool = NameToId(nameof(PrefabPool));
			WorldTransform = NameToId(nameof(WorldTransform));
			GameStartedEvent = NameToId(nameof(GameStartedEvent));
			GameFinishedEvent = NameToId(nameof(GameFinishedEvent));
			GameTime = NameToId(nameof(GameTime));
			Players = NameToId(nameof(Players));
			Leaderboard = NameToId(nameof(Leaderboard));
			AllSpawnPoints = NameToId(nameof(AllSpawnPoints));
			FreeSpawnPoints = NameToId(nameof(FreeSpawnPoints));
		}


		///Value Extensions

		#region BulletPool

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEntityPool<IGameEntity> GetBulletPool(this IGameContext entity) => entity.GetValue<IEntityPool<IGameEntity>>(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBulletPool(this IGameContext entity, out IEntityPool<IGameEntity> value) => entity.TryGetValue(BulletPool, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddBulletPool(this IGameContext entity, IEntityPool<IGameEntity> value) => entity.AddValue(BulletPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBulletPool(this IGameContext entity) => entity.HasValue(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBulletPool(this IGameContext entity) => entity.DelValue(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBulletPool(this IGameContext entity, IEntityPool<IGameEntity> value) => entity.SetValue(BulletPool, value);

		#endregion

		#region PrefabPool

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PrefabEntityPool GetPrefabPool(this IGameContext entity) => entity.GetValue<PrefabEntityPool>(PrefabPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPrefabPool(this IGameContext entity, out PrefabEntityPool value) => entity.TryGetValue(PrefabPool, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPrefabPool(this IGameContext entity, PrefabEntityPool value) => entity.AddValue(PrefabPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPrefabPool(this IGameContext entity) => entity.HasValue(PrefabPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPrefabPool(this IGameContext entity) => entity.DelValue(PrefabPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPrefabPool(this IGameContext entity, PrefabEntityPool value) => entity.SetValue(PrefabPool, value);

		#endregion

		#region WorldTransform

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetWorldTransform(this IGameContext entity) => entity.GetValue<Transform>(WorldTransform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWorldTransform(this IGameContext entity, out Transform value) => entity.TryGetValue(WorldTransform, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddWorldTransform(this IGameContext entity, Transform value) => entity.AddValue(WorldTransform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWorldTransform(this IGameContext entity) => entity.HasValue(WorldTransform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWorldTransform(this IGameContext entity) => entity.DelValue(WorldTransform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWorldTransform(this IGameContext entity, Transform value) => entity.SetValue(WorldTransform, value);

		#endregion

		#region GameStartedEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetGameStartedEvent(this IGameContext entity) => entity.GetValue<IEvent>(GameStartedEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGameStartedEvent(this IGameContext entity, out IEvent value) => entity.TryGetValue(GameStartedEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddGameStartedEvent(this IGameContext entity, IEvent value) => entity.AddValue(GameStartedEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGameStartedEvent(this IGameContext entity) => entity.HasValue(GameStartedEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGameStartedEvent(this IGameContext entity) => entity.DelValue(GameStartedEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGameStartedEvent(this IGameContext entity, IEvent value) => entity.SetValue(GameStartedEvent, value);

		#endregion

		#region GameFinishedEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetGameFinishedEvent(this IGameContext entity) => entity.GetValue<IEvent>(GameFinishedEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGameFinishedEvent(this IGameContext entity, out IEvent value) => entity.TryGetValue(GameFinishedEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddGameFinishedEvent(this IGameContext entity, IEvent value) => entity.AddValue(GameFinishedEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGameFinishedEvent(this IGameContext entity) => entity.HasValue(GameFinishedEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGameFinishedEvent(this IGameContext entity) => entity.DelValue(GameFinishedEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGameFinishedEvent(this IGameContext entity, IEvent value) => entity.SetValue(GameFinishedEvent, value);

		#endregion

		#region GameTime

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<float> GetGameTime(this IGameContext entity) => entity.GetValue<IReactiveVariable<float>>(GameTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGameTime(this IGameContext entity, out IReactiveVariable<float> value) => entity.TryGetValue(GameTime, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddGameTime(this IGameContext entity, IReactiveVariable<float> value) => entity.AddValue(GameTime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGameTime(this IGameContext entity) => entity.HasValue(GameTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGameTime(this IGameContext entity) => entity.DelValue(GameTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGameTime(this IGameContext entity, IReactiveVariable<float> value) => entity.SetValue(GameTime, value);

		#endregion

		#region Players

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IDictionary<TeamType,IPlayerContext> GetPlayers(this IGameContext entity) => entity.GetValue<IDictionary<TeamType,IPlayerContext>>(Players);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPlayers(this IGameContext entity, out IDictionary<TeamType,IPlayerContext> value) => entity.TryGetValue(Players, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPlayers(this IGameContext entity, IDictionary<TeamType,IPlayerContext> value) => entity.AddValue(Players, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPlayers(this IGameContext entity) => entity.HasValue(Players);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPlayers(this IGameContext entity) => entity.DelValue(Players);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPlayers(this IGameContext entity, IDictionary<TeamType,IPlayerContext> value) => entity.SetValue(Players, value);

		#endregion

		#region Leaderboard

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveDictionary<TeamType,int> GetLeaderboard(this IGameContext entity) => entity.GetValue<IReactiveDictionary<TeamType,int>>(Leaderboard);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetLeaderboard(this IGameContext entity, out IReactiveDictionary<TeamType,int> value) => entity.TryGetValue(Leaderboard, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddLeaderboard(this IGameContext entity, IReactiveDictionary<TeamType,int> value) => entity.AddValue(Leaderboard, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasLeaderboard(this IGameContext entity) => entity.HasValue(Leaderboard);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelLeaderboard(this IGameContext entity) => entity.DelValue(Leaderboard);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetLeaderboard(this IGameContext entity, IReactiveDictionary<TeamType,int> value) => entity.SetValue(Leaderboard, value);

		#endregion

		#region AllSpawnPoints

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform[] GetAllSpawnPoints(this IGameContext entity) => entity.GetValue<Transform[]>(AllSpawnPoints);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAllSpawnPoints(this IGameContext entity, out Transform[] value) => entity.TryGetValue(AllSpawnPoints, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAllSpawnPoints(this IGameContext entity, Transform[] value) => entity.AddValue(AllSpawnPoints, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAllSpawnPoints(this IGameContext entity) => entity.HasValue(AllSpawnPoints);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAllSpawnPoints(this IGameContext entity) => entity.DelValue(AllSpawnPoints);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAllSpawnPoints(this IGameContext entity, Transform[] value) => entity.SetValue(AllSpawnPoints, value);

		#endregion

		#region FreeSpawnPoints

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static List<Transform> GetFreeSpawnPoints(this IGameContext entity) => entity.GetValue<List<Transform>>(FreeSpawnPoints);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFreeSpawnPoints(this IGameContext entity, out List<Transform> value) => entity.TryGetValue(FreeSpawnPoints, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFreeSpawnPoints(this IGameContext entity, List<Transform> value) => entity.AddValue(FreeSpawnPoints, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFreeSpawnPoints(this IGameContext entity) => entity.HasValue(FreeSpawnPoints);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFreeSpawnPoints(this IGameContext entity) => entity.DelValue(FreeSpawnPoints);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFreeSpawnPoints(this IGameContext entity, List<Transform> value) => entity.SetValue(FreeSpawnPoints, value);

		#endregion
    }
}
