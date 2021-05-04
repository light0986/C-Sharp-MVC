using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace unitProject01
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double result1 = new project01.QEIOV().math1(1, -6, 8);
            double result2 = new project01.QEIOV().math2(1, -6, 8);
            Assert.IsTrue(result1 == 4);
            Assert.IsTrue(result2 == 2);
        }
    }
}
