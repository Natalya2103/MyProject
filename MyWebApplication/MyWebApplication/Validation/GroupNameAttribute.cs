using ModelsDAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApplication.Validation
{
    public class GroupNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var groupName = value.ToString();
            var userGroupRepository = DependencyResolver.Current.GetService<UserGroupRepository>();
            return !userGroupRepository.Exists(groupName);
        }
    }
}