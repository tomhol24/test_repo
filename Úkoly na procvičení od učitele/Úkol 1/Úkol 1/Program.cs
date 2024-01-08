using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Úkol_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Napiš číslo:");
            //int number1 = int.Parse(Console.ReadLine());
            //Console.WriteLine("Napiš další číslo:");
            //int number2 = int.Parse(Console.ReadLine());

            //int sum = number1 + number2;
            //Console.WriteLine(sum);

            //int sub = number1 - number2;
            //Console.WriteLine(sub);

            //int multiply = number1 * number2;
            //Console.WriteLine(multiply);

            //float divide = number1 / (float)number2; //aby to fungovalo tak jedna z numberek taky musí být float -> díky tomu se výsledek nezaokrouhlí
            //Console.WriteLine(divide);

            //int power1 = number1 * number1;
            //int power2 = number2 * number2;
            //Console.WriteLine(power1);
            //Console.WriteLine(power2);

            //double val1 = number1;
            //double val2 = number2;
            //Console.WriteLine(Math.Sqrt(val1));
            //Console.WriteLine(Math.Sqrt(val2));

            //if (sum > 0)
            //{
            //    Console.WriteLine("Součet je kladný");
            //}
            //else
            //{
            //    Console.WriteLine("Součet je záporný");
            //}

            //if (sub > multiply)
            //{
            //    Console.WriteLine("Rozdíl je větší než násobek");
            //}
            //else
            //{
            //    Console.WriteLine("Rozdíl je menší než násobek");
            //}

            //if (sum > sub && multiply > divide)
            //{
            //    Console.WriteLine("Podmínka platí");
            //}
            //else
            //{
            //    Console.WriteLine("Podmínka neplatí");
            //}
            

            int i = 0;
            int[] myArray = new int[5];            
             
            Console.WriteLine("Napiš číslo aby si pokračoval nebo stop aby si skončil");

            while (i < myArray.Length)
            {     
                string text = Console.ReadLine();   
                
                if (int.TryParse(text, out int cislo))
                {
                    myArray[i] = cislo;
                    i++;
                    Console.WriteLine("Uživatel napsal číslo");
                }
                else if (text == "stop")
                {
                    i = myArray.Length + 1;
                    Console.WriteLine("Uživatel napsal stop");
                }
                else
                {
                    i = myArray.Length + 1;
                    Console.WriteLine("Uživatel napsal písmeno");
                }

                if (i == myArray.Length - 1) 
                {
                    Console.WriteLine("Napši poslední číslo");
                }
            }
            Console.WriteLine("Už psát nemusíš");
            Console.Write("Pole obsahuje tato čísla: ");
            for (i = 0; i < myArray.Length; i++) 
            {
                Console.Write($"{myArray[i]},");
            }           
            Console.ReadKey();
        }
    }
}
