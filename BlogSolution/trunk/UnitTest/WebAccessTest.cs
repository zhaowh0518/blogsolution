using Disappearwind.BlogSolution.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Disappearwind.BlogSolution.UnitTest
{

    /// <summary>
    ///This is a test class for WebAccessTest and is intended
    ///to contain all WebAccessTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WebAccessTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Request
        ///</summary>
        [TestMethod()]
        public void RequestTest()
        {
            string url = "http://www.blogger.com/feeds/blogID/posts/default"; // TODO: Initialize to an appropriate value
            string data = @"<entry xmlns='http://www.w3.org/2005/Atom'><title type='text'>Marriage!</title><content type='xhtml'><div>Disappearwind test!~</div></content></entry>";
            string expected = data;
            string actual;
            actual = WebAccess.Request(url, data);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Greate!Pass!");
        }
    }
}
