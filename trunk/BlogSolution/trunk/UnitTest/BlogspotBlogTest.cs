using Disappearwind.BlogSolution.BlogspotEntity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Disappearwind.BlogSolution.IBlog;
using System.Collections.Generic;

namespace Disappearwind.BlogSolution.UnitTest
{


    /// <summary>
    ///This is a test class for BlogspotBlogTest and is intended
    ///to contain all BlogspotBlogTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BlogspotBlogTest
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
        ///A test for AddPost
        ///</summary>
        [TestMethod()]
        public void AddPostTest()
        {
            BlogspotBlog target = new BlogspotBlog(); 
            BlogspotPost post = new BlogspotPost();
            post.Title = "test";
            post.Content = "test";
            List<string> categoryList = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                categoryList.Add(string.Format("category{0}", i));
            }
            //post.CategoryList = categoryList;
            string userName = "disappearwindtest@gmail.com";
            string password = "zhaowenhua";
            target.Auth = target.GetAuthToken(userName, password);
            target.PostURL = "http://www.blogger.com/feeds/4013265077745692418/posts/default";
            bool actual = target.AddPost(post);
            Assert.Inconclusive(target.ExceptionMsg);
            Assert.IsTrue(actual);
        }
    }
}
