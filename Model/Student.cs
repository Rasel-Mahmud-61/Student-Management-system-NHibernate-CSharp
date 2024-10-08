using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementApp.Model
{
    public class Student
    {
        public virtual int rollNumber { get; set; }
        public virtual string firstName { get; set; }
        public virtual string lastName { get; set; }
        public virtual string department { get; set; }
        public virtual string mobileNumber { get; set; }

    }
}
