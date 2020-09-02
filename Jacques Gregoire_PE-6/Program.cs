using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Jacques_Gregoire_PE_6
{
    class Program
    {
        //Author: Jacques Gregoire.
        //Purpose: Generate a random number, which the user has eight chances to guess.
        //restrictions: none.
        static void Main(string[] args)
        //method: main
        //purpose: to generate a random number which the user has eight chances to guess.
        //restrictions: none.
        {
            Random rand = new Random();

            //String get;
            int guess = 10000;
            int i;
            bool correct = false;
            
            // generate a random number between 0 inclusive and 101 exclusive
            int randomNumber = rand.Next(0, 100);

            //this feature was only implimented during development
            //Console.WriteLine(randomNumber);

            //this loop keeps going until the user enters the correct number or runs out of guesses
            for (i = 1; i < 9; i++)
            {
                //this loop checks to see if the number is valid (0-100)
                do
                {
                    Console.WriteLine("Enter a number 0-100");
                    try
                    {
                        guess = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number.");
                    }

                } while (guess > 100 || guess < 0);


                //these statements check to see whether the guess is too high or too low.
                if (guess > randomNumber)
                {
                    Console.WriteLine("Your guess was to High!");
                    Console.WriteLine("guesses remaining: " + (8 - i));
                }
                if (guess < randomNumber)
                {
                    Console.WriteLine("Your guess was to low!");
                    Console.WriteLine("Guesses remaining: " + (8 - i));
                }
                if (guess == randomNumber)
                {
                    Console.WriteLine("Your guess was correct!");
                    Console.WriteLine("you got it in " + i + " guesses!");
                    correct = true;
                    break;
                }

            }


                // a final statement to display the correct answer.
                if (correct == false)
                {
                    if (i == 8)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("You used up all of your guesses!.");
                        Console.WriteLine("The number was " + randomNumber + ".");
                    }
                }

            

        }
    }
}
