using Autofac;
using Autofac.Integration.Mvc;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Owin;
using ModelsDAL;
using ModelsDAL.Repositories;
using MyWebApplication.App_Start;
using MyWebApplication.Controllers;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: OwinStartup(typeof(Startup))]
namespace MyWebApplication.App_Start
{
    public partial class Startup
    {
        [Obsolete]
        public static void Configuration(IAppBuilder app)
        { 
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var connectionString = ConfigurationManager.ConnectionStrings["MSSQL"];
            if (connectionString == null)
            {
                throw new Exception("Не найдена строка подключения");
            }

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register(x => { 
                var cfg = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012
                        .ConnectionString(connectionString.ConnectionString)
                        .Dialect<MsSql2012Dialect>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>())
                    .CurrentSessionContext("call");
                    var conf = cfg.BuildConfiguration();
                    var schemeExport = new SchemaUpdate(conf);
                    schemeExport.Execute(true, true);
                return cfg.BuildSessionFactory();
            }).As<ISessionFactory>().SingleInstance();
            containerBuilder
                .Register(x => x.Resolve<ISessionFactory>().OpenSession())
                .As<ISession>()
                .InstancePerRequest();
            containerBuilder.RegisterControllers(Assembly.GetAssembly(typeof(HomeController)));
            containerBuilder.RegisterModule(new AutofacWebTypesModule());

            var types = typeof(User).Assembly.GetTypes();
            foreach (var type in types)
            {
                var serviceAttribute = type.GetCustomAttribute<RepositoryAttribute>();
                if (serviceAttribute == null)
                {
                    continue;
                }
                containerBuilder.RegisterType(type);
            }


            var container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            app.UseAutofacMiddleware(container);

            CreateTestData(container);
        }

        private static void CreateTestData(IContainer container)
        {
            var repo = DependencyResolver.Current.GetService<FolderRepository>();
            if (!repo.Exists("ROOT"))
            {
                var folderList = new List<Folder>();
                var root = new Folder() { FolderName = "ROOT", ParentFolder = null };
                folderList.Add(root);
                folderList.Add(new Folder() { FolderName = "Folder1", ParentFolder = root });
                folderList.Add(new Folder() { FolderName = "Folder2", ParentFolder = root });
                var folder3 = new Folder() { FolderName = "Folder3", ParentFolder = root };
                folderList.Add(folder3);
                folderList.Add(new Folder() { FolderName = "Folder4", ParentFolder = folder3 });
                folderList.Add(new Folder() { FolderName = "Folder5", ParentFolder = folder3 });
                var author = new User() { Login = "1", Password = "1", FIO = "1", CreationDate = DateTime.Now, Age = 18, Email = "1@1.ru" };


                var documentList = new List<Document>();
                foreach (var folder in folderList)
                {
                    var document1 = new Document() { DocumentType = "text", Author = author, CreateDate = DateTime.Now, ParentFolder = folder, FolderName = "Document1 in " + folder.FolderName };
                    var document2 = new Document() { DocumentType = "text", Author = author, CreateDate = DateTime.Now, ParentFolder = folder, FolderName = "Document2 in " + folder.FolderName };
                    var document3 = new Document() { DocumentType = "text", Author = author, CreateDate = DateTime.Now, ParentFolder = folder, FolderName = "Document3 in " + folder.FolderName };
                    documentList.Add(document1);
                    documentList.Add(document2);
                    documentList.Add(document3);

                    repo.Save(folder);
                }
                foreach (var document in documentList)
                {
                    repo.Save(document);
                }
            }
        }
    }
}