using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.ShipRelated
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [field:HideInInspector] [field:SerializeField] public Vector3 MoveDirection { get; private set; }
        public float MoveSpeed { get; private set; }

        [SerializeField] private PositionDriver positionDriver;

        private HashSet<Func<bool>> _moveConditions = new();

        private void FixedUpdate() => positionDriver.FixedUpdate();

        public void Initialize(ShipConfig config)
        {
            MoveSpeed = config.MoveSpeed;
            positionDriver.SetSpeed(config.MoveSpeed);
        }

        public void AddMoveCondition(Func<bool> condition) => _moveConditions.Add(condition);
        
        public void MoveStep(Vector2 direction)
        {
            if(CanMove())
                positionDriver.MoveStep(direction * MoveSpeed);
        }

        private bool CanMove()
        {
            if(_moveConditions.Count == 0) 
                return true;
            
            foreach (var condition in _moveConditions)
            {
                if (!condition.Invoke()) 
                    return false;
            }
            return true;
        }
    }
}