using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Reflection.Emit;

namespace Jacques_Gregoire_MadLibs
{
    class Program
    {
        //Author: Jacques Gregoire.
        //Purpose: to play a madlibs game by butchering some brief stories from a file.
        //Restrictions: none.
        static void Main(string[] args)
        {
            //Method: main.
            //purpose: basically does the whole madlibs game.
            //Restrictions: none.


            //these are the varibles that we use.
            String resultString = null;
            String user;
            String play = null;
            int story = -1;
            int numLibs = 0;
            int counter = 0;
            StreamReader input;

            //this label kicks things back to the top if you input something other than yes/no
            tryResult:

            //this statement asks the user if they want to play madlibs. if they say no-
            // the program ends.
            Console.WriteLine("do you want to play MadLibs? yes/no");
            play = Console.ReadLine();

            play.ToLower();                     

            if(play == "yes")
            {

                //asks the user for a name;
                Console.WriteLine("Pleaser enter your name");
                String name = Console.ReadLine();


                //this makes sure the program doesnt blow up when you ask for a story outside of the array
                while (story < 0 || story > 5)
                {
                    Console.WriteLine("Please choose a story 1 - 6");
                    user = Console.ReadLine();
                    try
                    {
                        story = Convert.ToInt32(user) - 1;
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number 1 - 6");
                    }
                }

                //this reads the file and counts how many stories there are
                input = new StreamReader("C:\\templates\\MadLibsTemplate.txt");

                string line = null;

                while ((line = input.ReadLine()) != null)
                {
                    numLibs++;
                }

                input.Close();

                //allocates an approprate number of strings for the amout of madlibs
                string[] libs = new string[numLibs];

                //reads the madlibs into an array of strings
                input = new StreamReader("C:\\templates\\MadLibsTemplate.txt");

                line = null;
                while ((line = input.ReadLine()) != null)
                {
                    libs[counter] = line;

                    libs[counter] = libs[counter].Replace("\\n", "\n");

                    counter++;
                }

                input.Close();

                //this chopps the madlibs up and allows us to replace the designated words with whatever the user enters
                string[] tale = libs[story].Split(' ');

                foreach (string thisWord in tale)
                {
                    if (thisWord.StartsWith("{"))
                    {
                        char[] chopped = thisWord.ToCharArray();

                        char[] promptword = new char[thisWord.Length];

                        int rep = 0;

                        for (int scp = 0; scp < chopped.Length; scp++)
                        {

                            if (chopped[scp] == '{' || chopped[scp] == '}' || chopped[scp] == ' ')
                            {
                                continue;
                            }

                            if (chopped[scp] == '_')
                            {
                                chopped[scp] = ' ';
                            }

                            promptword[rep++] = chopped[scp];
                        }

                        promptword[rep] = (char)0;

                        string sPrompt = new string(promptword);

                        //prompts the user to enter the requested word type
                        Console.WriteLine("Please enter a:" + sPrompt);
                        string uPut = Console.ReadLine();
                        resultString += " " + uPut;

                    }
                    //
                    else
                    {
                        resultString += " " + thisWord;
                    }

                }
                Console.WriteLine(resultString);


            }
            //if the user does not want madlibs, the progam ends.
            if (play == "no")
            {
                Console.WriteLine("Goodbye");
            }
            //if the user enters something invalid, the progam shoots them to the the start to try again.
            else
            {
                goto tryResult;
            }
        }
     }
}
