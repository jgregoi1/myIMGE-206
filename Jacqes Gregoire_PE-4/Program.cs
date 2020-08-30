using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jacqes_Gregoire_PE_4
{
    class Program
    {
        //Author: Jacques Gregoire
        //Purpose: To ask the user for two numbers until 
        //they input only one that is greater than 10
        //
        static void Main(string[] args)
        {
            //Creates the varibles for the progam
            int var1 = 0;
            int var2 = 0;
            bool greater = true;

            //this loop won't stop until the user inputs a number lower than 10
            while (greater == true)
            {
                Console.WriteLine("Please enter a number...");

                var1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter another number...");

                var2 = Convert.ToInt32(Console.ReadLine());

                greater =! (var1 > 10) ^ (var2 > 10);

                // this statment prints out a message based on the numbers input
                if(greater == true)
                {
                    Console.WriteLine("Numbers rejected! Enter at least one integer less than 10.");
                }
                else
                {
                    Console.WriteLine("Number accepted, disarming self-descruct. Have a nice day!");
                }

            }
            
            
        }
    }
}
