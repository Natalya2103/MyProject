﻿using ModelsDAL;
using MyWebApplication.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebApplication.Models
{
    public class UserGroupModel : EntityModel<UserGroup>
    {
        [Required]
        [GroupName]
        [DisplayName("Название группы")]
        public string GroupName { get; set; }
    }
}