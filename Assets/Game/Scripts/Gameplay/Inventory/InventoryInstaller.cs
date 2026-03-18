using System;
using System.Collections.Generic;
using System.Linq;
using Modules.Inventories;
using UnityEngine;
using Zenject;

namespace SampleGame.Gameplay
{
    [CreateAssetMenu(
        fileName = "InventoryInstaller",
        menuName = "SampleGame/New InventoryInstaller"
    )]
    public sealed class InventoryInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private ItemInfo[] _initialItems;

        public override void InstallBindings()
        {
            this.Container
                .Bind<Inventory<Item>>()
                .FromMethod(this.CreateInventory)
                .AsSingle()
                .NonLazy();

            this.Container
                .BindInterfacesAndSelfTo<ItemConsumer>()
                .AsSingle()
                .NonLazy();
        }

        private Inventory<Item> CreateInventory()
        {
            var items = _initialItems.Select(it => new KeyValuePair<Item, int>(it.item, it.count));
            return new Inventory<Item>(items);
        }

        [Serializable]
        private struct ItemInfo
        {
            public Item item;
            public int count;
        }
    }
}