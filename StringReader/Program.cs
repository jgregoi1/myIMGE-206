using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StringReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string Uinput;
            char[] input;
            LinkedList<char> linkedList = new LinkedList<char>();

            Console.WriteLine("Please enter a string, any string");
            Uinput = Console.ReadLine();
            Uinput = Uinput.ToLower();
            input = Uinput.ToCharArray();

            for(int i = 0; i < input.Length; i++)
            {
                linkedList.AddLast(input[i]);
            }
            Console.WriteLine();

            LetterCounter(linkedList);

            Console.WriteLine();

            Reverse(linkedList);

            Console.WriteLine();




            //removes all sepecial characters ( in theroy)
            for (int j = 0; j < linkedList.Count; j++)
            {
                linkedList.Remove(' ');
            }
            for (int j = 0; j < linkedList.Count; j++)
            {
                linkedList.Remove(',');
            }
            for (int j = 0; j < linkedList.Count; j++)
            {
                linkedList.Remove(Convert.ToChar('.'));
            }

            Pallidrome(linkedList);
        }

        static void LetterCounter(LinkedList<char> list)
        {  
            
             
            char[] lower = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
            int i = 0;
            

            
            
            for ( i = 0; i < lower.Length; i++)
            {
                LinkedListNode<char> linkedListNode1 = list.First;                
                int count = 0;
                while (linkedListNode1 != null)
                {                    
                    if ((char)linkedListNode1.Value == lower[i])
                    {                        
                        count++;
                    }             

                    linkedListNode1 = linkedListNode1.Next;
                }
                if (count == 1)
                {
                    Console.WriteLine("there is " + count + " " + lower[i] + " in your string");
                }
                else if (count > 0)
                {
                    Console.WriteLine("there are " + count + " " + lower[i] + "'s in your string");
                }
            }

        }

        static void Reverse(LinkedList<char> list)
        {
            LinkedListNode<char> linkedListNode1 = list.Last;

            while(linkedListNode1 != null)
            {
                Console.Write(linkedListNode1.Value);
                linkedListNode1 = linkedListNode1.Previous;
            }
        }

        static void Pallidrome(LinkedList<char> list)
        {
            bool isPallidrome = true;
            
            LinkedList<char> lister1 = new LinkedList<char>();
            LinkedList<char> lister2 =  new LinkedList<char>();
            LinkedListNode<char> linkedListNode1;
            LinkedListNode<char> linkedListNode2;

            for(int i = 0; i < list.Count; i++)
            {
                if(list.Count.ToString() == "1")
                {
                    break;
                }
                linkedListNode1 = list.First;
                linkedListNode2 = list.Last;

                if (linkedListNode1.Value != linkedListNode2.Value)
                {
                    isPallidrome = false;
                    break;
                }

                list.Remove(linkedListNode1);
                list.Remove(linkedListNode2);
            }
            if (isPallidrome == true)
            {
                Console.WriteLine("Is a pallidrome.");
            }
            else if (isPallidrome == false)
            {
                Console.WriteLine("Is not a pallidrome.");
            }
                
        }
    }
    
}
