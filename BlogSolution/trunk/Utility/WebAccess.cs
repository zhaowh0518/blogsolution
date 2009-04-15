/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind, disappearwind@gmail.com                            *
 * Created: 2009-4-2                                                        *
 *                                                                          *
 * Description:                                                             *
 *   Access web                                                             *
 *                                                                          *
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Disappearwind.BlogSolution.Utility
{
    /// <summary>
    /// Access web
    /// </summary>
    public class WebAccess
    {
        /// <summary>
        /// Requst a url with data use post method and no private header
        /// </summary>
        /// <param name="url">The request url</param>
        /// <param name="data">Request data</param>
        /// <param name="contentType">content type</param>
        /// <returns></returns>
        public static string Request(string url, string data, string contentType)
        {
            return Request(url, data, WebAccessMethod.POST, contentType, null);
        }
        /// <summary>
        /// Requst a url with data use post method
        /// </summary>
        /// <param name="url">The request url</param>
        /// <param name="data">Request data</param>
        /// <param name="contentType">content type</param>
        /// <param name="header">The header of httprequest.usually for authenticate</param>
        /// <returns></returns>
        public static string Request(string url, string data, string contentType,List<string> header)
        {
            return Request(url, data, WebAccessMethod.POST, contentType, header);
        }
        /// <summary>
        /// Request a url with data and return the url's response
        /// </summary>
        /// <param name="url">The request url</param>
        /// <param name="data">Request data</param>
        /// <param name="method">Request method,default is POST</param>
        /// <param name="contentType">content type</param>
        /// <param name="header">The header of httprequest.usually for authenticate</param>
        /// <returns></returns>
        public static string Request(string url, string data,WebAccessMethod? method,string contentType,List<string> header)
        {
            try
            {
                if (method == null)
                {
                    method = WebAccessMethod.POST;
                }
                string result = string.Empty;
                //request
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                if (header != null)
                {
                    foreach (var item in header)
                    {
                        req.Headers.Add(item);
                    }
                }
                byte[] requestBytes = System.Text.Encoding.UTF8.GetBytes(data); //UTF8 for chinese
                req.Method = method.ToString();
                req.ContentType = contentType;
                req.ContentLength = requestBytes.Length;
                Stream requestStream = req.GetRequestStream();
                requestStream.Write(requestBytes, 0, requestBytes.Length);
                requestStream.Close();
                //get response
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.UTF8);
                result = sr.ReadToEnd();
                sr.Close();
                res.Close();

                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// HttpWebRequest method enum
        /// </summary>
        public enum WebAccessMethod
        {
            POST,
            GET
        }
    }
}
