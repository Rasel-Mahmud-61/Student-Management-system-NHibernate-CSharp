using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using StudentManagementApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementApp.BusinessLogic
{
    internal class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    string connectionString = "Data Source=LAPTOP-SP1NASH4\\SQLEXPRESS;Initial Catalog = RASELMAHMUD;TrustServerCertificate=True; Trusted_Connection=True;";
                    _sessionFactory = Fluently.Configure()
    .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString)
    .ShowSql())  // Enables SQL logging
    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StudentMap>())
    .BuildSessionFactory();

                }


                return _sessionFactory;
            }
        }
        public static ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
