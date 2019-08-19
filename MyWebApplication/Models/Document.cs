using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Document : Folder
    {
        public string DocumentType { get; set; }
        public DateTime CreateDate { get; set; }
        public User Author { get; set; }
    }
}
