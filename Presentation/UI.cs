using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using StudentManagementApp.BusinessLogic;
using StudentManagementApp.Model;


namespace StudentManagementApp.View
{
    
    public class UI
    {
        private int rollNumber;
        private string firstName;
        private string lastName;
        private string department;
        private string mobileNumber;
        public void MainFile()
        {
            Console.WriteLine("Enter options 1 or 2: ");
            Console.WriteLine("1. Entry data");
            Console.WriteLine("2. Show data");
            string inputValue= Console.ReadLine();
            int inuputNumber=int.Parse(inputValue);
            Console.WriteLine($"Inputed value is {inuputNumber}");
            if (inuputNumber == 1)
            {
                EntryData();
            }
            else
            {
               ShowData();
            }


        }

        public void EntryData()
        {
            Console.WriteLine("Enter RollNumber");
            String inputValue= Console.ReadLine();
            rollNumber=int.Parse(inputValue);
            Console.WriteLine("Enter First Name");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter Your Department");
            department = Console.ReadLine();
            Console.WriteLine("Enter Your Mobile Number");
            mobileNumber = Console.ReadLine();

            Console.WriteLine("Your Inputed value is "+rollNumber+" "+ firstName+" "+ lastName+" "+department+" "+mobileNumber);

            PushTheValueToDatabase();

            

        }
        public void ShowData()
        {
            Console.WriteLine("Enter Roll Number to search:");
            string inputRollNumber = Console.ReadLine();
            int rollNumberToSearch = int.Parse(inputRollNumber);

       
           
            using (var session = NHibernateHelper.GetSession())
            {
                try
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        // Fetch student data by roll number
                        var student = session.Query<Student>().FirstOrDefault(s => s.RollNumber == rollNumberToSearch);

                        // Check if student exists and display data
                        if (student != null)
                        {
                            Console.WriteLine("Student Details:");
                            Console.WriteLine("Roll Number: " + student.RollNumber);
                            Console.WriteLine("First Name: " + student.FirstName);
                            Console.WriteLine("Last Name: " + student.LastName);
                            Console.WriteLine("Department: " + student.Department);
                            Console.WriteLine("Mobile Number: " + student.MobileNumber);
                        }
                        else
                        {
                            Console.WriteLine("No student found with Roll Number: " + rollNumberToSearch);
                        }

                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while fetching data: " + ex.Message);
                }
            }
        }


        public void PushTheValueToDatabase()
        {
      


  

            using (var session = NHibernateHelper.GetSession())
            {
                try
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        try
                        {
                            var student = new Student()
                            {
                                RollNumber = rollNumber,
                                FirstName = firstName,
                                LastName = lastName,
                                Department = department,
                                MobileNumber = mobileNumber,
                            };


                            session.Save(student);
                            transaction.Commit();
                            Console.WriteLine("Product saved successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }

        }

       
    }
}
