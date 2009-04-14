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
        /// Request a url with data and return the url's response
        /// </summary>
        /// <param name="url">The request url</param>
        /// <param name="data">Request data</param>
        /// <returns></returns>
        public static string Request(string url, string data)
        {
            try
            {
                string result = string.Empty;
                //request
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                byte[] requestBytes = System.Text.Encoding.UTF8.GetBytes(data); //UTF8 for chinese
                req.Method = "POST";
                //req.ContentType = "application/x-www-form-urlencoded";
                req.ContentType = "application/atom+xml";
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
    }
}
