using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class AbortedToFailureNode : BehaviourNode
    {
        [SerializeField]
        private BehaviourNode _origin;

        protected override BehaviourResult OnUpdate(float deltaTime)
        {
            BehaviourResult result = _origin.Run(deltaTime);
            return result == BehaviourResult.Aborted ? BehaviourResult.Failure : result;
        }

        protected override void OnAbort()
        {
            if (_origin.IsRunning)
                _origin.Abort();
        }
    }
}