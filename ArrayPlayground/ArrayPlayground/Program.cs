using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace ArrayPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové pole a naplň ho pěti čísly. [ ] 
            int[] myArray = { 10, 20, 30, 40, 50};

            //TODO 2: Vypiš do konzole všechny prvky pole, zkus klasický for, kde i využiješ jako index v poli, a foreach (vysvětlíme si).
            Console.WriteLine("Vypsání for cyklem");

            for (int i = 0; i < myArray.Length ; i++)  //podmínka do kdy mi má forcyklus jet, i++ icko se zvetsi o jedna, i<5 dokud je i mensi nez 5, myArray.Lenght pro délku pole-> kdyz delam pres cele pole
            {
                Console.WriteLine(myArray[i]);
            }
            Console.WriteLine("\nVypsání foreachem:");

            foreach (int number in myArray) //pro kazdou integerovou promennou number v mem poli tak delej neco,mám pole for cyklus který jede por každou hodnotu v poli každou hodnotu v cyklu já chyci aby mi ten prvek aby ho ten prvek uložilo jako integerovou proměnnnou number, for echa projde od začátku do konce všechny
            {
                Console.WriteLine(number);
            }
            //TODO 3: Spočti sumu všech prvků v poli a vypiš ji uživateli.
            float sum = 0;
            for (int i = 0; i < myArray.Length; i++) 
            {
                sum += myArray[i]; // += je k sum přičti myArray na indexu i, to samé existuje také s -=, nebo *=
                //sum = + myArray[i];
            }
            Console.WriteLine("Suma: " + sum);
            
            //TODO 4: Spočti průměr prvků v poli a vypiš ho do konzole.
            float average = sum / myArray.Length;
            Console.WriteLine("Průměr: " + average);


            //TODO 5: Najdi maximum v poli a vypiš ho do konzole.
            float max = 0;
            max = myArray.Max();
            Console.WriteLine("Maximum: " + max); //to samé co ($"Maximum: {max}")

            //TODO 6: Najdi minimum v poli a vypiš ho do konzole.
            float min = int.MaxValue; //začnu na vélkém a pak koukám jestli něco není menší, minimum na začátku co největší abych jej potom mohl snižovat
            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] < min)
                {
                    min = myArray[i];
                }
            }
            Console.WriteLine("Minimum: " + min);

            //TODO 7: Vyhledej v poli číslo, které zadá uživatel, a vypiš index nalezeného prvku do konzole.        
            float userNumber = int.Parse(Console.ReadLine());
            bool foundNumber = false;

            for(int i = 0; i < myArray.Length; i++) 
            {
                if (userNumber == myArray[i]) 
                {
                    foundNumber = true;
                    Console.WriteLine($"Hledané číslo: {userNumber} je na indexu {i}");
                    break; //utneme jej dřív než by se utnul sám
                }
            }   
            if (foundNumber == false) 
            {
                Console.WriteLine($"Hledané číslo {userNumber} v seznamu neexistuje.");
            }

            //TODO 8: Změň tvorbu integerového pole tak, že bude obsahovat 100 náhodně vygenerovaných čísel od 0 do 9. Vytvoř si na to proměnnou typu Random.
            Random rng = new Random();
            myArray = new int[100];
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = rng.Next(0, 10); //10 není zahrnutá
                //Console.WriteLine("Na indexu {0}", i);
            }

            //TODO 9: Spočítej kolikrát se každé číslo v poli vyskytuje a spočítané četnosti vypiš do konzole.
            int[] counts = new int[10];
            foreach (int number in myArray)
            {
                counts[number]++;
            }
            for (int i = 0; i < counts.Length; i++)
            {
                Console.WriteLine($"Číslo {i} se vyskytuje {counts[i]} krát.");
            }
            //TODO 10: Vytvoř druhé pole, do kterého zkopíruješ prvky z prvního pole (myArray) v opačném pořadí.
            int[] mySecondArray = new int[100];  
            for(int i = mySecondArray.Length - 1;i >= 0; i--) //-1 protože v tom poli se indexuje od nuly
            {
                mySecondArray[i] = myArray[99 -i ];
            }

            Console.WriteLine("První pole");
            foreach (int number in myArray)
            { 
               Console.WriteLine(number);
            }
            Console.WriteLine("Druhé pole");
            foreach (int number in myArray)
            {
                Console.WriteLine(number);
            }











            Console.ReadKey();
        }
    }
}
