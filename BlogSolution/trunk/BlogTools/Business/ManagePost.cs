using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Disappearwind.BlogSolution.IBlog;
using System.Reflection;

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
        public bool AddPost(string blogName, string title, string content)
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
                pi.CreateDate = DateTime.Now;
                return currentBlogEntity.AddPost(pi);
            }
            else
            {
                return false;
            }
        }

        public class PostInfo : IPost
        {
            #region IPost Members

            public string Title { get; set; }

            public string Content { get; set; }

            public DateTime CreateDate { get; set; }

            public System.Xml.XmlDocument ToXML()
            {
                throw new NotImplementedException();
            }

            #endregion
        }
    }
}
