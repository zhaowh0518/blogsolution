/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind, disappearwind@gmail.com                            *
 * Created: 2009-4-1                                                        *
 *                                                                          *
 * Description:                                                             *
 *   Definition interface for base blog.                                    *
 *                                                                          *
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disappearwind.BlogSolution.IBlog
{
    /// <summary>
    /// Base blog interface
    /// </summary>
    public interface IBaseBlog
    {
        /// <summary>
        /// Blog name,the type is string and it's readonly
        /// </summary>
        string BlogName { get;}
        /// <summary>
        /// Blog url,the url which the blog can access and it's readonly
        /// </summary>
        string URL { get; }
        /// <summary>
        /// Keyword assign to the blog
        /// </summary>
        string KeyWord { get; }
        /// <summary>
        /// The url or address of blog posts
        /// when it used in get posts from blog,it is a rss url or xml file of post
        /// and when it used in add post to blog it is the api of the blog support to manage blog
        /// </summary>
        string PostURL { get; set; }
        /// <summary>
        /// The url for authenticate user
        /// </summary>
        string AuthURL { get; }
        /// <summary>
        /// Login blog to operate blog
        /// </summary>
        /// <param name="userName">user name</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        bool Login(string userName, string password);
        /// <summary>
        /// Get all posts
        /// </summary>
        /// <returns>posts list</returns>
        List<IPost> GetPosts();
        /// <summary>
        /// Add a post to the blog
        /// </summary>
        /// <param name="post">the post to be added,it must implement IPost</param>
        /// <returns>result</returns>
        bool AddPost(IPost post);
        /// <summary>
        /// Delete post
        /// </summary>
        /// <param name="post">the post to be deleted</param>
        /// <returns></returns>
        bool DetetePost(IPost post);
    }
}
