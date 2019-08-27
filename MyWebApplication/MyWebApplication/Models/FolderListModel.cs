using ModelsDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyWebApplication.Models
{
    public class FolderListModel : EntityListModel<Folder>
    {
        public bool IsRootFolder { get; set; }

        public Folder FolderParent { get; set; }

        public Folder CurrentFolder { get; set; }
    }
}