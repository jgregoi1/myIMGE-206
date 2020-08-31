
using System;

namespace Mandelbrot
{
    /// <summary>
    /// This class generates Mandelbrot sets in the console window!
    /// </summary>


    class Class1
    {
        /// <summary>
        /// This is the Main() method for Class1 -
        /// this is where we call the Mandelbrot generator!
        /// </summary>
        /// <param name="args">
        /// The args parameter is used to read in
        /// arguments passed from the console window
        /// </param>
        /// Author:Jacques Gregoire

        [STAThread]
        static void Main(string[] args)
        {
            //these are all the varibles we need for the program
            double realCoord, imagCoord;
            double realTemp, imagTemp, realTemp2, arg;
            double holder = 0;
            double holder2 = 0;
            double place = 0;
            double place2 = 0;
            double num1 = 0;
            double num2 = 0;
            int iterations;
            bool pass = false;
            bool pass2 = false;
            bool pass3 = false;
            bool pass4 = false;

            // this loop asks for the start value of imagCoord
            while (pass == false)
            {
                Console.WriteLine("please enter a decimal (1.2 is a good start)");

                try
                {
                    holder = Convert.ToDouble(Console.ReadLine());

                    pass = true;
                }
                catch
                {
                    Console.WriteLine("Please enter a number.");
                }
            }
                //this loop asks for the end value of imagCoord
                while (pass2 == false)
                {
                    Console.WriteLine("please enter an decimal less than " + holder + " (-1.2 is a good place to start)");

                    try
                    {
                        holder2 = Convert.ToDouble(Console.ReadLine());

                        if (holder2 < holder)
                        {
                            pass2 = true;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("please enter a number");
                    }
                }

                //this loop asks for the start value of realCoord
                while (pass3 == false)
                {
                    Console.WriteLine("please enter a decimal. (-0.6 is a good place to start)");

                    try
                    {
                        place = Convert.ToDouble(Console.ReadLine());

                        pass3 = true;
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number.");
                    }
                }

                //this loop asks for the end value fo realCoord
                while (pass4 == false)
                {


                    Console.WriteLine("please enter a decimal greater than " + place + " (1.77 is a good place to start.)");

                    try
                    {
                        place2 = Convert.ToDouble(Console.ReadLine());

                        if (place2 > place)
                        {
                            pass4 = true;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number.");
                    }

                }

                //these equations calculate the incriments
                num1 = (holder - holder2) / 48;
                num2 = (place - place2) / 80;


                //these nested loops do the math for which characters go where
                for (imagCoord = holder; imagCoord >= holder2; imagCoord -= 0.05)
                {
                    for (realCoord = place; realCoord <= place2; realCoord += 0.03)
                    {
                        iterations = 0;
                        realTemp = realCoord;
                        imagTemp = imagCoord;
                        arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                        while ((arg < 4) && (iterations < 40))
                        {
                            realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                               - realCoord;
                            imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                            realTemp = realTemp2;
                            arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                            iterations += 1;
                        }
                        //this swtich statment puts siad characters into the console baised on the math
                        switch (iterations % 4)
                        {
                            case 0:
                                Console.Write(".");
                                break;
                            case 1:
                                Console.Write("o");
                                break;
                            case 2:
                                Console.Write("O");
                                break;
                            case 3:
                                Console.Write("@");
                                break;
                        }
                    }
                    Console.Write("\n");
                }

            }
        }

    }



