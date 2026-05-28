using NUnit.Framework;

namespace Atomic.Elements
{
    [TestFixture]
    public sealed class CompositeActionTests
    {
        [Test]
        public void CreateAndInvoke()
        {
            //Arrange:
            var a1 = new ActionSpy();
            var a2 = new ActionSpy();
            var a3 = new ActionSpy();
            var a4 = new ActionSpy();
            
            IAction actionGroup = new CompositeAction(a1, a2, a3, a4);
            
            //Act:
            actionGroup.Invoke();
            
            //Assert:
            Assert.IsTrue(a1.WasInvoked);
            Assert.IsTrue(a2.WasInvoked);
            Assert.IsTrue(a3.WasInvoked);
            Assert.IsTrue(a4.WasInvoked);
        }
    }
}