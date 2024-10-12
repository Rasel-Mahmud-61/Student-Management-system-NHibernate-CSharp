using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementApp.Model
{
    public class Student
    {
        

        public virtual int RollNumber { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Department { get; set; }
        public virtual string MobileNumber { get; set; }

    }
}
