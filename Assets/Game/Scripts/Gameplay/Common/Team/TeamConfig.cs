using UnityEngine;

namespace Game.Gameplay
{
    [CreateAssetMenu(
        fileName = "TeamConfig",
        menuName = "Game/New TeamConfig"
    )]
    public sealed class TeamConfig : ScriptableObject
    {
        public Material Material => this._material;
        public TeamType Team => _team;
        public InputMap InputMap => _inputMap;
        public int CameraDisplay => (int) _team - 1;
        
        [SerializeField]
        private TeamType _team;

        [SerializeField]
        private Material _material;

        [SerializeField]
        private InputMap _inputMap;
    }
}