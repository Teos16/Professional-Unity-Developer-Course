using System.Collections.Generic;
using NUnit.Framework;

namespace Modules.Inventories
{
    public sealed partial class InventoryTests
    {
        [TestCaseSource(nameof(AddItemsCases))]
        public void AddItems(string item, int count, bool expectedResult, int expectedCount)
        {
            //Arrange:
            var inventory = new Inventory<string>();

            //Act:
            bool actualResult = inventory.AddItems(item, count);

            //Assert:
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expectedCount, inventory.GetCount(item));
        }

        private static IEnumerable<TestCaseData> AddItemsCases()
        {
            yield return new TestCaseData("Sword", 2, true, 2);
            yield return new TestCaseData("Boots", 3, true, 3);
            yield return new TestCaseData("Helmet", 4, true, 4);
        }
        
        [Test]
        public void WhenAddNewItem_ThenOnCellAddedEventOccurs()
        {
            const string sword = "Sword";
            const int countToAdd = 5;

            string actualItem = string.Empty;
            int actualCount = 0;

            //Arrange:
            var inventory = new Inventory<string>();
            inventory.OnCellAdded += (i, c) =>
            {
                actualItem = i;
                actualCount = c;
            };

            //Act:
            inventory.AddItems(sword, countToAdd);

            //Assert:
            Assert.AreEqual(sword, actualItem);
            Assert.AreEqual(countToAdd, actualCount);
        }

        [Test]
        public void WhenAddItem_ThenOnCountChangedEventOccurs()
        {
            const string sword = "Sword";
            const int countToAdd = 5;

            string actualItem = string.Empty;
            int actualCount = 0;

            //Arrange:
            var inventory = new Inventory<string>();
            inventory.OnCountChanged += (i, c) =>
            {
                actualItem = i;
                actualCount = c;
            };

            //Act:
            inventory.AddItems(sword, countToAdd);

            //Assert:
            Assert.AreEqual(sword, actualItem);
            Assert.AreEqual(countToAdd, actualCount);
        }
    }
}