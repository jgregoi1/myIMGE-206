using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary1
{
    class Program
    {
        struct employee
        {
            public string sName;
            public double dSalary;
        }

        static void Main(string[] args)
        {
            //string sName;

            bool emp = false;

            employee employee;
            employee.dSalary = 30000;

            Console.WriteLine("Please enter your name");
            employee.sName = Console.ReadLine().ToLower();
            
            emp = GiveRaise(employee);



            if (emp == true)
            {
                employee.dSalary += 19000;
                if (employee.dSalary > 30000)
                {
                    
                    Console.WriteLine("Boss-o-matic: Congratulations on the raise " + employee.sName + "!");
                    Console.WriteLine("Your salary is now $" + employee.dSalary + ".");
                }
                else
                {                    
                    Console.WriteLine("Your salary is now $" + employee.dSalary + " " + employee.sName + ".");
                    Console.WriteLine("Have a nice day! And rememeber, employees are our 9th most valuable asset.");

                }
            }
            else
            {
                Console.WriteLine("Your salary is $" + employee.dSalary + " " + employee.sName + ".");
                Console.WriteLine("Have a nice day! And rememeber, employees are our 9th most valuable asset.");

            }
        }


        static bool GiveRaise(employee s )
        {
            bool id = false;
            

            if (s.sName == "jacques gregoire")
            {
                             

                id = true;
            }
                 

            return id;


        }


    }
}

