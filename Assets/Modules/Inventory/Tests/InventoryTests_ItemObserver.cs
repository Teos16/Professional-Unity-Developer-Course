using System.Collections.Generic;
using NUnit.Framework;

namespace Modules.Inventories
{
    public sealed class InventoryTests_ItemObserver
    {
        [Test]
        public void SubscribeOnItem()
        {
            //Arrange:
            const string sword = "Sword";
            const string boots = "Boots";

            const int countToAdd = 5;
            
            var inventory = new Inventory<string>();
            var observer = new MockObserver();

            //Pre-assert:
            Assert.Zero(observer.Count);
            inventory.Subscribe(sword, observer);

            //Act:
            inventory.AddItems(sword, countToAdd);
            inventory.AddItems(boots, 3333);

            //Assert:
            Assert.AreEqual(countToAdd, observer.Count);
        }

        private sealed class MockObserver : Inventory<string>.IItemObserver
        {
            public int Count;

            public void OnCountChanged(int count)
            {
                this.Count = count;
            }
        }
    }
}