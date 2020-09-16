using System;
using System.Net.Http.Headers;

namespace UT1_BugSquash
{
    class Program
    {
        // Calculate x^y for y > 0 using a recursive function
        static void Main(string[] args)
        {
            string sNumber;
            int nX;
            //compiletime error: missing ';'
            //int nY
            int nY;
            int nAnswer;

            //compiletime error: missing " " around the string to be printed
            //Console.WriteLine(This program calculates x ^ y.);
            Console.WriteLine("This program calculates x ^ y.");
            do
            {
                Console.Write("Enter a whole number for x: ");
                //compiletime error: sNnumber needs to be assigned a value here.
                //Console.ReadLine();
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nX));

            retry:

            do
            {
                
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
                //compiletime error: declared xN where nY needs to be declared.
                //while (int.TryParse(sNumber, out nX));
                //logic error: needs to be !int... instead of int...
                //while (int.TryParse(sNumber, out nY));
                //runtime error: needs to be a way to stop negitive values put on for y;
                //fix: added an if statement that retries the loop if nY is negative or 0
            } while (!int.TryParse(sNumber, out nY));
            
            if (nY <= 0)
            {
                goto retry;
            }
            // compute the factorial of the number using a recursive function
            
            nAnswer = Power(nX, nY);            
            //runtime error: need to get rid of the " "s around the varibles
            //Console.WriteLine("{nX}^{nY} = {nAnswer}");
            Console.WriteLine(nX + "^" + nY + "=" + nAnswer);
        }

        //compiletime error: misisng 'static'.
        //int Power(int nBase, int nExponent)
        static int Power(int nBase, int nExponent)
        {
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                returnVal = 0;
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                //logic error: needs to be -1 instead of +1
                //nextVal = Power(nBase, nExponent + 1);
                nextVal = Power(nBase, nExponent - 1);

                // multiply the base with all subsequent values
                returnVal = nBase * nextVal;
            }
            //runtime error: missing 'return'
            return returnVal;
        }
    }
}
