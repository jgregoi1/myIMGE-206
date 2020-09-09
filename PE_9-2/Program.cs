using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_9_2
{
    class Program
    {

        delegate string stringReader(string s);
        static void Main(string[] args)
        {
            //declares the delagate
            Console.WriteLine("Please enter a string");

            stringReader processReader;

            processReader = new stringReader(Stringer);

        }

        public static string Stringer(string s)
        {
            s = Console.ReadLine();


           return s;
        }


    }



}

