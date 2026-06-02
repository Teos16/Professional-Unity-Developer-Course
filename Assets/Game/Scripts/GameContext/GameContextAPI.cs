/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using static Atomic.Entities.EntityNames;
using System.Runtime.CompilerServices;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game
{
#if UNITY_EDITOR
	[InitializeOnLoad]
#endif
	public static class GameContextAPI
	{
		///Values
		public static readonly int BulletPool; // SceneEntityPool
		public static readonly int Character; // IEntity

		static GameContextAPI()
		{
			//Values
			BulletPool = NameToId(nameof(BulletPool));
			Character = NameToId(nameof(Character));
		}


		///Value Extensions

		#region BulletPool

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SceneEntityPool GetBulletPool(this IEntity entity) => entity.GetValue<SceneEntityPool>(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBulletPool(this IEntity entity, out SceneEntityPool value) => entity.TryGetValue(BulletPool, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddBulletPool(this IEntity entity, SceneEntityPool value) => entity.AddValue(BulletPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBulletPool(this IEntity entity) => entity.HasValue(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBulletPool(this IEntity entity) => entity.DelValue(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBulletPool(this IEntity entity, SceneEntityPool value) => entity.SetValue(BulletPool, value);

		#endregion

		#region Character

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEntity GetCharacter(this IEntity entity) => entity.GetValue<IEntity>(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCharacter(this IEntity entity, out IEntity value) => entity.TryGetValue(Character, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCharacter(this IEntity entity, IEntity value) => entity.AddValue(Character, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacter(this IEntity entity) => entity.HasValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacter(this IEntity entity) => entity.DelValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCharacter(this IEntity entity, IEntity value) => entity.SetValue(Character, value);

		#endregion
    }
}
