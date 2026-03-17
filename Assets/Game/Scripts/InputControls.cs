using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "SnakeInputControls", menuName = "Game/SnakeInputControls")]
    public sealed class InputControls : ScriptableObject
    {
        [field: SerializeField] public KeyCode Left { get; private set; } = KeyCode.LeftArrow;
        [field: SerializeField] public KeyCode Right { get; private set; } = KeyCode.RightArrow;
        [field: SerializeField] public KeyCode Up { get; private set; } = KeyCode.UpArrow;
        [field: SerializeField] public KeyCode Down { get; private set; } = KeyCode.DownArrow;
    }
}