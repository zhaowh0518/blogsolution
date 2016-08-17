using Disappearwind.BlogSolution.BlogspotEntity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace Disappearwind.BlogSolution.UnitTest
{
    
    
    /// <summary>
    ///This is a test class for BlogspotPostTest and is intended
    ///to contain all BlogspotPostTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BlogspotPostTest
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
        ///A test for ToXML
        ///</summary>
        [TestMethod()]
        public void ToXMLTest()
        {
            BlogspotPost target = new BlogspotPost();
            target.Title = "test";
            target.Content = "<div>this is post content</div>";
            List<string> categoryList = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                categoryList.Add(string.Format("category{0}", i));
            }
            target.CategoryList = categoryList;
            string result = target.ToXML().InnerXml;
            Assert.IsTrue(result.Length > 0);
        }
    }
}
