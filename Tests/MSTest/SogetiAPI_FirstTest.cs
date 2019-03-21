using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MSTest.Tests
{
    [TestClass]
    public class SogetiAPI_FirstTest
    {
        [TestMethod]
        public void FirstTest_PassTest()
        {
            bool does_this_work = true;
            Assert.IsTrue(does_this_work);
        }

        [TestMethod]
        public void SecondTest_FailTest()
        {
            bool does_this_work = false;
            Assert.IsTrue(does_this_work);
        }
    }
}
