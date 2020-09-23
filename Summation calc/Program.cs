using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Summation_calc
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDerivedClass derivitive = new MyDerivedClass();
            Console.WriteLine(derivitive.GetString());
        }
    }

    public class MyClass
    {

        private string myString;

        public virtual string GetString()
        {
            return myString;
        }

        public string MyString
        {
            set
            {
                myString = "not null";
            }
        }
    }

    public class MyDerivedClass: MyClass
    {

        public override string GetString()
        {
            return base.GetString() + "(output from the derived class)";
        }
    }
}
