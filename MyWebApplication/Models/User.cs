using System;

namespace Models
{
    public class User
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserGroup Group { get; set; }
    }
}
