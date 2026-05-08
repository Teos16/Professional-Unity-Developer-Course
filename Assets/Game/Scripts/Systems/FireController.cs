using Game.Scripts.GameObjects.Components.Fire;
using SampleGame.Components;
using UnityEngine;

namespace SampleGame
{
    public class FireController : MonoBehaviour
    {
        [SerializeField] private GameObject _character;

        private void Update()
        {
            /*if (Input.GetKeyDown(KeyCode.Space))
                _character.GetComponent<IFireComponent>().Fire();   */         
            
            if (Input.GetKeyDown(KeyCode.Q))
                _character.GetComponent<IDualFireComponent>().FireLeft();
            
            if (Input.GetKeyDown(KeyCode.E))
                _character.GetComponent<IDualFireComponent>().FireRight();
        }
    }
}