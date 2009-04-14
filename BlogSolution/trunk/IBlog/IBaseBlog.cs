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
        /// Add a post to the blog
        /// </summary>
        /// <param name="post">the post to be added,it must implement IPost</param>
        void AddPost(IPost post);
        /// <summary>
        /// Get post from xml file
        /// </summary>
        /// <returns>posts list</returns>
        List<IPost> GetPosts();
    }
}
