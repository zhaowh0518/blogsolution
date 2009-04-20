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
        public MoveResult Move(string sourceBlogName, string url, string destinedBlogName)
        {
            MoveResult moveResult = new MoveResult();
            List<BlogInfo> blogList = ToolsUtility.GetBlogsList();
            BlogInfo sourceBlog = (BlogInfo)blogList.Single(p => p.BlogName == sourceBlogName);
            BlogInfo destinedBlog = (BlogInfo)blogList.Single(p => p.BlogName == destinedBlogName);

            Assembly sourceBlogAssembly = Assembly.Load(sourceBlog.AssemblyName);
            Assembly destinedBlogAssembly = Assembly.Load(destinedBlog.AssemblyName);

            IBaseBlog sourceBlogEntity = (IBaseBlog)sourceBlogAssembly.CreateInstance(sourceBlog.TypeName);
            IBaseBlog destinedBlogEntity = (IBaseBlog)destinedBlogAssembly.CreateInstance(destinedBlog.TypeName);

            sourceBlogEntity.PostURL = url;
            destinedBlogEntity.PostURL = destinedBlog.PostURL;
            bool isLogin = destinedBlogEntity.Login(destinedBlog.UserName, destinedBlog.Password);
            if (isLogin)
            {
                List<IPost> postList = sourceBlogEntity.GetPosts();
                moveResult.TotalCount = postList.Count;
                foreach (var item in postList)
                {
                    if (!destinedBlogEntity.AddPost(item))
                    {
                        moveResult.FailedList.Add(item.Title);
                    }
                    System.Threading.Thread.Sleep(1000);
                }
                moveResult.FailedCount = moveResult.FailedList.Count;
            }
            return moveResult;
        }
        /// <summary>
        /// A structure to record move result
        /// </summary>
        public class MoveResult
        {
            /// <summary>
            /// Total count of post to be moved
            /// </summary>
            public int TotalCount { get; set; }
            /// <summary>
            /// Moved failed posts count
            /// </summary>
            public int FailedCount { get; set; }
            /// <summary>
            /// Failed posts list
            /// </summary>
            public List<string> FailedList { get; set; }
            /// <summary>
            /// Default constructor
            /// </summary>
            public MoveResult()
            {
                FailedList = new List<string>();
            }
        }
    }
}
