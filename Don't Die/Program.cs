using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

using System.Net;
using System.IO;
using System.Web;

using Newtonsoft.Json;
using System.Runtime.ExceptionServices;
using System.CodeDom;

namespace Don_t_Die
{
    public enum Edirection
    {
        north,
        south,
        east,
        west,
        none
    }

    public class Path
    {
        public Edirection direction = Edirection.none;
        public int cost = -1;
        public int neightbor;
        public bool isValid = false;
    }

    public class TriviaResult
    {
        public string category;
        public string type;
        public string difficulty;
        public string question;
        public string correct_answer;
        public List<string> incorrect_answers;
    }

    public class Trivia
    {
        public int response_code;
        public List<TriviaResult> results;

    }
    

    class Program
    {




        static int[,] mCosts = new int[,]
        {
            {0, 2, -1, -1, -1, -1, -1, -1},  //a
            {-1, -1, 2, 3, -1, -1, -1, -1},   //b
            {-1, 2, -1, -1, -1, -1, -1, 20}, //c
            {-1, 3, 5, -1, 2, 4, -1, -1},    //d
            {-1, -1, -1, -1, -1, 3, -1, -1}, //e
            {-1, -1, -1, -1, -1, -1, 1, -1}, //f
            {-1, -1, -1, -1, 0 , -1, -1, 2},  //g
            {-1, -1, -1, -1, -1, -1, -1, -1} //h
        };
                

        static Edirection[,] mDirection = new Edirection[,]
        {
            {Edirection.none, Edirection.south, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none}, //a
            {Edirection.none, Edirection.none, Edirection.south, Edirection.east, Edirection.none, Edirection.none,Edirection.none, Edirection.none}, //b
            {Edirection.none, Edirection.north, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.south}, //c
            {Edirection.none, Edirection.west, Edirection.south, Edirection.none, Edirection.north, Edirection.east, Edirection.none, Edirection.none}, //d
            {Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.south, Edirection.none,Edirection.none}, //e
            {Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.east, Edirection.none}, //f
            {Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.north, Edirection.none, Edirection.none, Edirection.south}, //g
            {Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none}  //h
        };

        static Edirection[][] lDirection = new Edirection[][]
        {
            new Edirection[] {Edirection.north, Edirection.south},
            new Edirection[] {Edirection.south, Edirection.east},
            new Edirection[] {Edirection.north, Edirection.south},
            new Edirection[] {Edirection.west, Edirection.south, Edirection.north, Edirection.east},
            new Edirection[] {Edirection.south},
            new Edirection[] {Edirection.east},
            new Edirection[] {Edirection.north, Edirection.south},
            new Edirection[] {}
        };

        static int[][] lNeighbors = new int[][]
        {
            new int[] {0, 1},
            new int[] {2, 3},
            new int[] {1, 7},
            new int[] {1, 2, 4, 5},
            new int[] {5},
            new int[] {6},
            new int[] {4, 7},
            new int[] {}
        };

        static int[][] lCost = new int[][]
        {
            new int[] {0, 2},
            new int[] {2, 3},
            new int[] {2,20},
            new int[] {3, 5, 2, 4},
            new int[] {3},
            new int[] {1},
            new int[] {0, 2},
            new int[] {}
        };

        
        static Path path1 = new Path();
        static Path path2 = new Path();
        static Path path3 = new Path();
        static Path path4 = new Path();

        static void Main(string[] args)
        {
            
            
            
            int wager;
            string Swager;
            int room = 0;
            int health = 1;
            bool gameOver = false;
            string response;
            string movement;
            bool isCorrect = false;
            
           
            List<Path> directions = new List<Path>();

            while (!gameOver)
            {
                Description(room);
                Console.WriteLine("Hp: " + health);
                pathfinder(room, lDirection, lNeighbors, lCost);
                isCorrect = false;
                if (path1.cost < health && path1.cost != -1)
                {
                    Console.WriteLine(" You see a path to the " + path1.direction + ". Path cost:" + path1.cost);
                    path1.isValid = true;
                    directions.Add(path1);
                }
                if (path2.cost <health && path2.cost != -1)
                {
                    Console.WriteLine(" You see a path to the " + path2.direction + ". Path cost:" + path2.cost);
                    path2.isValid = true;
                    directions.Add(path2);

                }
                if (path3.cost < health && path3.cost != -1)
                {
                    Console.WriteLine(" You see a path to the " + path3.direction + ". Path cost:" + path3.cost);
                    path3.isValid = true;
                    directions.Add(path3);

                }
                if (path4.cost < health && path4.cost != -1)
                {
                    Console.WriteLine(" You see a path to the " + path4.direction + ". Path cost:" + path4.cost);
                    path4.isValid = true;
                    directions.Add(path4);

                }


                tryAgain:
                Console.WriteLine();

                Console.WriteLine("What do you do: \nTrivia. \nMove.");

                response = Console.ReadLine();
                response = response.ToLower();

                if (response.StartsWith("m"))
                {
                    Console.WriteLine("which way do you want to travel? (Enter a valid direction)");
                    again:
                    movement = Console.ReadLine();
                    movement = movement.ToLower();               


                    if (movement != "north" && movement != "south" && movement != "east" && movement != "west")
                    {
                        Console.WriteLine("Please enter a valid direction.");
                        goto again;

                    }
                    
                    if (movement == path1.direction.ToString())
                    {
                        if(path1.isValid == false)
                        {
                            Console.WriteLine("That path isnt valid");
                            goto again;
                        }
                        room = path1.neightbor;
                        health -= path1.cost;
                    }
                    if (movement == path2.direction.ToString())
                    {
                        if (path2.isValid == false)
                        {
                            Console.WriteLine("That path isnt valid");
                            goto again;
                        }
                        room = path2.neightbor;
                        health -= path2.cost;
                    }
                    if (movement == path3.direction.ToString())
                    {
                        if (path3.isValid == false)
                        {
                            Console.WriteLine("That path isnt valid");
                            goto again;
                        }
                        room = path3.neightbor;
                        health -= path3.cost;
                    }
                    if (movement == path4.direction.ToString())
                    {
                        if (path4.isValid == false)
                        {
                            Console.WriteLine("That path isnt valid");
                            goto again;
                        }
                        room = path4.neightbor;
                        health -= path4.cost;
                    }

                    health -= attack(health);

                }
                if (response.StartsWith("t"))
                {
                    Console.WriteLine("how much health do you want to wager?");
                    Oncemore:
                    Swager = Console.ReadLine();

                    try
                    {
                        wager = Convert.ToInt32(Swager);
                    }
                    catch
                    {
                        Console.WriteLine("Please enter an integer.");
                        goto Oncemore;
                    }
                    if (wager > health)
                    {
                        Console.WriteLine("Please enter a value less than or equal to your health");
                        goto Oncemore;
                    }

                    Trivia(isCorrect, wager);

                    if(isCorrect == true)
                    {
                        health += wager;
                    }
                    if(isCorrect == false)
                    {
                        health -= wager;
                    }
                }
                else
                {
                    Console.WriteLine("Make a valid selection.");
                    goto tryAgain;
                }

                if(health <= 0)
                {
                    gameOver = true;
                    Console.WriteLine("You died!");
                }
                if(room == 7)
                {
                    gameOver = true;
                    Console.WriteLine("You Win!");
                }
            } 
            
        }

        static void Description(int room)
        {
            if(room == 0)
            {
                Console.WriteLine("You are in a dark cavern. light shines from the hole you must have fallen through, but it is far above. \n You feel like you're being watched");
            }
            if (room == 1)
            {
                Console.WriteLine("The next room is damp and reeks of something dead. liquid drips from the celling, but its definiatly not water.");
            }
            if (room == 2)
            {
                Console.WriteLine("You find yourself in a much more plesant room than the last one. A small waterfall flows into a pool and glowing crystals grow from the walls");
            }
            if (room == 3)
            {
                Console.WriteLine("You walk into a spacious cavern full of stalagtites. A stale breeze blows through the cave");
            }
            if (room == 4)
            {
                Console.WriteLine("Something is very wrong with this room. \n The floor is squishy and mucus drips from the walls. You can't wait to get out of here. \n You feel like you are being watch again.");
            }
            if (room == 5)
            {
                Console.WriteLine("This room appears to have been a workshop at one point. Robot parts litter workbenches and blueprints line the walls");
            }
            if (room == 6)
            {
                Console.WriteLine("Glowing purple mushrooms dot the walls and floor of this room. The spores they release make the air thick. You start to feel dizzy");
            }
            if (room == 7)
            {
                Console.WriteLine("You enter this room and see exactly what you have been looking for, an exit. light shines from a hole far above. \n A rope and bucket decends to a pool at the center of the cavern. finally you have found a way out. ");
            }
            if (room > 7 || room < 0)
            {
               Console.WriteLine("You seem to have strayed from the main cave system. The eyes you felt following your earlier glow white in the darkness. \n Claws flash, flesh tears, your body hits the cold floor, never to be found.");
            }
        }

        static void pathfinder(int room, Edirection[][] direction, int[][] neighbors, int[][] cost)
        {
            //finds the neighbors of the current room.
            for (int i = 0; i < neighbors[room].Length; i++)
            {                

                if (i == 0)
                {
                    path1.cost = neighbors[room][i];
                }
                if(i == 1)
                {
                    path2.cost = neighbors[room][i];
                }
                if(i == 2)
                {
                    path3.cost = neighbors[room][i];
                }
                if(i == 3)
                {
                    path4.cost = neighbors[room][i];
                }

            }
            //finds the direction of the neighbors
            for (int i = 0; i < direction[room].Length; i++)
            {
                //Console.WriteLine(direction[room][i]);

                if (i == 0)
                {
                    path1.direction = direction[room][i];
                }
                if (i == 1)
                {
                    path2.direction = direction[room][i];
                }
                if (i == 2)
                {
                    path3.direction = direction[room][i];
                }
                if (i == 3)
                {
                    path4.direction = direction[room][i];
                }
            }
            //finds th cost of the neightboring paths
            for (int i = 0; i < cost[room].Length; i++) 
            {
                //Console.WriteLine(cost[room][i]);

                if (i == 0)
                {
                    path1.cost = cost[room][i];
                }
                if (i == 1)
                {
                    path2.cost = cost[room][i];
                }
                if (i == 2)
                {
                    path3.cost = cost[room][i];
                }
                if (i == 3)
                {
                    path4.cost = cost[room][i];
                }
            }
        }
       
        public static bool Trivia(bool isCorrect, int wager)
        {
            
            string url = null;
            string s = null;
            HttpWebRequest request;
            HttpWebResponse response;
            Random rand = new Random();
            StreamReader reader;
            string inputI;
            int inputS;
            

            url = "https://opentdb.com/api.php?amount=1&type=multiple";

            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());

            s = reader.ReadToEnd();
            reader.Close();


            Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);

            trivia.results[0].question = HttpUtility.HtmlDecode(trivia.results[0].question);
            trivia.results[0].correct_answer = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);

            for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
            {
                trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
            }

            List<string> answers = new List<string>();

            do
            {
                int option = rand.Next(0, 100);
                if (option < 25)
                {
                    if (!answers.Contains(trivia.results[0].correct_answer))
                    {
                        answers.Add(trivia.results[0].correct_answer);
                    }
                }
                if (option >= 25 && option < 50)
                {
                    if (!answers.Contains(trivia.results[0].incorrect_answers[0]))
                    {
                        answers.Add(trivia.results[0].incorrect_answers[0]);
                    }
                }
                if (option >= 50 && option < 75)
                {
                    if (!answers.Contains(trivia.results[0].incorrect_answers[1]))
                    {
                        answers.Add(trivia.results[0].incorrect_answers[1]);
                        
                    }
                }
                if (option >= 75 && option < 100)
                {
                    if (!answers.Contains(trivia.results[0].incorrect_answers[2]))
                    {
                        answers.Add(trivia.results[0].incorrect_answers[2]);
                        
                    }
                }                
            } while (answers.Count < 4);

            int rando = 1;
            Console.WriteLine(trivia.results[0].question);
            foreach(string answer in answers)
            {
                Console.WriteLine(rando + ". " + answer);
                rando++;
            }
            Oncemore:
            inputI = Console.ReadLine();

            try
            {
                inputS = Convert.ToInt32(inputI);
            }
            catch
            {
                Console.WriteLine("Please Enter an integer.");
                goto Oncemore;
            }
            if(inputS > 4 || inputS < 1)
            {
                Console.WriteLine("Enter a number 1-4.");
                goto Oncemore;
            }

            if(answers[inputS -1] == trivia.results[0].correct_answer)
            {
                
                Console.WriteLine("Correct! you gained " + wager + " health!");
                isCorrect = true;
            }
            else
            {
                Console.WriteLine("Incorrect! the correct answer was " + trivia.results[0].correct_answer + ".");                
                Console.WriteLine("You lost " + wager + " health.");
                isCorrect = false;
            }

            return isCorrect;
        }
        
        public static int attack(int hp)
        {
            Random rando = new Random();
            int type = rando.Next(0, 7);
            int loss = rando.Next(0, (hp - 1));



            if (hp > 1)
            {                
                if (type == 0)
                {
                    Console.WriteLine("As you enter the next room you trip over a rock, losing " + loss + " health.");
                }
                if (type == 1)
                {
                    Console.WriteLine("The floor of the tunnel is slick with scum. You slip and land hard on your head. You wake up " + loss + " health weaker.");
                }
                if (type == 2)
                {
                    Console.WriteLine("As you walk through the dark tunnel as strange leafy creature sneaks up behind you. It hisses and explodes, dealing " + loss + " damage.");
                }
                if (type == 3)
                {
                    Console.WriteLine("You didnt see the tripwire until too late. The flame trap activates, dealing " + loss + " damage.");
                }
                if (type == 4)
                {
                    Console.WriteLine("It was a mistake not putting anything into the offering plate of the statue you passed. Now you're cursed for -" + loss + " health.");
                }
                if (type == 5)
                {
                    Console.WriteLine("A noxious breeze blows through the tunnels, dealing " + loss + " damage.");
                }
                if (type == 6)
                {
                    Console.WriteLine("You trip over a large hive of cave bees. They don't believe you when you say it was an accident and punish you for " + loss + " damage");
                }
                if (type == 7)
                {
                    Console.WriteLine("You buy a drink from a spider bar, hoping to quench your thirst. To bad it's only poison that deals " + loss + " damage.");
                }
            }
            return loss;
        }
    }
}

