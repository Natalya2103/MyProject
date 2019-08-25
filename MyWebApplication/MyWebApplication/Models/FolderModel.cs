using ModelsDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebApplication.Models
{
    public class FolderModel : EntityModel<Folder>
    {
        [Required]
        [DisplayName("Название папки")]
        public virtual string FolderName { get; set; }

        [DisplayName("Путь")]
        public virtual Folder ParentFolder { get; set; }
    }
}