using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester3
{
    class Program
    {
        public class myClass
        {
            public int myInt;

            public myClass(int val)
            {
                this.myInt += val;
                Console.WriteLine("Second");
            }
        }

        public class myDerivedClass: myClass
        {
            public myDerivedClass(int val): base(val)
            {
                this.myInt = (this.myInt + 2) * 4;
                Console.WriteLine("First");
            }
        }


        static void Main(string[] args)
        {
            myDerivedClass myobj = new myDerivedClass(42);
            Console.WriteLine(myobj.myInt);
        }
    }
}
