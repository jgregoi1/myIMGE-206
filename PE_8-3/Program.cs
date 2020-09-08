using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_8_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //prompts the user for a string
            Console.WriteLine("please enter a string");            
            string input = Console.ReadLine();

            //replaces any 'no' with a 'yes'
            input = input.ToLower();
            string input2 = input.Replace("no", "yes");
            
            //prints out the new string
            Console.WriteLine(input2);
        }
    }
}
