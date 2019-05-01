using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MSTest.Tests
{
    [TestClass]
    public class MsTest
    {
        [TestMethod]
        public void MsTestPass()
        {
            bool does_this_work = true;
            Assert.IsTrue(does_this_work);
        }
    }
}
