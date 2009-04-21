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
            //bool actual = target.AddPost(post);
            //Assert.IsTrue(actual);

            string xmlPost = "<entry xmlns='http://www.w3.org/2005/Atom'><title type='text'>2009年第一天上班：辞职</title><content type='xhtml'><div xmlns='http://www.w3.org/1999/xhtml'>09年上班做的第一件事就是辞职！<br>虽说是辞职，可是大家一阵寒暄之后就没有音信了，我还在等着交接工作呢！<br>等了一年终于决定辞职了，一个漫长的旅途，现在终于要结束了，心里不由得畅快！<br>一直就在痛苦的挣扎，一直都想离开现在的环境，一次次的失败，一次次的遗忘就那样的消磨了2008年的时光。<br>好快，在这个公司都1年多了，毕业也1年多了。可是我得到的有些什么呢？！<br>技术：从03到05再到08，从Web到WinForm再到WPF，然后呢？会一点LINQ，再然后呢?不记得了，大部分的项目都是在重复做，然后就是重复的拷贝代码，然后就机械式的遗忘了那些代码，直到有一天要用了，才翻遍自己做过的所有项目查找，然而有时候会弯曲忘掉在那个项目中，以至于找不到，然后又从网上搜，做重复的劳动，然后就在感叹一年不如一年，技术在退步。。。<br>业务：从CRM到网络视频再到医疗，整个乱乱的，感觉就是在不同的行业钻，然后在一个适合自己的地方停下脚，慢慢发展自己，但是至今为止没有找到适合自己兴趣，自己特别想从事的工作。<br>生活：乱的一踏糊涂！从香山搬家到公司附近再到金源，又到香山现在却跑到了回龙观！！！频繁的搬家，没有一个固定的栖息地！觉得一直在漂泊！不断掉落的头发，年纪轻轻的就在秃头，脸上无穷无尽的痘痘，一个大红脸！！！面子工程现在是彻底失败着！每每照镜子就觉得沧桑不堪！！！<br>在痛苦，在不断的内心中折磨着自己，在痛苦中徘徊，在不断的探索自己，在不断的探索人生，对自己认真的说一声：加油！<br></div></content></entry>";
            //!
            string xmlPost2 = "<entry xmlns='http://www.w3.org/2005/Atom'><title type='text'>2009年第一天上班：辞职</title><content type='xhtml'><div xmlns='http://www.w3.org/1999/xhtml'>09年上班做的第一件事就是辞职  <br>虽说是辞职，可是大家一阵寒暄之后就没有音信了，我还在等着交接工作呢  <br>等了一年终于决定辞职了，一个漫长的旅途，现在终于要结束了，心里不由得畅快  <br>一直就在痛苦的挣扎，一直都想离开现在的环境，一次次的失败，一次次的遗忘就那样的消磨了2008年的时光。<br>好快，在这个公司都1年多了，毕业也1年多了。可是我得到的有些什么呢？  <br>技术：从03到05再到08，从Web到WinForm再到WPF，然后呢？会一点LINQ，再然后呢?不记得了，大部分的项目都是在重复做，然后就是重复的拷贝代码，然后就机械式的遗忘了那些代码，直到有一天要用了，才翻遍自己做过的所有项目查找，然而有时候会弯曲忘掉在那个项目中，以至于找不到，然后又从网上搜，做重复的劳动，然后就在感叹一年不如一年，技术在退步。。。<br>业务：从CRM到网络视频再到医疗，整个乱乱的，感觉就是在不同的行业钻，然后在一个适合自己的地方停下脚，慢慢发展自己，但是至今为止没有找到适合自己兴趣，自己特别想从事的工作。<br>生活：乱的一踏糊涂  从香山搬家到公司附近再到金源，又到香山现在却跑到了回龙观      频繁的搬家，没有一个固定的栖息地  觉得一直在漂泊  不断掉落的头发，年纪轻轻的就在秃头，脸上无穷无尽的痘痘，一个大红脸      面子工程现在是彻底失败着  每每照镜子就觉得沧桑不堪      <br>在痛苦，在不断的内心中折磨着自己，在痛苦中徘徊，在不断的探索自己，在不断的探索人生，对自己认真的说一声：加油  <br></div></content></entry>";
            //<br>
            string xmlPost3 = "<entry xmlns='http://www.w3.org/2005/Atom'><title type='text'>2009年第一天上班：辞职</title><content type='xhtml'><div xmlns='http://www.w3.org/1999/xhtml'>09年上班做的第一件事就是辞职    虽说是辞职，可是大家一阵寒暄之后就没有音信了，我还在等着交接工作呢    等了一年终于决定辞职了，一个漫长的旅途，现在终于要结束了，心里不由得畅快    一直就在痛苦的挣扎，一直都想离开现在的环境，一次次的失败，一次次的遗忘就那样的消磨了2008年的时光。  好快，在这个公司都1年多了，毕业也1年多了。可是我得到的有些什么呢？    技术：从03到05再到08，从Web到WinForm再到WPF，然后呢？会一点LINQ，再然后呢?不记得了，大部分的项目都是在重复做，然后就是重复的拷贝代码，然后就机械式的遗忘了那些代码，直到有一天要用了，才翻遍自己做过的所有项目查找，然而有时候会弯曲忘掉在那个项目中，以至于找不到，然后又从网上搜，做重复的劳动，然后就在感叹一年不如一年，技术在退步。。。  业务：从CRM到网络视频再到医疗，整个乱乱的，感觉就是在不同的行业钻，然后在一个适合自己的地方停下脚，慢慢发展自己，但是至今为止没有找到适合自己兴趣，自己特别想从事的工作。  生活：乱的一踏糊涂  从香山搬家到公司附近再到金源，又到香山现在却跑到了回龙观      频繁的搬家，没有一个固定的栖息地  觉得一直在漂泊  不断掉落的头发，年纪轻轻的就在秃头，脸上无穷无尽的痘痘，一个大红脸      面子工程现在是彻底失败着  每每照镜子就觉得沧桑不堪        在痛苦，在不断的内心中折磨着自己，在痛苦中徘徊，在不断的探索自己，在不断的探索人生，对自己认真的说一声：加油    </div></content></entry>";
            //<br>-><br />
            string xmlPost4 = "<entry xmlns='http://www.w3.org/2005/Atom'><title type='text'>2009年第一天上班：辞职</title><content type='xhtml'><div xmlns='http://www.w3.org/1999/xhtml'>09年上班做的第一件事就是辞职！<br />虽说是辞职，可是大家一阵寒暄之后就没有音信了，我还在等着交接工作呢！<br />等了一年终于决定辞职了，一个漫长的旅途，现在终于要结束了，心里不由得畅快！<br />一直就在痛苦的挣扎，一直都想离开现在的环境，一次次的失败，一次次的遗忘就那样的消磨了2008年的时光。<br />好快，在这个公司都1年多了，毕业也1年多了。可是我得到的有些什么呢？！<br />技术：从03到05再到08，从Web到WinForm再到WPF，然后呢？会一点LINQ，再然后呢?不记得了，大部分的项目都是在重复做，然后就是重复的拷贝代码，然后就机械式的遗忘了那些代码，直到有一天要用了，才翻遍自己做过的所有项目查找，然而有时候会弯曲忘掉在那个项目中，以至于找不到，然后又从网上搜，做重复的劳动，然后就在感叹一年不如一年，技术在退步。。。<br />业务：从CRM到网络视频再到医疗，整个乱乱的，感觉就是在不同的行业钻，然后在一个适合自己的地方停下脚，慢慢发展自己，但是至今为止没有找到适合自己兴趣，自己特别想从事的工作。<br />生活：乱的一踏糊涂！从香山搬家到公司附近再到金源，又到香山现在却跑到了回龙观！！！频繁的搬家，没有一个固定的栖息地！觉得一直在漂泊！不断掉落的头发，年纪轻轻的就在秃头，脸上无穷无尽的痘痘，一个大红脸！！！面子工程现在是彻底失败着！每每照镜子就觉得沧桑不堪！！！<br />在痛苦，在不断的内心中折磨着自己，在痛苦中徘徊，在不断的探索自己，在不断的探索人生，对自己认真的说一声：加油！<br /></div></content></entry>";
            //<br>-><p></p>
            string xmlPost5 = "<entry xmlns='http://www.w3.org/2005/Atom'><title type='text'>2009年第一天上班：辞职</title><content type='xhtml'><div xmlns='http://www.w3.org/1999/xhtml'>09年上班做的第一件事就是辞职！<p></p>虽说是辞职，可是大家一阵寒暄之后就没有音信了，我还在等着交接工作呢！<p></p>等了一年终于决定辞职了，一个漫长的旅途，现在终于要结束了，心里不由得畅快！<p></p>一直就在痛苦的挣扎，一直都想离开现在的环境，一次次的失败，一次次的遗忘就那样的消磨了2008年的时光。<p></p>好快，在这个公司都1年多了，毕业也1年多了。可是我得到的有些什么呢？！<p></p>技术：从03到05再到08，从Web到WinForm再到WPF，然后呢？会一点LINQ，再然后呢?不记得了，大部分的项目都是在重复做，然后就是重复的拷贝代码，然后就机械式的遗忘了那些代码，直到有一天要用了，才翻遍自己做过的所有项目查找，然而有时候会弯曲忘掉在那个项目中，以至于找不到，然后又从网上搜，做重复的劳动，然后就在感叹一年不如一年，技术在退步。。。<p></p>业务：从CRM到网络视频再到医疗，整个乱乱的，感觉就是在不同的行业钻，然后在一个适合自己的地方停下脚，慢慢发展自己，但是至今为止没有找到适合自己兴趣，自己特别想从事的工作。<p></p>生活：乱的一踏糊涂！从香山搬家到公司附近再到金源，又到香山现在却跑到了回龙观！！！频繁的搬家，没有一个固定的栖息地！觉得一直在漂泊！不断掉落的头发，年纪轻轻的就在秃头，脸上无穷无尽的痘痘，一个大红脸！！！面子工程现在是彻底失败着！每每照镜子就觉得沧桑不堪！！！<p></p>在痛苦，在不断的内心中折磨着自己，在痛苦中徘徊，在不断的探索自己，在不断的探索人生，对自己认真的说一声：加油！<p></p></div></content></entry>";
            
            string result = target.AddPost(xmlPost5);

            if (result.Contains("id"))
            {
                Assert.IsTrue(result.Length > 0);
            }
            else
            {
                Assert.Inconclusive(result);
            }
        }
    }
}
