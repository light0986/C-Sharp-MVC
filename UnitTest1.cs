using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test3_1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            bool result = new test3.Class1().check(3, 500);
            Assert.IsTrue(result);
        }
    }
}
