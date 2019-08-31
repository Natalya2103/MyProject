using ModelsDAL;
using MyWebApplication.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebApplication.Models
{
    public class DocumentModel : EntityModel<Document>
    {
        [Required]
        [DisplayName("Название документа")]
        public virtual string DocumentName { get; set; }

        public virtual long? ParentFolderId { get; set; }

        [DataType(DataType.Upload)]
        [DisplayName("Документ")]
        public BinaryFileWrapper Data { get; set; }
    }
}