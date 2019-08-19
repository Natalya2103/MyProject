using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class FolderAccess
    {
        public Folder Folder { get; set; }
        public string Permission { get; set; }
        public UserGroup UserGroup { get; set; }
        public User User { get; set; }
    }
}
