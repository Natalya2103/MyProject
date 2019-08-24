using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDAL.Filters
{
    public class UserFilter: BaseFilter
    {
        public string Login { get; set; }
        public string FIO { get; set; }
        public string Email { get; set; }
        public Range<DateTime> CreationDate { get; set; }
        public Range<int> Age { get; set; }
        public IList<User> CreationAuthor { get; set; }
    }
}
