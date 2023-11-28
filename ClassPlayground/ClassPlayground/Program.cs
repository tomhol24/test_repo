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
        class Human
        {
            //Vytvářím obecnou šablonu
            private int age;//public je přístupový modifikátor
                            //Jsou dva základní - privat, public a pak je ještě protected
                            //U neoznačených věcí je automaticky privat
                            //Privat -> není vidět z venku, Public -> je vidět z venku, Protected -> dědí trošku z obou (je to jejich mezistupe
            public float height;
            public float weight;
            public string name;
            public string hairColour;
            public string eyeColour;

            public Human(int age, float height, float weight) //konstruktor třídy, co se má stát když si vytvářím nového člověka, všechny třídy mají v základu prázdný konstruktor
            {
                this.age = age;
                this.height = height; //rozlišuji pomocí "this", mezi tím nahoře a v tomto konstruktoru
                this.weight = weight;

                hairColour = "Neznámá";
                eyeColour = "Neznámá";
                name = "Neznámá";


            }

            public Human(int age, float height, float weight, string hairColour, string eyeColour, string name) //na každého humana potřebuji nový konstruktor
            {
                this.age = age;
                this.height = height; //rozlišuji pomocí "this", mezi tím nahoře a v tomto konstruktoru
                this.weight = weight;
                this.hairColour = hairColour;
                this.eyeColour = eyeColour;
                this.name = name;
            }

            public void PrintCharacterictics()
            {
                string printedName = name;
                if (printedName == null)
                {
                    printedName = "Bezejmenný člověk";
                }
                Console.WriteLine(($"{name} je starý {age} let a měří {height} cm"));
            }

            public float BMI()
            {
                float heightForCalculation = height / 100f;
                float bmi = (float)weight / (heightForCalculation) * (heightForCalculation);
                return bmi;
            }

            public int GetAge() //k vrácení co ve třídě privat
            {
                return age;
            }

            public void SetAge(int age) //Ohraničení zadávané hodnoty, explicitně říkám zadej mi integer -> nic jihéno neberu
            {
                if (age < 0 || age > 120) 
                {
                    Console.WriteLine("Tento věk není možné zadat");
                }
                else 
                { 
                    this.age = age;
                }            
            }

            public void SetAge(string age) 
            {
                //this.age = int.Parse(age); 
                bool isNumber = int.TryParse(age, out int ageNumber);
                if (isNumber) 
                {
                    this.age = ageNumber;
                    Console.WriteLine($"Věk člověka {name} změněn na {ageNumber}");
                }
                else 
                {
                    Console.WriteLine("Stupid, zadej číslo troubo!");
                }
            }
      }
        static void Main(string[] args)
        {
            Human human1 = new Human(32, 165, 65); //Vytvořil jsem instanci třídy
            //human1.age = 32; -> tohle tu nemusí být protože už je to definované nahoře přes konstruktor
            //human1.height = 165;
            //human1.weight = 65;           
            //human1.hairColour = "Brown";
            //human1.eyeColour = "Green";
            human1.name = "Karel";
            human1.PrintCharacterictics();
            

            Human human2 = new Human(18, 205, 90, "Brown", "Blue", "Lojza");           
            human2.PrintCharacterictics();
            float bmi = human2.BMI();
            Console.WriteLine(($"{human2.name} má BMI {bmi}"));


            Human human3 = new Human(10, 130, 80);
            human3.PrintCharacterictics();
            human1.name = "Franta";
            Console.WriteLine(($"Dítě má BMI {bmi}"));


            Console.WriteLine(human1.GetAge());
            human1.SetAge(50);
            Console.WriteLine(human1.GetAge());
            human1.SetAge(360);
            human1.SetAge("20");
            human1.PrintCharacterictics();
            human1.SetAge("HAHAHA");
            human1.PrintCharacterictics();


            Console.ReadKey();
        }
    }
}
