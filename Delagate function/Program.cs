using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delagate_function
{
    class Program
    { delegate string readerFunction(string input);
        static void Main(string[] args)
        {

            string nullHolder = null;

            Console.WriteLine("please enter a string.");

            readerFunction stringReader;

            stringReader = new readerFunction(stringer);

            nullHolder = stringReader(nullHolder);
        }

        static string stringer(string input)
        {
            input = Console.ReadLine();
            return input;
        }
       
    }
   
}


