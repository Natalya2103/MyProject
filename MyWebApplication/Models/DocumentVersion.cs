using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class DocumentVersion
    {
        public long Id { get; set; }
        public string File { get; set; }
        public User Author { get; set; }
        public DateTime CreateDate { get; set; }
        public Document Document {get; set;}
    }
}
