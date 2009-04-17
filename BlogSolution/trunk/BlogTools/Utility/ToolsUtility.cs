/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind, disappearwind@gmail.com                            *
 * Created: 2009-4-15                                                       *
 *                                                                          *
 * Description:                                                             *
 *   Utility for tools.                                                     *
 *   read resouce from xaml file                                            *
 *   move blog                                                              *
 *                                                                          *
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml;
using System.Reflection;
using Disappearwind.BlogSolution.IBlog;
using System.Windows;

namespace Disappearwind.BlogSolution.BlogTools
{
    /// <summary>
    /// Utility of BlogTools
    /// </summary>
    public static class ToolsUtility
    {
        /// <summary>
        /// The bloglist.xaml file path
        /// </summary>
        public static string BlogListFilePath = "Resource\\BlogList.xaml";
        /// <summary>
        /// Get resource from xmal file called BlogList.xaml
        /// </summary>
        /// <returns></returns>
        public static List<BlogInfo> GetBlogsList()
        {
            List<BlogInfo> blogList = new List<BlogInfo>();
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri(BlogListFilePath, UriKind.RelativeOrAbsolute);
            foreach (var key in rd.Keys)
            {
                BlogInfo bi = rd[key] as BlogInfo;
                blogList.Add(bi);
            }
            return blogList;

        }
    }
}
