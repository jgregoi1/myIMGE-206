using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //various varibles
            char single = 'n';

            //asks the user for a string
            Console.WriteLine("please enter a string");
            string input = Console.ReadLine();
            char[] cWord = input.ToCharArray();
            char[] dWord = new char[cWord.Length];
            
            //prints out the string in reverse.
            for (int i = 0; i < cWord.Length; i++)
            {
                single = cWord[(cWord.Length -1) - i];
                //Console.WriteLine(cWord.Length);
                dWord[i] = single;
                Console.Write(single);                
            }
            Console.WriteLine("");
            
            
        }
    }
}
