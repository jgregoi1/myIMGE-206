using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_8_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //various arrays
            Char[] splitter = { ' ' };
            string[] replace;
           
            //prompts the user for a string
            Console.WriteLine("Please enter a string");
            string input = Console.ReadLine();           

            //adds a "" around each word in the string
            replace = input.Split(splitter);

            foreach(string single in replace)
            {
                Console.Write("\"{0}\"", single);
            }
            Console.WriteLine("");

        }
    }
}
