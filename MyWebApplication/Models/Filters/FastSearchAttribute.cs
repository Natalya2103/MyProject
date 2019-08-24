using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDAL.Filters
{
    public class FastSearchAttribute : Attribute
    {
        public FieldType FieldType { get; set; }
    }

    public enum FieldType
    {
        String,
        Int
    }
}