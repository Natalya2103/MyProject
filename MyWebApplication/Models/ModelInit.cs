using Autofac;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ModelInit
    {
        static void Init()
        {
            var containerBuilder = new ContainerBuilder();
            //регистрируем объект, который будет создавать сессии
            containerBuilder.Register(X =>
                {
                    //конфигурирование объекта, которые будет создавать сессии
                    var cfg = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012
                        .ConnectionString("Data Source=.\\SQLEXPRESS; Initial Catalog=ITUniver; Integrated Security = true;")
                        .Dialect<MsSql2012Dialect>())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>());
                    var conf = cfg.BuildConfiguration();
                    var schemeExport = new SchemaUpdate(conf);
                    schemeExport.Execute(true, true); //сам создает таблицу
                    return cfg.BuildSessionFactory();
                }).As<ISessionFactory>().SingleInstance();//только 1 раз вып-ся
                                               //регистрируем способ создания сессий
            containerBuilder.Register(x => x.Resolve<ISessionFactory>().OpenSession())
                    .As<ISession>();

        }
    }
}
