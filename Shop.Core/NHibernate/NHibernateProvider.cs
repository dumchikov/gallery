using System;
using System.Configuration;
using System.Data.SqlServerCe;
using System.IO;
using System.Net.Mime;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Ninject.Activation;
using Shop.Domain.Models;

namespace Shop.Core.NHibernate
{
    public class NHibernateProvider : IProvider<ISessionFactory>
    {
        //private readonly string _connectionString = ConfigurationManager.ConnectionStrings["shop"].ConnectionString;

        private readonly string _connectionString = string.Format("Data Source={0}; Persist Security Info=False;", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "photos.sdf"));

        private ISessionFactory BuildSessionFactory()
        {
            //SqlCeEngine engine = new SqlCeEngine(_connectionString);
            //engine.Upgrade();

            var configuration = Fluently.Configure()
                                        .Database(MsSqlCeConfiguration.Standard.ConnectionString(_connectionString))
                                        .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Entity>()
                                                                                 .Where(
                                                                                     x =>
                                                                                     x.Namespace != null &&
                                                                                     x.Namespace.Contains("Models"))
                                                                                 .UseOverridesFromAssembly(this.GetType().Assembly))
                                                        //.ExportTo(@"C:/mappings")
                                                        )

                                        .BuildConfiguration();

            //new SchemaExport(configuration).Execute(true, true, false);

            var sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory;
        }

        public object Create(IContext context)
        {
            return this.BuildSessionFactory();
        }

        public Type Type
        {
            get { return typeof(ISessionFactory); }
        }
    }
}