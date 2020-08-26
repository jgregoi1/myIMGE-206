
using System;

namespace SquashTheBugs
{
    // Class Program
    // Author: David Schuh, Editied by Jacques Gregoire
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10 
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            // Compiletime error: missing ';' the the end of the line.
            //int i = 0 
            //Runtime error: int i needs to be greater than 1 in order for the program to work;
            //int i = 0
            int i = 2;

            //string was moved here with the rest of the declared varibles.
            string allNumbers = null;

            // loop through the numbers 1 through 10
            //Logic error: int i shared the same name as the declared varible above.
            //loic error: also needed to be '<=' to get ten results.
            //for (i = 1; i < 10; ++i)
          
            for (int count = 1; count <= 10; ++count)
            {
                // declare string to hold all numbers
                //compiletime error: String should be declared above the loop. 
                //string allNumbers = null;

                // output explanation of calculation
                //compiletime error: missing ""'s in print output.
                //Console.Write(i + "/" + i - 1 + " = ");
                Console.Write(i + "/" + i + " - 1" + " = ");

                // output the calculation based on the numbers
                Console.WriteLine(i / (i - 1));

                // concatenate each number to allNumbers
                allNumbers += i + " ";

                // increment the counter
                i = i + 1;
            }

            // output all numbers which have been processed
            //compiletime error; missing '+' in the output.
            //Console.WriteLine("These numbers have been processed: "  allNumbers);
            Console.WriteLine("These numbers have been processed: " + allNumbers);
        }
    }
}
