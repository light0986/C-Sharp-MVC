using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace unitProject01
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double[] result = new double[2];
            result = new project01.QEIOV().Math1(1, -6, 8);
            Assert.IsTrue(result[0] == 4 & result[1] ==2 );
        }
    }
}
