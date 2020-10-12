using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Budget_Akanator
{
    class BTNode
    {
        public string message;
        public BTNode noNode;
        public BTNode yesNode;

        public BTNode(string nodeMessage)
        {
            message = nodeMessage;
            yesNode = null;
            noNode = null;
        }

        public void Query()
        {
            if (noNode != null && yesNode != null)
            {
                Console.WriteLine(message);
                Console.Write("Yes or No: ");

                string input = Console.ReadLine().ToLower();

                if (input.StartsWith("y"))
                {
                    yesNode.Query();
                }
                else
                {
                    noNode.Query();
                }
            }
            else
            {
                OnQueryObject();
            }
        }


        public void OnQueryObject()
        {
            Console.Write("Are you thinking of " + message + "? : ");
            string input = Console.ReadLine().ToLower();

            if (input.StartsWith("y"))
            {
                Console.WriteLine("The computer wins!");
            }
            else
            {
                UpdateTree();
            }
        }

        public void UpdateTree()
        {
            Console.Write("You won!  What were you thinking of?  : ");
            string userObject = Console.ReadLine();

            Console.Write("Please enter a yes/no question to distinguish " + message +
                " from " + userObject + " :  ");
            string userQuestion = Console.ReadLine();

            Console.Write("If you were thinking of " + userObject + ", what would the answer to that question be? :");
            string input = Console.ReadLine().ToLower();

            if (input.StartsWith("y"))
            {
                this.noNode = new BTNode(message);
                this.yesNode = new BTNode(userObject);
            }
            else
            {
                this.yesNode = new BTNode(message);
                this.noNode = new BTNode(userObject);
            }

            message = userQuestion;

            Console.WriteLine("Thank you, my knowledge has increased!");
        }
    }

    class BTTree
    {
        BTNode rootNode;

        public BTTree(string question, string yesGuess, string noGuess)
        {
            rootNode = new BTNode(question);
            rootNode.yesNode = new BTNode(yesGuess);
            rootNode.noNode = new BTNode(noGuess);
        }

        public void Query()
        {
            rootNode.Query();
        }
    }

    static class Program
    {
        static BTTree tree = null;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a yes/no question about an object: ");
            string question = Console.ReadLine();
            Console.Write("Enter a guess if the response is Yes: ");
            string yesGuess = Console.ReadLine();
            Console.Write("Enter a guess if the response is No: ");
            string noGuess = Console.ReadLine();

            tree = new BTTree(question, yesGuess, noGuess);

            do
            {
                tree.Query();

                Console.Write("Play again? : ");
                string input = Console.ReadLine().ToLower();

                if (input.StartsWith("n"))
                {
                    break;
                }

            } while (true);
        }
    }
}
