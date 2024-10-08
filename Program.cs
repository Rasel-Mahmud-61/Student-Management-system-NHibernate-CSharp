using StudentManagementApp.View;
using System.Reflection;
using System;
using System.Reflection;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
namespace StudentManagementApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            

            UI user = new UI();

          user.MainFile();

        }

    }
}