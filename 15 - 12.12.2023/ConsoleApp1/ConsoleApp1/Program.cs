using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        class Animal 
        {
            public string name;
            public int averageMaxAge;
            public int endangerment;

            public void AnimalNoises()
            {
                Console.WriteLine("*happy animal nosises");
            }
        }
        class Dog : Animal
        {
            public int nuberOfPupies;
            public string race;

            public void AnimalNoises()
            {
                Console.WriteLine("Woof woof");
            }

            //public override void AnimalNoises() 
            //{
            //    Console.WriteLine("Woof");
            //    int x = 123458;
            //    Console.WriteLine(x);   
            
            //}

        }
        static void Main(string[] args)
        {                            
            Dog newDog = new Dog();
            newDog.name = "Fido";
            newDog.race = "Bulterier";
            newDog.AnimalNoises();
            Console.WriteLine($"{newDog.name}, {newDog.race}");
            newDog.AnimalNoises();





         Console.ReadKey();
        }
    }
}
