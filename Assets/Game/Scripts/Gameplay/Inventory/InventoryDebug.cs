using Modules.Inventories;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace SampleGame.Gameplay
{
    //Нельзя менять!
    public sealed class InventoryDebug : MonoBehaviour
    {
        [Inject]
        [ShowInInspector, HideInEditorMode]
        private Inventory<Item> inventory;

        [Inject]
        [ShowInInspector, HideInEditorMode]
        private ItemConsumer consumer;

        private void OnEnable()
        {
            this.consumer.OnItemConsumed += this.OnConsumed;
        }

        private void OnDisable()
        {
            this.consumer.OnItemConsumed -= this.OnConsumed;
        }

        private void OnConsumed(Item item)
        {
            Debug.Log($"<color=green>{item.Title}</color> activated!");
        }
    }
}