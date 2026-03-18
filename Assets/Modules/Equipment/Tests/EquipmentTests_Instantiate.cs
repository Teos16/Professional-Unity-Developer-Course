using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Modules.Equipments
{
    public sealed partial class EquipmentTests
    {
        [Test]
        public void Instantiate()
        {
            //Arrange:
            var equpment = new Equipment<SlotType, object>();

            //Assert:
            Assert.IsNotNull(equpment);
            Assert.AreEqual(4, equpment.Capacity);
            Assert.AreEqual(0, equpment.Count);
        }


        [Test]
        public void WhenInstantiateWithNullItemsThenException()
        {
            Assert.Catch<ArgumentNullException>(() =>
            {
                var _ = new Equipment<SlotType, object>(null);
            });
        }

        [Test]
        public void InstantiateWithItems()
        {
            //Arrange:
            var sword = new object();
            var boots = new object();

            var equpment = new Equipment<SlotType, object>(
                new KeyValuePair<SlotType, object>(SlotType.HANDS, sword),
                new KeyValuePair<SlotType, object>(SlotType.LEGS, boots)
            );

            //Assert:
            Assert.IsNotNull(equpment);
            Assert.AreEqual(4, equpment.Capacity);
            Assert.AreEqual(2, equpment.Count);
        }
    }
}