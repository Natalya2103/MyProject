using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyWebApplication.Models
{
    public class ReportModel
    {
        [DisplayName("Количество папок")]
        public long FolderCount { get; set; }

        [DisplayName("Количество документов")]
        public long DocumentCount { get; set; }

        [DisplayName("Общий объем документов")]
        public long DocumentTotalSize { get; set; }
    }
}