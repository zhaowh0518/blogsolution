/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind, disappearwind@gmail.com                            *
 * Created: 2009-4-2                                                        *
 *                                                                          *
 * Description:                                                             *
 *   Definition the post of blogspot.                                       *
 *                                                                          *
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Disappearwind.BlogSolution.IBlog;

namespace Disappearwind.BlogSolution.BlogspotEntity
{
    public class BlogspotPost:IPost
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
        /// The category of post
        /// </summary>
        public List<string> CategoryList { get; set; }

        /// <summary>
        /// convet current BlogspotPost object to xml string
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>xml format string</returns>
        /* xml format:
         *  <entry xmlns='http://www.w3.org/2005/Atom'>
              <title type='text'>Marriage!</title>
              <content type='xhtml'>
                <div xmlns="http://www.w3.org/1999/xhtml">
                  <p>Mr. Darcy has <em>proposed marriage</em> to me!</p>
                  <p>He is the last man on earth I would ever desire to marry.</p>
                  <p>Whatever shall I do?</p>
                </div>
              </content>
              <category scheme="http://www.blogger.com/atom/ns#" term="marriage" />
              <category scheme="http://www.blogger.com/atom/ns#" term="Mr. Darcy" />
            </entry>
         */
        public string ToXML()
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement rootNode = xmlDoc.CreateElement("entry");
            rootNode.SetAttribute("xmlns", "http://www.w3.org/2005/Atom");
            xmlDoc.AppendChild(rootNode);

            XmlElement titleElement = xmlDoc.CreateElement("title");
            titleElement.SetAttribute("type", "text");
            titleElement.InnerText = Title;
            rootNode.AppendChild(titleElement);

            XmlElement contentElement = xmlDoc.CreateElement("content");
            contentElement.SetAttribute("type", "xhtml");
            contentElement.InnerText = FormatContent(Content);
            rootNode.AppendChild(contentElement);

            if (CategoryList != null)
            {
                foreach (var item in CategoryList)
                {
                    XmlElement categoryElement = xmlDoc.CreateElement("category");
                    categoryElement.SetAttribute("scheme", "http://www.blogger.com/atom/ns#");
                    categoryElement.SetAttribute("term", item);
                    rootNode.AppendChild(categoryElement);
                }
            }

            return xmlDoc.InnerXml;
        }
        /// <summary>
        /// Convet a IPost to xml use blogspot post format
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public static string ToXML(IPost post)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement rootNode = xmlDoc.CreateElement("entry");
            rootNode.SetAttribute("xmlns", "http://www.w3.org/2005/Atom");
            xmlDoc.AppendChild(rootNode);

            XmlElement titleElement = xmlDoc.CreateElement("title");
            titleElement.SetAttribute("type", "text");
            titleElement.InnerText = post.Title;
            rootNode.AppendChild(titleElement);

            XmlElement contentElement = xmlDoc.CreateElement("content");
            contentElement.SetAttribute("type", "xhtml");
            XmlElement detailElement = xmlDoc.CreateElement("div");
            detailElement.SetAttribute("xmlns", "http://www.w3.org/1999/xhtml");
            detailElement.InnerText = FormatContent(post.Content);
            contentElement.AppendChild(detailElement);

            rootNode.AppendChild(contentElement);


            return xmlDoc.InnerXml.Replace("&lt;", "<").Replace("&gt;", ">"); // < > replace
        }
        /// <summary>
        /// Format content to fit blogger's specified
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private static string FormatContent(string content)
        {
            content = content.Replace("<br>", "<p></p>").Replace("<BR>", "<p></p>"); //becareful this is very import,if don't do this,the api will return bad request error
            content = content.Replace("&nbsp;", " "); //unless do this,it will show &nbsp in blog page
            content = content.Replace("<div>", "<p>").Replace("<DIV>", "<P>");
            content = content.Replace("</div>", "</p>").Replace("</DIV>", "</P>");
            content = FilterTagAttribute(content, 0);
            return content;
        }
        /// <summary>
        /// Filter html tag attribute,use recursion
        /// </summary>
        /// <param name="content">html content</param>
        /// <param name="index">currentIndex should be 0</param>
        /// <returns></returns>
        private static string FilterTagAttribute(string content, int index)
        {
            if (index >= content.Length)
            {
                return content;
            }
            int leftAngularIndex = content.IndexOf("<", index);
            int blankIndex = content.IndexOf(" ", index);
            int rightAngularIndex = content.IndexOf(">", index);
            if (rightAngularIndex >= content.Length || rightAngularIndex <= leftAngularIndex || blankIndex <= 0)
            {
                return content;
            }
            else if (rightAngularIndex < blankIndex || leftAngularIndex > blankIndex)
            {
                return FilterTagAttribute(content, rightAngularIndex + 1);
            }
            else
            {
                string currentTag = content.Substring(leftAngularIndex, blankIndex - leftAngularIndex);
                string currentTagAll = content.Substring(leftAngularIndex, rightAngularIndex - leftAngularIndex);
                content = content.Replace(currentTagAll, currentTag);
                rightAngularIndex = content.IndexOf(">", index);
                return FilterTagAttribute(content, rightAngularIndex + 1);
            }
        }
    }
}
