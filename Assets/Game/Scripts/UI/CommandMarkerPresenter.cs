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
                case TargetCommand targetCommand:
                    ShowMarker(targetCommand, targetCommand.TargetObject.transform);
                    break;
                case PositionCommand positionCommand:
                {
                    if (positionCommand.TargetPosition != null)
                        ShowMarker(command, positionCommand.TargetPosition.Value);
                    break;
                }
            }
        }

        private void ShowMarker(ICommand command, Transform target)
        {
            if (target == null)
                return;
            
            switch (command)
            {
                case MoveToTargetCommand:
                    _view.ShowMoveMarker(target);
                    break;
                case PatrolTargetCommand:
                    _view.ShowPatrolMarker(target);
                    break;
                case AddPatrolTargetCommand:
                    _view.ShowPatrolMarker(target);
                    break;
                case FollowTargetCommand:
                    _view.ShowFollowMarker(target);
                    break;
                case AttackTargetCommand:
                    _view.ShowAttackMarker(target);
                    break;
                case HoldPositionCommand:
                    _view.ShowHoldPositionMarker(target.transform.position);
                    break;
            }
        }
        
        private void ShowMarker(ICommand command, Vector3 position)
        {
            switch (command)
            {
                case MoveToPositionCommand:
                    _view.ShowMoveMarker(position);
                    break;
                case PatrolPositionCommand:
                    _view.ShowPatrolMarker(position);
                    break;
                case AddPatrolPointCommand:
                    _view.ShowPatrolMarker(position);
                    break;
                case FollowPositionCommand:
                    _view.ShowFollowMarker(position);
                    break;
                case AttackPositionCommand:
                    _view.ShowAttackMarker(position);
                    break;
            }
        }
    }
}