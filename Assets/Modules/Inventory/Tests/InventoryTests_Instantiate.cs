using System.Collections.Generic;
using NUnit.Framework;

namespace Modules.Inventories
{
    public sealed partial class InventoryTests
    {
        [Test]
        public void InstantiateWithItems()
        {
            //Arrange:
            const string sword = "Sword";
            const string boots = "Boots";
            const string helmet = "Helmet";

            IEnumerable<KeyValuePair<string, int>> items = new KeyValuePair<string, int>[]
            {
                new(sword, 3),
                new(boots, 5),
                new(helmet, 2)
            };
            var inventory = new Inventory<string>(items);

            //Assert:
            Assert.AreEqual(3, inventory.GetCount(sword));
            Assert.AreEqual(5, inventory.GetCount(boots));
            Assert.AreEqual(2, inventory.GetCount(helmet));
        }
    }
}