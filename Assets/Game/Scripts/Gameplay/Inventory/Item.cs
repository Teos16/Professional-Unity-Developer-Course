using Sirenix.OdinInspector;
using UnityEngine;

namespace SampleGame.Gameplay
{
    [CreateAssetMenu(
        fileName = "Item",
        menuName = "SampleGame/New Item"
    )]
    public sealed class Item : ScriptableObject
    {
        [field: SerializeField]
        public string Title { get; private set; }

        [field: TextArea]
        [field: SerializeField]
        public string Description { get; private set; }
        
        [field: PreviewField]
        [field: SerializeField]
        public Sprite Icon { get; private set; }
        
        [field: SerializeField]
        public bool IsConsumable { get; private set; }
        
        [field: SerializeField]
        public bool IsEquippable { get; private set; }
    }
}