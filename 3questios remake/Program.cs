using System;
using System.Timers;

namespace _3questios_remake
{
    class Program
    {
        static Timer timeOutTimer;

        static bool bTimeOut = false;

        static void Main(string[] args)
        {
            int input;
            int Ans;
            String primary;
            String answer;
            string playAgain;
            bool valid = false;




        start:
            bTimeOut = false;

            timeOutTimer = new Timer(5000);

            timeOutTimer.Elapsed += new ElapsedEventHandler(TimesUp);

            do
            {
                Console.WriteLine("Choose your question: 1-3");

                primary = Console.ReadLine();

                input = Convert.ToInt32(primary);

            } while (input > 3 && input < 1);

            if (input == 1)
            {
                Console.WriteLine("You will have five(5) seconds to answer the following question.");
                Console.WriteLine("what is your favorite color?");
                timeOutTimer.Start();

                answer = Console.ReadLine();

                answer = answer.ToLower();

                timeOutTimer.Stop();

                if (bTimeOut == false)
                {
                    if (answer == "black")
                    {
                        Console.WriteLine("Correct!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect! the correct answer is Black.");
                    }
                }
            }
            if (input == 2)
            {
                Console.WriteLine("You will have five(5) seconds to answer the following question.");
                Console.WriteLine("What is the answer to life, the universe, and everthing?");
                timeOutTimer.Start();

                answer = Console.ReadLine();

                Ans = Convert.ToInt32(answer);

                timeOutTimer.Stop();

                if (bTimeOut == false)
                {
                    if (Ans == 42)
                    {
                        Console.WriteLine("Correct!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect! the correct answer is 42.");
                    }
                }
            }
            if (input == 3)
            {
                Console.WriteLine("You will have five(5) seconds to answer the following question.");
                Console.WriteLine("What is the average air velcocity of an un-laden sparrow?");
                timeOutTimer.Start();
                
                answer = Console.ReadLine();

                answer = answer.ToLower();

                timeOutTimer.Stop();

                if (bTimeOut == false)
                {
                    if (answer == "an african sparrow or a european sparrow?")
                    {
                        Console.WriteLine("Correct!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect! The correct answer is an african sparrow or a european sparrow?");
                    }
                }
            }

            do
            {
                Console.WriteLine("Play again?");
                
                playAgain = Console.ReadLine();

                playAgain = playAgain.ToLower();

                if (playAgain.StartsWith("y"))
                {
                    goto start;                    
                }
                if (playAgain.StartsWith("n"))
                {
                    valid = true;
                }

            } while (valid == false);

            
        }

        static void TimesUp(object source, ElapsedEventArgs e)
        {
            
            Console.Write("Your time is up!");
            
            // set the bTimeOut flag to quit the game
            bTimeOut = true;

            // stop the timeOutTimer
            timeOutTimer.Stop();
        }


    }
}
