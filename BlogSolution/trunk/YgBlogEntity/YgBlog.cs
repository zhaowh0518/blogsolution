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
        /// Add a post to ygblog
        /// </summary>
        /// <param name="post"></param>
        public void AddPost(IPost post)
        {
            throw new NotImplementedException("The ygbog will not implement AddPostMethod");
        }
        /// <summary>
        /// Get posts from xml files,if rss file does not exist,the method will result a empty IPost list 
        /// </summary>
        /// <returns></returns>
        public List<IPost> GetPosts()
        {
            List<IPost> postList = new List<IPost>();
            //if rss file exist,get posts from rss file
            if (System.IO.File.Exists(RssFilePath))
            {
                XDocument xDoc = XDocument.Load(RssFilePath);
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

        #endregion
        /// <summary>
        /// The path of rss file
        /// </summary>
        public string RssFilePath { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        public YgBlog()
        {
            RssFilePath = "rss.xml";
        }
    }
}
