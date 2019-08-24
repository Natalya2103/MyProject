using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDAL.Filters

{
    public abstract class BaseFilter
    {
        public long? Id { get; set; } //может быть null
        public string SearchString { get; set; }
    }
}
