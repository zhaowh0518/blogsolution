/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind, disappearwind@gmail.com                            *
 * Created: 2009-4-2                                                        *
 *                                                                          *
 * Description:                                                             *
 *   Definition blogspot.                                                   *
 *   blogspot belong to blogger                                             *
 *   BlogURL:http://disappearwind.blogspot.com/                             *
 *                                                                          *
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Disappearwind.BlogSolution.IBlog;
using Disappearwind.BlogSolution.Utility;

namespace Disappearwind.BlogSolution.BlogspotEntity
{
    public class BlogspotBlog : IBaseBlog
    {
        #region IBaseBlog Members
        /// <summary>
        /// blogspot
        /// </summary>
        public string BlogName
        {
            get { return "blogspot"; }
        }
        /// <summary>
        /// http://disappearwind.blogspot.com/
        /// </summary>
        public string URL
        {
            get { return "http://disappearwind.blogspot.com/"; }
        }
        /// <summary>
        /// blogspot
        /// </summary>
        public string KeyWord
        {
            get { return "blogspot"; }
        }
        /// <summary>
        /// add a post to the blogspot
        /// </summary>
        /// <param name="post"></param>
        public void AddPost(IPost post)
        {
            BlogspotPost bsPost = (BlogspotPost)post;
            AddPost(bsPost.ToXML());
        }

        public List<IPost> GetPosts()
        {
            throw new NotImplementedException("blogsport will not implement the GetPosts method!");
        }

        #endregion
        /// <summary>
        /// The url for call blog's url
        /// </summary>
        public string RPCURL { get { return "http://plant.blogger.com/api/RPC2"; } }
        /// <summary>
        /// Add post use xml.
        /// </summary>
        /// <param name="xmlPost">the xml format string which definition by blogspot</param>
        /// <returns></returns>
        public bool AddPost(string xmlPost)
        {
            string result = WebAccess.Request(RPCURL, xmlPost);
            return true;
        }
    }
}
