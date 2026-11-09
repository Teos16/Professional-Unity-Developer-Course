using Sirenix.OdinInspector;
using UnityEngine;

namespace SampleGame
{
    public sealed class CommandMarkerPresenter : SerializedMonoBehaviour
    {
        [SerializeField] private CommandMarkerView _view;
        [SerializeField] private CommandManager _commandManager;

        private void Start() => _commandManager.OnCommandTrigger += ShowMarker;

        private void OnDestroy() => _commandManager.OnCommandTrigger -= ShowMarker;

        private void ShowMarker(ICommand command)
        {
            switch (command)
            {
                case MoveToPositionCommand c:
                    _view.ShowMoveMarker(c.Position);
                    break;
                case MoveToTargetCommand c:
                    _view.ShowMoveMarker(c.Target.transform);
                    break;
                case FollowCommand c:
                    _view.ShowFollowMarker(c.Target.transform);
                    break;
                case HoldCommand:
                    _view.ShowHoldPositionMarker(_commandManager.transform.position);
                    break;
            }
        }
    }
}