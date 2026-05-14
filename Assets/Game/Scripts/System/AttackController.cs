using UnityEngine;

namespace Game.Scripts.System
{
    public sealed class AttackController : MonoBehaviour
    {
        [SerializeField] private GameObject _character;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                _character.GetComponent<IStaff>().Push();
            else if (Input.GetKeyDown(KeyCode.Mouse1))
                _character.GetComponent<IStaff>().Toss();
        }
    }
}