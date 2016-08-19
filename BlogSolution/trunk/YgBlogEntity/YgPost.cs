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
    public class YgPost : IPost
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
            Content = FormatYgPost(content);
            CreateDate = createDate;
        }
        /// <summary>
        /// Filter some special html tag in ygblog's post
        /// </summary>
        /// <param name="content">html tag</param>
        /// <returns></returns>
        private string FormatYgPost(string content)
        {
            content = content.Replace("<o:p>", "<p>").Replace("</o:p>", "</p>");
            string specialXmlTag = "<?xml:namespace";
            int stargIndex = content.IndexOf(specialXmlTag);
            if (stargIndex >= 0)
            {
                int endIndex = content.IndexOf(">", stargIndex);
                specialXmlTag = content.Substring(stargIndex, endIndex - stargIndex) + ">";
                content = content.Replace(specialXmlTag, "");
            }
            return content;
        }


        public string ToXML()
        {
            throw new NotImplementedException();
        }
    }
}
