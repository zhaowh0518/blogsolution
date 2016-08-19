using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Disappearwind.BlogSolution.IBlog;
using System.Reflection;
using System.IO;

namespace Disappearwind.BlogSolution.BlogTools
{
    public class ManagePost
    {
        /// <summary>
        /// Add post to a blog
        /// </summary>
        /// <param name="blogName">Blog to add post</param>
        /// <param name="title">blog title</param>
        /// <param name="content">blog content</param>
        /// <returns></returns>
        public bool AddPost(string blogName, string title, string content,string createdate)
        {
            List<BlogInfo> blogList = ToolsUtility.GetBlogsList();
            BlogInfo currentBlog = (BlogInfo)blogList.Single(p => p.BlogName == blogName);
            Assembly currentBlogAssembly = Assembly.Load(currentBlog.AssemblyName);
            IBaseBlog currentBlogEntity = (IBaseBlog)currentBlogAssembly.CreateInstance(currentBlog.TypeName);
            bool isLogin = currentBlogEntity.Login(currentBlog.UserName, currentBlog.Password);
            if (isLogin)
            {
                PostInfo pi = new PostInfo();
                pi.Title = title;
                pi.Content = content;
                if(string.IsNullOrEmpty(createdate))
                {
                    pi.CreateDate = DateTime.Now;
                }
                else
                {
                    pi.CreateDate = DateTime.Parse(createdate);
                }
                return currentBlogEntity.AddPost(pi);
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Generate XML file
        /// </summary>
        /// <param name="blogName"></param>
        public bool toXML(string blogName)
        {
            List<BlogInfo> blogList = ToolsUtility.GetBlogsList();
            BlogInfo currentBlog = (BlogInfo)blogList.Single(p => p.BlogName == blogName);
            Assembly currentBlogAssembly = Assembly.Load(currentBlog.AssemblyName);
            IBaseBlog currentBlogEntity = (IBaseBlog)currentBlogAssembly.CreateInstance(currentBlog.TypeName);

            List<IPost> postList = currentBlogEntity.GetPosts();
            string xml = string.Empty;
            foreach (var item in postList)
            {
                xml += item.ToXML();
            }

            string resultFileName = "result.xml";
            string templateName = blogName + ".xml";
            string result = File.ReadAllText(templateName);
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Replace("[ItemList]", xml);
                File.WriteAllText(resultFileName, result);
                return true;
            }
            return false;
        }

        public class PostInfo : IPost
        {
            #region IPost Members

            public string Title { get; set; }

            public string Content { get; set; }

            public DateTime CreateDate { get; set; }

            public string ToXML()
            {
                throw new NotImplementedException();
            }

            #endregion
        }
    }
}
