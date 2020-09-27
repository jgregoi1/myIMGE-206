using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            Pets pets = new Pets();

            Random rand = new Random();

            
            tryAgain:
            for (int i = 0; i < 50; i++)
            {
                if(rand.Next(0, 11) == 1)
                {
                    if (rand.Next(0,2) == 0)
                    {
                        int age = 0;
                        bool valid = false;
                        Console.WriteLine("you bought a Dog!");
                        Console.WriteLine("What do you want your dog to be named?");
                        string Dname = Console.ReadLine();
                        Console.WriteLine("How old is " + Dname + "?");
                        do
                        {
                            string temp = Console.ReadLine();
                            try
                            {
                                age = Convert.ToInt32(temp);
                                valid = true;
                            }
                            catch
                            {
                                Console.WriteLine("Please enter a number.");
                            }
                        } while (valid == false);
                        
                        valid = false;
                        Console.WriteLine("what is " + Dname + "'s license number?");
                        string Dlicesnse = Console.ReadLine();
                        //dog = (Dog)thisPet;
                        thisPet = new Dog(Dname, Dlicesnse, age);

                        
                    }
                    else
                    {
                        bool valid = false;
                        Console.WriteLine("you bought a Cat!");
                        Console.WriteLine("What do you want your Cat to be named?");
                        string Cname = Console.ReadLine();
                        Console.WriteLine("How old is " + Cname + "?");
                        do
                        {
                            try
                            {
                                int age = Convert.ToInt32(Console.ReadLine());
                                valid = true;
                            }
                            catch
                            {
                                Console.WriteLine("Please enter a number.");
                            }
                        } while (valid == false);

                        valid = false;
                        Console.WriteLine("what is " + Cname + "'s license number?");
                        string Clicense = Console.ReadLine();


                        thisPet = new Cat();

                    }
                }
                else
                {
                    thisPet = pets[rand.Next(0, pets.count)];

                    if (thisPet == null)
                    {
                        goto tryAgain;
                    }
                }


                if (thisPet.GetType() == typeof(Cat)) 
                {
                    iCat = (ICat)thisPet;

                    int rando = rand.Next(0, 4);

                    switch (rando)
                    {
                        case 0:
                            iCat.Eat();
                            break;
                        case 1:
                            iCat.Play();
                            break;
                        case 2:
                            iCat.Purr();
                            break;
                        case 3:
                            iCat.Scratch();
                            break;
                        default:
                            Console.WriteLine("this fell through for some reason");
                            break;
                    }


                    

                }
                else
                {
                    //thisPet = (Pet)iDog;

                    int rando = rand.Next(0, 5);

                    iDog = (IDog)thisPet;

                    switch (rando)
                    {
                        case 0:
                            iDog.Eat();
                            break;
                        case 1:
                            iDog.Play();
                            break;
                        case 2:
                            iDog.Bark();
                            break;
                        case 3:
                            iDog.NeedWalk();
                            break;
                        case 4:
                            iDog.GotoVet();
                            break;
                        default:
                            Console.WriteLine("this fell through for some reason");
                            break;
                    }


                }
                
               
                
            }



        }
    }

    public interface ICat
    {
        void Eat();
        void Play();
        void Purr();
        void Scratch();
        
    }

    public interface IDog
    {
        void Eat();
        void Play();
        void Bark();
        void NeedWalk();
        void GotoVet();
        
    }

    public class Cat : Pet, ICat
    {
        public Cat()
        {

        }
        public override void Eat()
        {
            Console.WriteLine(Name + ": I suppose this meal is... acceptible.");
        }
        public override void Play()
        {
            Console.WriteLine(Name + ": Look human, I have smote a mouse.");
        }
        public void Purr()
        {
            Console.WriteLine(Name + ": Purrr...");
        }
        public void Scratch()
        {
            Console.WriteLine(Name + ": What? the sofa isn't a sratching post?");
        }
        public override void GotoVet()
        {
            Console.WriteLine(Name + ": NOO! I won't go!");
        }
    }

    public class Dog : Pet, IDog
    {
        public string license;

        public Dog(string szName, string szLicense, int nAge): base(szName, nAge) 
        {
            this.Name = szName;
            this.license = szLicense;
            this.age = nAge;
        }

        public override void Eat()
        {
            Console.WriteLine(Name + ": Yum! I will eat anything!");
        }
        public override void Play()
        {
            Console.WriteLine(Name + ": I think ill roll around in the trash for kicks.");
        }
        public void Bark()
        {
            Console.WriteLine(Name + ": Bork!");
        }
        public void NeedWalk()
        {
            Console.WriteLine(Name + ": Hey, its time to go for a hike!");
        }
        public override void GotoVet()
        {
            Console.WriteLine(Name + ": uh heck no.");
        }
    }

    public abstract class Pet
    {
        private string name;
        public int age;
        public string Name;

        public Pet()
        {

        }

        public Pet(string name, int age)
        {
            this.name = name;
            this.age = age;
        }


        public abstract void Eat();

        public abstract void Play();

        public abstract void GotoVet();
        

        
    }

    public class Pets
    {      

       public List<Pet> petList = new List<Pet>();

        public Pet this[int nPetEl]
        {
            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[nPetEl];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                // if the index is less than the number of list elements
                if (nPetEl < petList.Count)
                {
                    // update the existing value at that index
                    petList[nPetEl] = value;
                }
                else
                {
                    // add the value to the list
                    petList.Add(value);
                }
            }
        }

        public int count
        {
            get
            {
                return petList.Count;
            }
        }
        public void Add(Pet pet)
        {
            petList.Add(pet);
        }

        public void Remove(Pet pet)
        {
            petList.Remove(pet);
        }

        public void RemoveAt(int PetEl)
        {

        }
    }
}
