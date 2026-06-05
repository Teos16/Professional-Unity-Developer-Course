/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using static Atomic.Entities.EntityNames;
using System.Runtime.CompilerServices;
#if UNITY_EDITOR
using UnityEditor;
#endif
using Game.App;
using Atomic.Elements;
using Game.Gameplay;
using Game.UI;

namespace Game.App
{
#if UNITY_EDITOR
	[InitializeOnLoad]
#endif
	public static class AppContextAPI
	{
		///Values
		public static readonly int StartLevel; // IValue<int>
		public static readonly int MaxLevel; // IValue<int>
		public static readonly int CurrentLevel; // IReactiveVariable<int>
		public static readonly int LevelRepository; // ILevelRepository
		public static readonly int MenuLoadedEvent; // IEvent
		public static readonly int GameContextPrefab; // GameContext
		public static readonly int GameUIPrefab; // GameUI

		static AppContextAPI()
		{
			//Values
			StartLevel = NameToId(nameof(StartLevel));
			MaxLevel = NameToId(nameof(MaxLevel));
			CurrentLevel = NameToId(nameof(CurrentLevel));
			LevelRepository = NameToId(nameof(LevelRepository));
			MenuLoadedEvent = NameToId(nameof(MenuLoadedEvent));
			GameContextPrefab = NameToId(nameof(GameContextPrefab));
			GameUIPrefab = NameToId(nameof(GameUIPrefab));
		}


		///Value Extensions

		#region StartLevel

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetStartLevel(this IAppContext entity) => entity.GetValue<IValue<int>>(StartLevel);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetStartLevel(this IAppContext entity, out IValue<int> value) => entity.TryGetValue(StartLevel, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddStartLevel(this IAppContext entity, IValue<int> value) => entity.AddValue(StartLevel, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasStartLevel(this IAppContext entity) => entity.HasValue(StartLevel);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelStartLevel(this IAppContext entity) => entity.DelValue(StartLevel);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetStartLevel(this IAppContext entity, IValue<int> value) => entity.SetValue(StartLevel, value);

		#endregion

		#region MaxLevel

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetMaxLevel(this IAppContext entity) => entity.GetValue<IValue<int>>(MaxLevel);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMaxLevel(this IAppContext entity, out IValue<int> value) => entity.TryGetValue(MaxLevel, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMaxLevel(this IAppContext entity, IValue<int> value) => entity.AddValue(MaxLevel, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMaxLevel(this IAppContext entity) => entity.HasValue(MaxLevel);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMaxLevel(this IAppContext entity) => entity.DelValue(MaxLevel);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMaxLevel(this IAppContext entity, IValue<int> value) => entity.SetValue(MaxLevel, value);

		#endregion

		#region CurrentLevel

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetCurrentLevel(this IAppContext entity) => entity.GetValue<IReactiveVariable<int>>(CurrentLevel);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCurrentLevel(this IAppContext entity, out IReactiveVariable<int> value) => entity.TryGetValue(CurrentLevel, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCurrentLevel(this IAppContext entity, IReactiveVariable<int> value) => entity.AddValue(CurrentLevel, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCurrentLevel(this IAppContext entity) => entity.HasValue(CurrentLevel);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCurrentLevel(this IAppContext entity) => entity.DelValue(CurrentLevel);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCurrentLevel(this IAppContext entity, IReactiveVariable<int> value) => entity.SetValue(CurrentLevel, value);

		#endregion

		#region LevelRepository

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ILevelRepository GetLevelRepository(this IAppContext entity) => entity.GetValue<ILevelRepository>(LevelRepository);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetLevelRepository(this IAppContext entity, out ILevelRepository value) => entity.TryGetValue(LevelRepository, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddLevelRepository(this IAppContext entity, ILevelRepository value) => entity.AddValue(LevelRepository, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasLevelRepository(this IAppContext entity) => entity.HasValue(LevelRepository);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelLevelRepository(this IAppContext entity) => entity.DelValue(LevelRepository);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetLevelRepository(this IAppContext entity, ILevelRepository value) => entity.SetValue(LevelRepository, value);

		#endregion

		#region MenuLoadedEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetMenuLoadedEvent(this IAppContext entity) => entity.GetValue<IEvent>(MenuLoadedEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMenuLoadedEvent(this IAppContext entity, out IEvent value) => entity.TryGetValue(MenuLoadedEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMenuLoadedEvent(this IAppContext entity, IEvent value) => entity.AddValue(MenuLoadedEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMenuLoadedEvent(this IAppContext entity) => entity.HasValue(MenuLoadedEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMenuLoadedEvent(this IAppContext entity) => entity.DelValue(MenuLoadedEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMenuLoadedEvent(this IAppContext entity, IEvent value) => entity.SetValue(MenuLoadedEvent, value);

		#endregion

		#region GameContextPrefab

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GameContext GetGameContextPrefab(this IAppContext entity) => entity.GetValue<GameContext>(GameContextPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGameContextPrefab(this IAppContext entity, out GameContext value) => entity.TryGetValue(GameContextPrefab, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddGameContextPrefab(this IAppContext entity, GameContext value) => entity.AddValue(GameContextPrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGameContextPrefab(this IAppContext entity) => entity.HasValue(GameContextPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGameContextPrefab(this IAppContext entity) => entity.DelValue(GameContextPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGameContextPrefab(this IAppContext entity, GameContext value) => entity.SetValue(GameContextPrefab, value);

		#endregion

		#region GameUIPrefab

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GameUI GetGameUIPrefab(this IAppContext entity) => entity.GetValue<GameUI>(GameUIPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGameUIPrefab(this IAppContext entity, out GameUI value) => entity.TryGetValue(GameUIPrefab, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddGameUIPrefab(this IAppContext entity, GameUI value) => entity.AddValue(GameUIPrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGameUIPrefab(this IAppContext entity) => entity.HasValue(GameUIPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGameUIPrefab(this IAppContext entity) => entity.DelValue(GameUIPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGameUIPrefab(this IAppContext entity, GameUI value) => entity.SetValue(GameUIPrefab, value);

		#endregion
    }
}
