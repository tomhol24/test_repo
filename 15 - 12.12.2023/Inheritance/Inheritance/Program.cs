using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
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
        
            public void AnimalNoises () 
            {
                Console.WriteLine("Woof woof");            
            }
        
     }

        static void Main(string[] args) 
        { 
         Dog newDog = new Dog();
            newDog.name = "Fido";
            newDog.race = "Bulterier"
            newDog.AnimalNoise();
            Console.WriteLine($"{newDog.name}, {newDog.race}");
            newDog.AnimalNoises();
        }




    }
