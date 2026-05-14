using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(CollisionComponent))]
    public sealed class ParentingComponent : MonoBehaviour
    {
        private CollisionComponent _collisionComponent;
        
        private void Awake() => _collisionComponent = GetComponent<CollisionComponent>();

        private void OnEnable()
        {
            _collisionComponent.OnEntered += Parent;
            _collisionComponent.OnExited += Unparent;
        }
        
        private void OnDisable()
        {
            _collisionComponent.OnEntered -= Parent;
            _collisionComponent.OnExited -= Unparent;
        }
        
        private void Parent(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Rigidbody2D rb)) 
                rb.transform.SetParent(transform.root);
        }
        
        private void Unparent(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Rigidbody2D rb)) 
                rb.transform.SetParent(null);
        }
    }
}