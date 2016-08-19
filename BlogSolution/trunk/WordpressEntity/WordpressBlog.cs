/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind, disappearwind@gmail.com                            *
 * Created: 2016-8-16                                                       *
 *                                                                          *
 * Description:                                                             *
 *   Definition wordpress                                                   *
 *   ChineseName:阳光博客                                                   *
 *   BlogURL:https://langzi007.wordpress.com/                               *
 *                                                                          *
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Disappearwind.BlogSolution.IBlog;

namespace Disappearwind.BlogSolution.WordpressEntity
{
    /// <summary>
    /// wordpress
    /// </summary>
    public class WordpressBlog:IBaseBlog
    {
        public string BlogName
        {
            get { return "wordpress"; }
        }

        public string URL
        {
            get { return "https://langzi007.wordpress.com"; }
        }

        public string KeyWord
        {
            get { return "wordpress"; }
        }

        public string PostURL  { get; set; }

        public string AuthURL { get { return string.Empty; } }
        /// <summary>
        /// Post container
        /// </summary>
        public static List<IPost> PostList { get; set; }

        public bool Login(string userName, string password)
        {
            return true;
        }

        public List<IPost> GetPosts()
        {
            return PostList;
        }

        public bool AddPost(IPost post)
        {
            if (null == PostList)
            {
                PostList = new List<IPost>();
            }
            WordpressPost wpPost = new WordpressPost();
            wpPost.Title = post.Title;
            wpPost.Content = post.Content;
            wpPost.CreateDate = post.CreateDate;
            PostList.Add(wpPost);
            return true;
        }

        public bool DetetePost(IPost post)
        {
            throw new NotImplementedException();
        }
    }
}
