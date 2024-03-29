﻿using Microsoft.AspNet.Identity;
using ModelsDAL;
using ModelsDAL.Filters;
using ModelsDAL.Repositories;
using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace MyWebApplication.Extensions
{
    public static class HtmlExtensions
    {   //класс разметки
        public static MvcHtmlString SortLink(this HtmlHelper html,
            string linkText,
            string sortExpression,
            string action,
            string controller,
            RouteValueDictionary routeValues)
        {
            routeValues = routeValues ?? new RouteValueDictionary();
            SortDirection? sort = null;
            var sortDirectionStr = html.ViewContext.HttpContext.Request["SortDirection"];   //ViewContext - позволяет забрать данные из View
            if (!string.IsNullOrEmpty(sortDirectionStr) && 
                html.ViewContext.HttpContext.Request["SortExpression"] == sortExpression)
            {
                SortDirection s;
                if (Enum.TryParse(sortDirectionStr, out s))
                {
                    sort = s;
                }
            }
            routeValues["SortExpression"] = sortExpression;
            routeValues["SortDirection"] = sort.HasValue && sort.Value == SortDirection.Asc ?
                SortDirection.Desc :
                SortDirection.Asc;
            return html.Partial("SortLink", new SortLinkModel
            {
                Action = action,
                Controller = controller,
                SortDirection = sort,
                RouteValues = routeValues,
                LinkText = linkText
            });
        }

        public static User CurrentUser(this HtmlHelper html)
        {
            var principal = HttpContext.Current.User;
            if (principal == null)
            {
                return null;
            }
            var currentUserId = principal.Identity.GetUserId<long>();
            var userRepository = DependencyResolver.Current.GetService<UserRepository>();
            return userRepository.Load(currentUserId);
        }
        public static MvcHtmlString DisplayCurrentUser(this HtmlHelper html)
        {
            var user = CurrentUser(html);
            if (user == null)
            {
                return MvcHtmlString.Empty;
            }
            return MvcHtmlString.Create($"Пользователь: {user.UserName}  " + html.ActionLink("Выйти", "Logout", "Account"));
        }
    }
}