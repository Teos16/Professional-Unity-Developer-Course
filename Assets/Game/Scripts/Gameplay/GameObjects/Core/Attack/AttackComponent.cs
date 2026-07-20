using System;
using UnityEngine;

namespace SampleGame
{
    public sealed class AttackComponent : MonoBehaviour
    {
        public interface IAction
        {
            void Invoke(GameObject target);
            void Invoke(Vector3 point);
        }

        public interface ICondition
        {
            bool IsMet(GameObject target);
            bool IsMet(Vector3 point);
        }

        public event Action OnFire;

        private ICondition _condition;
        private IAction _action;

        public void SetCondition(ICondition condition) => _condition = condition;

        public void SetAction(IAction action) => _action = action;

        public bool CanFire(GameObject target) => _condition == null || _condition.IsMet(target);

        public bool CanFire(Vector3 point) => _condition == null || _condition.IsMet(point);

        public void Attack(GameObject target)
        {
            if (CanFire(target))
            {
                _action.Invoke(target);
                OnFire?.Invoke();
            }
        }
        
        public void Attack(Vector3 point)
        {
            if (CanFire(point))
            {
                _action.Invoke(point);
                OnFire?.Invoke();
            }
        }
    }
}