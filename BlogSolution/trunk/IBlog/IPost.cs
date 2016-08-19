/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind, disappearwind@gmail.com                            *
 * Created: 2009-4-1                                                        *
 *                                                                          *
 * Description:                                                             *
 *   Definition interface for base post.                                    *
 *                                                                          *
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Disappearwind.BlogSolution.IBlog
{
    /// <summary>
    /// post interface
    /// </summary>
    public interface IPost
    {
        /// <summary>
        /// Post title
        /// </summary>
        string Title { get; set; }
        /// <summary>
        /// Post content
        /// </summary>
        string Content { get; set; }
        /// <summary>
        /// Post createdate,maybe didn't today,it was the actual created day.
        /// </summary>
        DateTime CreateDate { get; set; }
        /// <summary>
        /// To xml format
        /// </summary>
        /// <returns></returns>
        string ToXML();
    }
}
