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
using System.Web;

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
            contentElement.InnerText = Content;
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
            detailElement.InnerText = post.Content;
            contentElement.AppendChild(detailElement);

            rootNode.AppendChild(contentElement);

            //return HttpUtility.HtmlDecode(xmlDoc.InnerXml);
            return xmlDoc.InnerXml.Replace("&lt;", "<").Replace("&gt;", ">");
        }        
    }
}
