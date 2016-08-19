/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind, disappearwind@gmail.com                            *
 * Created: 2016-8-16                                                       *
 *                                                                          *
 * Description:                                                             *
 *   Definition the post of wordpress.                                      *
 *                                                                          *
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Disappearwind.BlogSolution.IBlog;
using System.Xml;

namespace Disappearwind.BlogSolution.WordpressEntity
{
    public class WordpressPost : IPost
    {
        #region IPost Members
        /// <summary>
        /// title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// content:encoded
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// pubDate
        /// </summary>
        public DateTime CreateDate { get; set; }
        #endregion

        /// <summary>
        /// Convet a IPost to xml use wordpress post format
        /// </summary>
        /// <returns></returns>
        public string ToXML()
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement rootNode = xmlDoc.CreateElement("item");
            xmlDoc.AppendChild(rootNode);

            XmlElement titleElement = xmlDoc.CreateElement("title");
            titleElement.InnerText = Title;
            rootNode.AppendChild(titleElement);

            XmlElement dateElement = xmlDoc.CreateElement("pubDate");
            dateElement.InnerText = string.Format("{0:R}", CreateDate).Replace("GMT", "+0000");
            rootNode.AppendChild(dateElement);

            XmlElement contentElement = xmlDoc.CreateElement("content", "encoded", " ");
            XmlNode contentNode = xmlDoc.CreateCDataSection(Content);
            contentElement.AppendChild(contentNode);
            rootNode.AppendChild(contentElement);

            //2016-08-1 12:10:48
            XmlElement postDateElement = xmlDoc.CreateElement("wp", "post_date", " ");
            postDateElement.InnerText = CreateDate.ToString("yyyy-MM-dd HH:mm:ss");
            rootNode.AppendChild(postDateElement);

            XmlElement postNameElement = xmlDoc.CreateElement("wp", "post_name", " ");
            postNameElement.InnerText = Title;
            rootNode.AppendChild(postNameElement);

            XmlElement statusElement = xmlDoc.CreateElement("wp", "status", " ");
            statusElement.InnerText = "publish";
            rootNode.AppendChild(statusElement);

            XmlElement parentElement = xmlDoc.CreateElement("wp", "post_parent", " ");
            parentElement.InnerText = "0";
            rootNode.AppendChild(parentElement);

            XmlElement typeElement = xmlDoc.CreateElement("wp", "post_type", " ");
            typeElement.InnerText = "post";
            rootNode.AppendChild(typeElement);

            XmlElement categoryElement = xmlDoc.CreateElement("category");
            categoryElement.SetAttribute("domain", "category");
            categoryElement.SetAttribute("nicename", "%e7%94%9f%e6%b4%bb"); //urlencode("生活")
            XmlNode categoryNode = xmlDoc.CreateCDataSection("生活");
            categoryElement.AppendChild(categoryNode);
            rootNode.AppendChild(categoryElement);

            string result = xmlDoc.InnerXml;
            result = result.Replace(" xmlns:content=\" \"", string.Empty).Replace(" xmlns:wp=\" \"", string.Empty);
            return result;
        }
    }
}
