/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind, disappearwind@gmail.com                            *
 * Created: 2009-4-1                                                        *
 *                                                                          *
 * Description:                                                             *
 *   Definition the post of ygblog.                                         *
 *                                                                          *
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Disappearwind.BlogSolution.IBlog;

namespace Disappearwind.BlogSolution.YgBlogEntity
{
    public class YgPost:IPost
    {
        #region IPost Members
        /// <summary>
        /// title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// createdate(publishdate)
        /// </summary>
        public DateTime CreateDate { get; set; }
        #endregion
        /// <summary>
        /// Default constructor,do nothing
        /// </summary>
        public YgPost()
        {

        }
        /// <summary>
        /// Arguments constructor
        /// </summary>
        /// <param name="title">title</param>
        /// <param name="content">content</param>
        /// <param name="createDate">create date type of datetime</param>
        public YgPost(string title, string content, DateTime createDate)
        {
            Title = title;
            Content = content;
            CreateDate = createDate;
        }
    }
}
