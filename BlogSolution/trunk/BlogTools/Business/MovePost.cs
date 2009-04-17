using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Disappearwind.BlogSolution.IBlog;

namespace Disappearwind.BlogSolution.BlogTools
{
    public class MovePost
    {
        /// <summary>
        /// Move posts from one blog to another
        /// </summary>
        /// <param name="sourceBlogName">source blog</param>
        /// <param name="url">source posts url</param>
        /// <param name="destinedBlogName">destination blog</param>
        /// <returns></returns>
        public int Move(string sourceBlogName, string url, string destinedBlogName)
        {
            int counter = 0;
            List<BlogInfo> blogList = ToolsUtility.GetBlogsList();
            BlogInfo sourceBlog = (BlogInfo)blogList.Single(p => p.BlogName == sourceBlogName);
            BlogInfo destinedBlog = (BlogInfo)blogList.Single(p => p.BlogName == destinedBlogName);

            Assembly sourceBlogAssembly = Assembly.Load(sourceBlog.AssemblyName);
            Assembly destinedBlogAssembly = Assembly.Load(destinedBlog.AssemblyName);

            IBaseBlog sourceBlogEntity = (IBaseBlog)sourceBlogAssembly.CreateInstance(sourceBlog.TypeName);
            IBaseBlog destinedBlogEntity = (IBaseBlog)destinedBlogAssembly.CreateInstance(destinedBlog.TypeName);

            sourceBlogEntity.PostURL = url;
            bool isLogin = destinedBlogEntity.Login(destinedBlog.UserName, destinedBlog.Password);
            if (isLogin)
            {
                List<IPost> postList = sourceBlogEntity.GetPosts();
                foreach (var item in postList)
                {
                    if (destinedBlogEntity.AddPost(item))
                    {
                        counter++;
                    }
                }
                return postList.Count - counter;
            }
            else
            {
                return -1;
            }
        }
    }
}
