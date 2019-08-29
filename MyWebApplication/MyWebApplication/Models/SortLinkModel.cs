using ModelsDAL.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MyWebApplication.Models
{
    public class SortLinkModel
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public SortDirection? SortDirection {get; set;}
        public RouteValueDictionary RouteValues { get; set; }
        public string LinkText { get; set; }
    }
}