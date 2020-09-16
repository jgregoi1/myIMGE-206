using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary1
{
    class Program
    {
        static void Main(string[] args)
        {
            string sName;
            double dSalary = 30000;
            bool emp;

            Console.WriteLine("Please enter your name");
            sName = Console.ReadLine(); 
            
            emp = GiveRaise(sName.ToLower(), ref dSalary);

            if (emp == true)
            {
                if (dSalary > 30000)
                {
                    Console.WriteLine("Boss-o-matic: Congratulations on the raise " + sName + "!");
                    Console.WriteLine("Your salary is now $" + dSalary + ".");
                }
                else
                {
                    Console.WriteLine("Your salary is now $" + dSalary + " " + sName + ".");
                    Console.WriteLine("Have a nice day! And rememeber, employees are our 9th most valuable asset.");

                }
            }
            else
            {
                Console.WriteLine("Your salary is $" + dSalary + " " + sName + ".");
                Console.WriteLine("Have a nice day! And rememeber, employees are our 9th most valuable asset.");

            }
        }


        static bool GiveRaise(string name, ref double salary)
        {
            bool id = false;

            if (name == "jacques gregoire")
            {
                salary = 19999.99;

                id = true;
            }

            return id;


        }


    }
}
