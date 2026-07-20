using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class RetryUntilSuccessNode : BehaviourNode
    {
        [SerializeField]
        private BehaviourNode _origin;

        [SerializeField]
        private Blackboard _blackboard;

        [SerializeField, BlackboardTagKey]
        private string _blackboardFailureTag;

        protected override BehaviourResult OnUpdate(float deltaTime)
        {
            BehaviourResult result = _origin.Run(deltaTime);
            if (result == BehaviourResult.Failure)
            {
                _blackboard.AddTag(_blackboardFailureTag);
                result = BehaviourResult.Running;
            }

            return result;
        }

        protected override void OnStop(BehaviourResult result) => 
            _blackboard.DelTag(_blackboardFailureTag);
    }
}