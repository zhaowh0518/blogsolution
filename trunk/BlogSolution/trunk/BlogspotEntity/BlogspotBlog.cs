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
        /// The api address
        /// </summary>
        public string PostURL
        {
            get
            {
                return "http://www.blogger.com/feeds/4013265077745692418/posts/default";
            }
            set { }
        }
        /// <summary>
        /// The url for authenticate
        /// </summary>
        public string AuthURL
        {
            get
            {
                return "https://www.google.com/accounts/ClientLogin";
            }
        }
        /// <summary>
        /// Login in to the blog
        /// Before write blog,shoule login first
        /// if login failed it's result false.
        /// if you want to more detail info about failed reason,
        /// you can get from ExcptionMsg property.
        /// <param name="userName">user name</param>
        /// <param name="password">password</param>
        /// </summary>
        public bool Login(string userName, string password)
        {
            Auth = " DQAAAHcAAADojACKQ7aW-T78VrtIhuIrx3iHKGQxlqTFY8mROfCaQTd7R9L2htNfGi3e4fGb2IWLpWSPp5KKEQXgM3MPp0DuPNN_-y2F_3A4RHlqMDpbDMfcZdF0qhjP2qvSDakr_tfF9GWaomz9_R3cM1LdEZc47iSRSWUF5FrbeKVqtcC7DA";
            //Auth = GetAuthToken(userName, password);
            if (string.IsNullOrEmpty(Auth))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Get posts from xml files,if rss file does not exist,the method will result a empty IPost list 
        /// </summary>
        /// <returns></returns>
        public List<IPost> GetPosts()
        {
            throw new Exception("didn't implement in blogspot");
        }
        /// <summary>
        /// add a post to the blogspot
        /// </summary>
        /// <param name="post">post to be added</param>
        /// <returns></returns>
        public bool AddPost(IPost post)
        {
            try
            {
                if (string.IsNullOrEmpty(Auth))
                {
                    throw new Exception("Before add post to the blog,you should login first.please call login method.");
                }
                string xmlPost = BlogspotPost.ToXML(post);
                string result = string.Empty;
                result = AddPost(xmlPost);
                if (result.Contains("xml"))
                {
                    return true;
                }
                else
                {
                    ExceptionMsg = string.Format("Request failed.Detail: {0}", result);
                    return false;
                }
            }
            catch (Exception ex)
            {
                ExceptionMsg = ex.Message;
                return false;
            }
        }
        /// <summary>
        /// Delete post
        /// </summary>
        /// <param name="post">the post to be deleted</param>
        /// <returns></returns>
        public bool DetetePost(IPost post)
        {
            throw new Exception("didn't implement in blogspot");
        }
        #endregion

        /// <summary>
        /// The Temp authenticate token
        /// It can be got by GetAuthToken method
        /// </summary>
        public string Auth { get; set; }
        /// <summary>
        /// When called method in the class throw exception,
        /// the ex.Message will stroe here
        /// </summary>
        public string ExceptionMsg { get; set; }
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
            string result = WebAccess.Request(PostURL, xmlPost, "application/atom+xml", header);
            return result;
        }
        /// <summary>
        /// Get login token
        /// here is a default one:
        /// <param name="userName">user name</param>
        /// <param name="password">password</param>
        /// </summary>
        /// <returns></returns>
        public string GetAuthToken(string userName, string password)
        {
            try
            {
                string data = string.Format("Email={0}"
                    + "&Passwd={1}"
                    + "&service=blogger"
                    + "&accountType=GOOGLE"
                    + "&source=Disappearwind-BlogSolution-1", userName, password);
                string result = WebAccess.Request(AuthURL, data, "application/x-www-form-urlencoded");

                int index = result.IndexOf("Auth=");
                index = index + 5;

                return result.Substring(index, result.Length - index);
            }
            catch (Exception ex)
            {
                ExceptionMsg = ex.Message;
                return string.Empty;
            }
        }
    }
}
