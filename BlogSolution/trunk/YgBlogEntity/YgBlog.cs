/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind, disappearwind@gmail.com                            *
 * Created: 2009-4-1                                                        *
 *                                                                          *
 * Description:                                                             *
 *   Definition ygblog.                                                     *
 *   ChineseName:阳光博客                                                   *
 *   BlogURL:http://disappearwind.ygblog.com                                *
 *                                                                          *
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Disappearwind.BlogSolution.IBlog;
using System.Xml.Linq;

namespace Disappearwind.BlogSolution.YgBlogEntity
{
    /// <summary>
    /// yblog
    /// </summary>
    public class YgBlog : IBaseBlog
    {
        #region IBaseBlog Members
        /// <summary>
        /// ygblog
        /// </summary>
        public string BlogName
        {
            get { return "ygblog"; }
        }
        /// <summary>
        /// http://disappearwind.ygblog.com
        /// </summary>
        public string URL
        {
            get { return "http://disappearwind.ygblog.com"; }
        }
        /// <summary>
        /// yg
        /// </summary>
        public string KeyWord
        {
            get { return "ygblog"; }
        }
        /// <summary>
        /// The url or address of blog posts
        /// default is the rss.xml file in application directory
        /// </summary>
        public string PostURL { get; set; }
        /// <summary>
        /// The url for authenticate user,don't publish to client
        /// </summary>
        public string AuthURL { get { return string.Empty; } }
        /// <summary>
        /// Login blog to operate blog
        /// </summary>
        /// <param name="userName">user name</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        public bool Login(string userName, string password)
        {
            throw new Exception("didn't implement in ygblog");
        }
        /// <summary>
        /// Get posts from xml files,if rss file does not exist,the method will result a empty IPost list 
        /// </summary>
        /// <returns></returns>
        public List<IPost> GetPosts()
        {
            List<IPost> postList = new List<IPost>();
            //if rss file exist,get posts from rss file
            if (System.IO.File.Exists(PostURL))
            {
                XDocument xDoc = XDocument.Load(PostURL);
                var c = from p in xDoc.Descendants("item")
                        select new
                        {
                            Title = p.Element("title").Value,
                            Content = p.Element("description").Value,
                            CreateDate = p.Element("PubDate").Value
                        };
                DateTime createDate = DateTime.Now;
                foreach (var item in c)
                {
                    createDate = DateTime.Now;
                    if (!string.IsNullOrEmpty(item.CreateDate))
                    {
                        createDate = Convert.ToDateTime(item.CreateDate);
                    }
                    postList.Add(new YgPost(item.Title, item.Content, createDate));
                }
            }
            return postList;
        }
        /// <summary>
        /// Add a post to the blog
        /// </summary>
        /// <param name="post">the post to be added,it must implement IPost</param>
        /// <returns>result</returns>
        public bool AddPost(IPost post)
        {
            throw new Exception("didn't implement in ygblog");
        }
        /// <summary>
        /// Delete post
        /// </summary>
        /// <param name="post">the post to be deleted</param>
        /// <returns></returns>
        public bool DetetePost(IPost post)
        {
            throw new Exception("didn't implement in ygblog");
        }
        #endregion
        /// <summary>
        /// Default constructor
        /// </summary>
        public YgBlog()
        {
            PostURL = "rss.xml";
        }
    }
}
