using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Jacques_Gregoire_PE3
{
    //Method: Main.
    //Purpose: prompt the user for four numbers and out put thier product.
    //Author: Jacques Gregoire.
    //Restrictions: none.
    class Program
    {

        static void Main(string[] args)            
        {
            //boolean varibles that allow for the try-catch statements.
            bool first = false;
            bool second = false;
            bool third = false;
            bool fourth = false;

            //ints for user imput.
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;


            int resultNum = 0;
            
            //A loop that wont stop until the user puts in a vailid number.
            while (first == false)
            {
                Console.WriteLine("Please enter a number.");
                
                try
                {
                    num1 = Convert.ToInt32(Console.ReadLine());
                    first = true;
                }
                catch
                {
                    Console.WriteLine("Please enter a vaild number.");
                }


            }

            //essentailly the same thing as above.
            while (second == false)
            {
                Console.WriteLine("Please enter another number.");

                try
                {
                    num2 = Convert.ToInt32(Console.ReadLine());
                    second = true;
                }
                catch
                {
                    Console.WriteLine("Please enter a vaild number.");
                }


            }

            //A loop that wont stop until the user enters a vailid number
            while (third == false)
            {
                Console.WriteLine("Please enter yet another number.");

                try
                {
                    num3 = Convert.ToInt32(Console.ReadLine());
                    third = true;
                }
                catch
                {
                    Console.WriteLine("Come on man, you were 2 for 3. Enter a valid number.");
                }            

               
            }

            //the final loop that asks for a number.
            while (fourth == false)
            {
                Console.WriteLine("Please enter your final number.");

                try
                {
                    num4 = Convert.ToInt32(Console.ReadLine());
                    fourth = true;
                }
                catch
                {

                    Console.WriteLine("geez, were you raised in a barn!? Enter a valid number!");
                }


            }

            //this part does the math.
            resultNum = num1 * num2 * num3 * num4;

            //this prints out the result.
            Console.WriteLine("Beep Bop Boop now doing math...");

            Console.WriteLine("Your result is: " + resultNum);
        }


    }
}
