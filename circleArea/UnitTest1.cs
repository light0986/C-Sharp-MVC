using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test3check
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double result = new test3.Class1().cirArea(10);
            Assert.IsTrue(result == 314);
        }
    }
}
