using UnityEngine;

namespace Game
{
    public sealed class PushRigidbodyComponent : MonoBehaviour
    {
        public interface ICondition  
        {  
            bool Evaluate();  
        }
        
        private ICondition _condition;
        private Rigidbody2D _rigidbody;
        private Vector2 _pushForce;
        
        private float _pushTimer = -1;

        private void FixedUpdate()
        {
            if (_pushTimer < 0) return;

            _pushTimer -= Time.fixedDeltaTime;

            if (_pushTimer <= 0)
                Push();
        }
        
        public void SetCondition(ICondition condition) => _condition = condition;
        
        public bool TryPush(Rigidbody2D rb, MoveRigidbodyConfig config, Vector2 sourcePosition)
        {
            if (!_condition.Evaluate() || !rb) 
                return false;
    
            int side = rb.position.x > sourcePosition.x ? 1 : -1;
            if (config.ForceMode == ForceMode.Pull) side = -side;
            Vector2 force = new Vector2(side * config.PushForce.x, config.PushForce.y);
    
            _rigidbody = rb;
            _pushForce = force;
            _pushTimer = config.Lag;
    
            return true;
        }
        
        private void Push()
        {
            if(_rigidbody != null)
                _rigidbody.AddForce(_pushForce, ForceMode2D.Impulse);
            
            _rigidbody = null;
            _pushForce = Vector2.zero;
            _pushTimer = -1f;
        }
    }
}