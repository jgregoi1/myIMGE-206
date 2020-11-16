using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizardry_
{
    public class Wizard: IComparable<Wizard>
    {
        public string name;
        public int age;
        public string specialty;

        public int CompareTo(Wizard other)
        {
            return this.age.CompareTo(other.age);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Wizard> wizards = new List<Wizard>();

            Wizard wizard = new Wizard();
            wizard.name = "Merlin";
            wizard.age = 180;
            wizard.specialty = "Sorcerer";
            wizards.Add(wizard);

            wizard = new Wizard();
            wizard.name = "Astroloth";
            wizard.age = 1034;
            wizard.specialty = "Sorcerer";
            wizards.Add(wizard);

            wizard = new Wizard();
            wizard.name = "Markus";
            wizard.age = 23;
            wizard.specialty = "Geomancer";
            wizards.Add(wizard);

            wizard = new Wizard();
            wizard.name = "Derin";
            wizard.age = 72;
            wizard.specialty = "Pyromancer";
            wizards.Add(wizard);

            wizard = new Wizard();
            wizard.name = "Wynnter";
            wizard.age = 40;
            wizard.specialty = "Master of Ice";
            wizards.Add(wizard);

            wizard = new Wizard();
            wizard.name = "Maltic";
            wizard.age = 68;
            wizard.specialty = "Hydromancer";
            wizards.Add(wizard);

            wizard = new Wizard();
            wizard.name = "Boron";
            wizard.age = 21;
            wizard.specialty = "Areomancer";
            wizards.Add(wizard);

            wizard = new Wizard();
            wizard.name = "Olutis";
            wizard.age = 99;
            wizard.specialty = "Arcanist";
            wizards.Add(wizard);

            wizard = new Wizard();
            wizard.name = "Zackius";
            wizard.age = 22;
            wizard.specialty = "Lightning Mage";
            wizards.Add(wizard);

            wizard = new Wizard();
            wizard.name = "Quriell";
            wizard.age = 54;
            wizard.specialty = "Feromancer";
            wizards.Add(wizard);

            //wizards = ByAge(wizards);
            Console.WriteLine("Before sorting:");
            foreach(Wizard mage in wizards)
            {
                Console.WriteLine(mage.age + " " + mage.name + " the " + mage.specialty);
            }
            
            //first method
            wizards.Sort();

            //alternative method (Now with a lambda!)
            wizards = wizards.OrderBy(other => other.age).ToList();

            Console.WriteLine();
            Console.WriteLine("After sorting:");
            foreach (Wizard mage in wizards)
            {
                Console.WriteLine(mage.age + " " + mage.name + " the " + mage.specialty);
            }

        }

        
    }
}
