/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind, disappearwind@gmail.com                            *
 * Created: 2009-4-15                                                       *
 *                                                                          *
 * Description:                                                             *
 *   Utility for tools.                                                     *
 *   read resouce from xaml file                                            *
 *   move blog                                                              *
 *                                                                          *
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml;
using System.Reflection;
using Disappearwind.BlogSolution.IBlog;

namespace Disappearwind.BlogSolution.BlogTools
{
    /// <summary>
    /// Utility of BlogTools
    /// </summary>
    public static class ToolsUtility
    {
        /// <summary>
        /// The blog list in bloglist.xaml
        /// </summary>
        public static List<BlogInfo> BlogList = new List<BlogInfo>();
        /// <summary>
        /// static constructor
        /// </summary>
        static ToolsUtility()
        {
            BlogList = GetBlogList();
        }
        /// <summary>
        /// Get resource from xmal file called BlogList.xaml
        /// </summary>
        /// <returns></returns>
        public static List<BlogInfo> GetBlogList()
        {
            List<BlogInfo> blogList = new List<BlogInfo>();
            string filePath = "Resource\\BlogList.xaml";
            //string filePath = "BlogList.xaml";
            //begin read text from xaml file
            XPathDocument doc = new XPathDocument(filePath);
            XPathNavigator nav = doc.CreateNavigator();
            XPathExpression expr = nav.Compile("//sys:String");
            XmlNamespaceManager nsManager = new XmlNamespaceManager(nav.NameTable);
            nsManager.AddNamespace("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            nsManager.AddNamespace("sys", "clr-namespace:System;assembly=mscorlib");
            expr.SetContext(nsManager);

            //Begin read
            XPathNodeIterator iterator = nav.Select(expr);
            while (iterator.MoveNext())
            {
                BlogInfo bi = new BlogInfo();
                bi.BlogName = iterator.Current.GetAttribute("Key", "http://schemas.microsoft.com/winfx/2006/xaml");
                bi.AssemblyName = iterator.Current.Value;
                blogList.Add(bi);
            }
            return blogList;
        }
        /// <summary>
        /// Get blog name list
        /// </summary>
        /// <returns></returns>
        public static List<string> GetBlogNameList()
        {
            List<string> nameList = new List<string>();
            foreach (var item in BlogList)
            {
                nameList.Add(item.BlogName);
            }
            return nameList;
        }
        /// <summary>
        /// Get assembly name belongs to blog
        /// </summary>
        /// <param name="blogName"></param>
        /// <returns></returns>
        public static string GetAssemblyName(string blogName)
        {
            var c = BlogList.Where(p => p.BlogName == blogName).Single();
            if (c != null)
            {
                return c.AssemblyName;
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Blog info
        /// </summary>
        public class BlogInfo
        {
            /// <summary>
            /// Name
            /// </summary>
            public string BlogName { get; set; }
            /// <summary>
            /// Assembly name
            /// </summary>
            public string AssemblyName { get; set; }
        }
        /// <summary>
        /// Move posts from one blog to another
        /// </summary>
        /// <param name="sourceBlog">source blog</param>
        /// <param name="url">source posts url</param>
        /// <param name="destinedBlog">destination blog</param>
        /// <returns></returns>
        public static int MovePost(string sourceBlog, string url, string destinedBlog)
        {
            int counter = 0;
            sourceBlog = GetAssemblyName(sourceBlog);
            destinedBlog = GetAssemblyName(destinedBlog);

            string[] sourceInfo = sourceBlog.Split(',');
            string[] destinedInfo = destinedBlog.Split(',');

            Assembly sourceBlogAssembly = Assembly.Load(sourceInfo[0]);
            Assembly destinedBlogAssembly = Assembly.Load(destinedInfo[0]);

            IBaseBlog sourceBlogEntity = (IBaseBlog)sourceBlogAssembly.CreateInstance(sourceInfo[1]);
            IBaseBlog destinedBlogEntity = (IBaseBlog)destinedBlogAssembly.CreateInstance(destinedInfo[1]);

            sourceBlogEntity.PostURL = url;
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
    }
}
