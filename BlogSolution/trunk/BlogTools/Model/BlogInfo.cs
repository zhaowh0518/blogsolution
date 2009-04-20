/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind, disappearwind@gmail.com                            *
 * Created: 2009-4-17                                                       *
 *                                                                          *
 * Description:                                                             *
 *   Blog infomation,from config file                                       *
 *                                                                          *
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disappearwind.BlogSolution.BlogTools
{
    /// <summary>
    /// Blog info
    /// </summary>
    public class BlogInfo
    {
        /// <summary>
        /// Name
        /// </summary>
        public string BlogName { get; set; }
        /// <summary>
        /// Assembly name
        /// </summary>
        public string AssemblyName { get; set; }
        /// <summary>
        /// Type name namely full class name
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// Login user name
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Login password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Is readonly blog.when true,can't add post to the blog
        /// add don't need config username and password for the blog
        /// </summary>
        public bool IsReadOnly { get; set; }
        /// <summary>
        /// The service url to process posts
        /// </summary>
        public string PostURL { get; set; }
    }
}
