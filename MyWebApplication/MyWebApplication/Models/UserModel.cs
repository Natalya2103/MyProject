using ModelsDAL;
using MyWebApplication.Files;
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
        [DisplayName("Логин")]
        public  string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public  string Password { get; set; }

        [Required]
        [DisplayName("Полное имя")]
        public  string FIO { get; set; }

        [Required]
        [DisplayName("Группа")]
        public string UserGroup { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Возраст")]
        public int Age { get; set; }
        //public virtual byte[] Avatar { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Дата рождения")]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Upload)]
        [DisplayName("Фото")]
        public BinaryFileWrapper Avatar { get; set; }

        [DisplayName("Автор")]
        public User CreationAuthor { get; set; }
    }
}