using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Disappearwind.BlogSolution.IBlog;
using System.IO;

namespace Disappearwind.BlogSolution.BlogTools
{
    public class ConvertPost
    {
        /// <summary>
        /// Convert posts from one blog to another
        /// </summary>
        /// <param name="sourceBlogName">source blog</param>
        /// <param name="destinedBlogName">destination blog</param>
        /// <param name="path">file path</param>
        /// <returns></returns>
        public void Convert(string sourceBlogName, string destinedBlogName, string path)
        {
            List<BlogInfo> blogList = ToolsUtility.GetBlogsList();
            BlogInfo sourceBlog = (BlogInfo)blogList.Single(p => p.BlogName == sourceBlogName);
            BlogInfo destinedBlog = (BlogInfo)blogList.Single(p => p.BlogName == destinedBlogName);

            Assembly sourceBlogAssembly = Assembly.Load(sourceBlog.AssemblyName);
            Assembly destinedBlogAssembly = Assembly.Load(destinedBlog.AssemblyName);

            IBaseBlog sourceBlogEntity = (IBaseBlog)sourceBlogAssembly.CreateInstance(sourceBlog.TypeName);
            IBaseBlog destinedBlogEntity = (IBaseBlog)destinedBlogAssembly.CreateInstance(destinedBlog.TypeName);

            string[] files = Directory.GetFiles(path, "*.xml");
            if (files.Length > 0)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    sourceBlogEntity.PostURL = files[i];
                    List<IPost> sourcePostList = sourceBlogEntity.GetPosts();
                    foreach (var item in sourcePostList)
                    {
                        destinedBlogEntity.AddPost(item);
                    }
                }
                List<IPost> destPostList = destinedBlogEntity.GetPosts();
                string xml = string.Empty;
                foreach (var item in destPostList)
                {
                    xml += item.ToXML().InnerXml;
                }

                string resultFileName = Path.Combine(path, "result.xml");
                string templateName = destinedBlogName + ".xml";
                string result = File.ReadAllText(templateName);
                if (!string.IsNullOrEmpty(result))
                {
                    result = result.Replace("[ItemList]",xml);
                    File.WriteAllText(resultFileName, result);
                }               
            }
        }
    }
}
