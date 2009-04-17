using Disappearwind.BlogSolution.BlogTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Disappearwind.BlogSolution.UnitTest
{
    
    
    /// <summary>
    ///This is a test class for ToolsUtilityTest and is intended
    ///to contain all ToolsUtilityTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ToolsUtilityTest
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
        ///A test for MovePost
        ///</summary>
        [TestMethod()]
        public void MovePostTest()
        {
            string sourceBlog = "YbBlog"; 
            string url = @"d:\rss.xml"; 
            string destinedBlog = "Blogspot";
            MovePost mp = new MovePost();
            int result = mp.Move(sourceBlog, url, destinedBlog);
            Assert.IsTrue(result > 0);
        }

        /// <summary>
        ///A test for GetBlogsList
        ///</summary>
        [TestMethod()]
        public void GetBlogsListTest()
        {
            List<BlogInfo> actual;
            actual = ToolsUtility.GetBlogsList();
            Assert.IsTrue(actual.Count == 2);
        }
    }
}
