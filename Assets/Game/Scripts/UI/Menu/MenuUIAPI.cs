/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using static Atomic.Entities.EntityNames;
using System.Runtime.CompilerServices;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections.Generic;
using Game.UI;
using System;
using Atomic.Elements;

namespace Game.UI
{
#if UNITY_EDITOR
	[InitializeOnLoad]
#endif
	public static class MenuUIAPI
	{
		///Values
		public static readonly int Screens; // IDictionary<Type,IScreenPresenter>
		public static readonly int CurrentScreen; // IReactiveVariable<IScreenPresenter>

		static MenuUIAPI()
		{
			//Values
			Screens = NameToId(nameof(Screens));
			CurrentScreen = NameToId(nameof(CurrentScreen));
		}


		///Value Extensions

		#region Screens

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IDictionary<Type,IScreenPresenter> GetScreens(this IMenuUI entity) => entity.GetValue<IDictionary<Type,IScreenPresenter>>(Screens);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetScreens(this IMenuUI entity, out IDictionary<Type,IScreenPresenter> value) => entity.TryGetValue(Screens, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddScreens(this IMenuUI entity, IDictionary<Type,IScreenPresenter> value) => entity.AddValue(Screens, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasScreens(this IMenuUI entity) => entity.HasValue(Screens);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelScreens(this IMenuUI entity) => entity.DelValue(Screens);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetScreens(this IMenuUI entity, IDictionary<Type,IScreenPresenter> value) => entity.SetValue(Screens, value);

		#endregion

		#region CurrentScreen

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<IScreenPresenter> GetCurrentScreen(this IMenuUI entity) => entity.GetValue<IReactiveVariable<IScreenPresenter>>(CurrentScreen);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCurrentScreen(this IMenuUI entity, out IReactiveVariable<IScreenPresenter> value) => entity.TryGetValue(CurrentScreen, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCurrentScreen(this IMenuUI entity, IReactiveVariable<IScreenPresenter> value) => entity.AddValue(CurrentScreen, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCurrentScreen(this IMenuUI entity) => entity.HasValue(CurrentScreen);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCurrentScreen(this IMenuUI entity) => entity.DelValue(CurrentScreen);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCurrentScreen(this IMenuUI entity, IReactiveVariable<IScreenPresenter> value) => entity.SetValue(CurrentScreen, value);

		#endregion
    }
}
