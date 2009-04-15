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
        /// The url or address of blog posts
        /// </summary>
        public string PostURL { get; set; } 
        /// <summary>
        /// add a post to the blogspot
        /// </summary>
        /// <param name="post">post to be added</param>
        /// <returns></returns>
        public bool AddPost(IPost post)
        {
            string xmlPost = BlogspotPost.ToXML(post);
            string result = AddPost(xmlPost);
            if (result.Contains("xml"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// didtn't implement this method
        /// </summary>
        /// <returns></returns>
        public List<IPost> GetPosts()
        {
            throw new NotImplementedException("blogsport will not implement the GetPosts method!");
        }

        #endregion
        /// <summary>
        /// The Temp authenticate token
        /// It can be got by GetAuthToken method
        /// </summary>
        public string Auth { get; set; }
        /// <summary>
        /// The url relation post. for add post,update post or delete post
        /// </summary>
        public string BlogspotPostUrl = "http://www.blogger.com/feeds/4013265077745692418/posts/default";
        /// <summary>
        /// The url for authenticate
        /// </summary>
        public string AuthURL = "https://www.google.com/accounts/ClientLogin";
        /// <summary>
        /// Add post use xml.
        /// </summary>
        /// <param name="xmlPost">the xml format string which definition by blogspot</param>
        /// <returns></returns>
        public string AddPost(string xmlPost)
        {
            List<string> header = new List<string>();
            header.Add(string.Format("Authorization: GoogleLogin auth={0}", Auth));
            header.Add("GData-Version: 2");
            string result = WebAccess.Request(BlogspotPostUrl, xmlPost, "application/atom+xml", header);
            return result;
        }
        /// <summary>
        /// Get login token
        /// here is a default one:
        /// </summary>
        /// <returns></returns>
        public string GetAuthToken()
        {
            string data = "Email=disappearwindtest@gmail.com"
                + "&Passwd=zhaowenhua"
                + "&service=blogger"
                + "&accountType=GOOGLE"
                + "&source=Disappearwind-BlogSolution-1";
            string result = WebAccess.Request(AuthURL, data, "application/x-www-form-urlencoded");

            int index = result.IndexOf("Auth=");
            index = index + 5;

            return result.Substring(index, result.Length - index);
        }
        /// <summary>
        /// 
        /// </summary>
        public BlogspotBlog()
        {
            Auth = GetAuthToken();
        }
    }
}
