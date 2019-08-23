using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApplication.Models
{
    public class EntityModel<T>
    {
        public T Entity { get; set; }
    }
}