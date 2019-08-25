using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDAL.Filters
{
    public class FolderFilter : BaseFilter
    {
        public string FolderName { get; set; }

        public long? ParentFolderId { get; set; }
    }
}
