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
        [DisplayName("Путь")]
        public string FolderParentPath { get; set; }
    }
}