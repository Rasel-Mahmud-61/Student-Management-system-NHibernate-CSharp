# ✍️Install Fluent NHibernate

**The first step is to start Fluent NHibernate is to install Fluent NHibernate package. So open the NuGet Package Manager Console and enter the following command**

```PM> install-package FluentNHibernate```

# 👉Mapping  
**we need to create Mappings using fluent NHibernate**
```
﻿using FluentNHibernate.Mapping;

namespace StudentApp
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Table("Student"); // Database table name
            Id(x => x.ID).GeneratedBy.Assigned(); // Mapping for the ID property
            Map(s => s.FirstName);
            Map(x => x.LastName);
        }
    }
}
```

# ✍️ NHibernateHelper.cs 

```﻿using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp
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

```


#👉Program.cs 
**Program.cs file in which we will start a session and then create a new customer and save that customer to the database**

```﻿using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp
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
}  ```

# Data Insert
```
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp
{
    internal class InsertData
    {
        public void InsertValue()
        {
            using (var session = NHibernateHelper.GetSession())
            {

                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        var student5 = new Student()
                        {
                            ID = 6,
                            FirstName = "Rumel",
                            LastName = "naimur"
                        };

                        session.Save(student5);

                        tx.Commit();
                        Console.WriteLine("save sucessfully_");

                    }
                    catch (Exception ex) { }



                }

            }
        }
    }
}
```
