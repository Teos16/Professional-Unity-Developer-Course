using System;
using UnityEngine;

namespace Game.Gameplay
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorEventReceiver : MonoBehaviour
    {
        private const string FIRE_EVENT = "fire_event";
        private const string MOVE_STEP_EVENT = "move_step_event";
        private const string BODY_FALL_EVENT = "body_fall_event";
        
        public event Action OnFireEvent;
        public event Action OnMoveStepEvent;
        public event Action OnBodyFallEvent;
        
        private void OnAnimatorMove() { }

        public void ReceiveEvent(AnimationEvent animEvent)
        {
            string eventName = animEvent.stringParameter;
            
            if (eventName == FIRE_EVENT)
                OnFireEvent?.Invoke();
            else if (eventName == MOVE_STEP_EVENT)
                OnMoveStepEvent?.Invoke();
            else if (eventName == BODY_FALL_EVENT)
                OnBodyFallEvent?.Invoke();
        }
    }
}