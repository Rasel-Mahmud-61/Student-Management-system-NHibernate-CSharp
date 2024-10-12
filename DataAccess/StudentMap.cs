using StudentManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace StudentManagementApp.DataAccess
{
    
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Table("StudentDetails"); // Database table name

            Id(x => x.RollNumber).Column("rollNumber").GeneratedBy.Assigned(); // Mapping for the ID property

            Map(s => s.FirstName).Column("firstName");
            Map(s => s.LastName).Column("lastName");
            Map(s => s.Department).Column("department");
            Map(s => s.MobileNumber).Column("mobileNumber");
        }
    }
}
