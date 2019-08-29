using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.Models
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("Имя пользователя")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}