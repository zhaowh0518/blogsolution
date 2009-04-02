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
        /// Get posts from xml files
        /// </summary>
        /// <param name="xmlPost"></param>
        /// <returns></returns>
        public List<IPost> GetPosts(string xmlPost)
        {
            List<IPost> postList = new List<IPost>();
            YgPost p1 = new YgPost();
            postList.Add(p1);
            return postList;
        }

        #endregion
    }
}
