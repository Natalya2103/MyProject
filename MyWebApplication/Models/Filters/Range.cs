using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDAL.Filters
{
    public struct Range<T>
        where T: struct
    {
        public T? From { get; set; }
        public T? To { get; set; }
    }
}
