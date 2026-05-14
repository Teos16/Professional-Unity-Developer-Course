using UnityEngine;

namespace Game.Scripts.System
{
    public sealed class JumpController : MonoBehaviour
    {
        [SerializeField] private GameObject _character;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _character.GetComponent<JumpRequestComponent>().TryJump();
        }
    }
}