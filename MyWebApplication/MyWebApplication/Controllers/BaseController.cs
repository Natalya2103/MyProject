using MyWebApplication.Files;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApplication.Controllers
{
    public class BaseController : Controller
    {
        public IFileProvider[] FileProvider { get; set; }

        protected IFileProvider GetFileProvider()
        {
            var key = ConfigurationManager.AppSettings["FileProvider"];
            if (string.IsNullOrEmpty(key))
            {
                throw new Exception("Не задан провайдер для хранения файлов");
            }
            var fileProvider = FileProvider
                .FirstOrDefault(f => f.Name.Equals(key, StringComparison.Ordinal));
            if (fileProvider == null)
            {
                throw new Exception("Не задан провайдер для хранения файлов");
            }
            return fileProvider;
        }
    }
}