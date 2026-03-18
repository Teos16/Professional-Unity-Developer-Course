using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Modules.Equipments
{
    public sealed partial class EquipmentTests
    {
        [TestCase(SlotType.HEAD)]
        [TestCase(SlotType.BODY)]
        [TestCase(SlotType.HANDS)]
        [TestCase(SlotType.LEGS)]
        public void WhenAddNullItemThenException(SlotType type)
        {
            var equpment = new Equipment<SlotType, object>();
            Assert.Catch<ArgumentNullException>(() => equpment.Add(type, null));
        }

        [TestCaseSource(nameof(AddCases))]
        public bool Add(Equipment<SlotType, object> equipment, SlotType type, object item)
        {
            return equipment.Add(type, item);
        }

        private static IEnumerable<TestCaseData> AddCases()
        {
            var sword = new object();
            var boots = new object();
            var helmet = new object();
            var armor = new object();

            var equpment = new Equipment<SlotType, object>(
                new KeyValuePair<SlotType, object>(SlotType.HANDS, sword),
                new KeyValuePair<SlotType, object>(SlotType.LEGS, boots)
            );

            yield return new TestCaseData(equpment, SlotType.HANDS, sword).Returns(false).SetName("Sword");
            yield return new TestCaseData(equpment, SlotType.LEGS, boots).Returns(false).SetName("Boots");
            yield return new TestCaseData(equpment, SlotType.HEAD, helmet).Returns(true).SetName("Helmet");
            yield return new TestCaseData(equpment, SlotType.BODY, armor).Returns(true).SetName("Armor");
        }

        [TestCaseSource(nameof(WhenAddThenEventOccursCases))]
        public (SlotType, object) WhenAddThenEventOccurs(
            Equipment<SlotType, object> equipment,
            SlotType type,
            object item
        )
        {
            //Arrange:
            SlotType eventSlot = default;
            object eventItem = default;

            equipment.OnAdded += (s, i) =>
            {
                eventSlot = s;
                eventItem = i;
            };

            //Act:
            equipment.Add(type, item);

            return (eventSlot, eventItem);
        }

        private static IEnumerable<TestCaseData> WhenAddThenEventOccursCases()
        {
            var sword = new object();
            var boots = new object();
            var helmet = new object();
            var armor = new object();

            var equpment = new Equipment<SlotType, object>(
                new KeyValuePair<SlotType, object>(SlotType.HANDS, sword),
                new KeyValuePair<SlotType, object>(SlotType.LEGS, boots)
            );

            yield return new TestCaseData(equpment, SlotType.HANDS, sword)
                .Returns(new ValueTuple<SlotType, object>(SlotType.HEAD, null))
                .SetName("Sword");

            yield return new TestCaseData(equpment, SlotType.LEGS, boots)
                .Returns(new ValueTuple<SlotType, object>(SlotType.HEAD, null))
                .SetName("Boots");

            yield return new TestCaseData(equpment, SlotType.HEAD, helmet)
                .Returns(new ValueTuple<SlotType, object>(SlotType.HEAD, helmet))
                .SetName("Helmet");


            yield return new TestCaseData(equpment, SlotType.BODY, armor)
                .Returns(new ValueTuple<SlotType, object>(SlotType.BODY, armor))
                .SetName("Armor");
        }
    }
}