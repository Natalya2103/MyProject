using Models;
using MyWebApplication.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebApplication.Models
{
    public class UserModel: EntityModel<User> { 

        [Compare("Password")]
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Подтверждение")]
        public string ConfirmPassword { get; set; }

        [Login]
        [Required]
        public  string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public  string Password { get; set; }

        [Required]
        [DisplayName("Полное имя")]
        public  string FIO { get; set; }

        [Required]
        [DisplayName("Группа")]
        public  string UserGroup { get; set; }
    }
}