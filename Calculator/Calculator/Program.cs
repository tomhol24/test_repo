using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */


namespace Calculator
{
   
    internal class Program
    {
        private static bool IsNumeric(string input) //chat GPT
        {
            return float.TryParse(input, out _);
        }
        static bool operaceBez0 = true;
        static float Soucet(float x, float y)  //učitel
        {
            float result = x + y;
            return result;
        }
        static float Rozdil(float x, float y) //sám
        {
            float result = x - y;
            return result;
        }
        static float Soucin(float x, float y) //sám
        {
            float result = x * y;
            return result;
        }
        static float Podil(float x, float y) //s pomocí přítele na telefonu
        {
            if (y == 0)
            {
                Console.WriteLine("Nelze dělit nulou");
                operaceBez0 = false;
                return 0;
            }
            float result = x / y;
            return result;
        }
        static float Mocneni(float x, float y) //s pomocí přítele na telefonu
        { 
           float result = (float)Math.Pow(x,y);
           return result;
        }
        static float Odmocneni(float x, float y) //s pomocí přítele na telefonu
        {
            float result = (float)Math.Pow(x, 1/y);
            return result;
        }
        static float Logaritmus(float x, float baseValue) //s pomocí Chat GPT
        {
            float result = (float)Math.Log(x, baseValue);
            return result;
        }
        static float Sinus(float x) //s pomocí přítele na telefonu a chatu GPT
        {
            double uhelVeStupnich = x;
            double uhelVRadianech = uhelVeStupnich * (Math.PI / 180.0);
            double sinusVysledek = Math.Sin(uhelVRadianech);
            if (Math.Abs(sinusVysledek) < 1e-6)
            {
                return 0f;
            }
            return (float)sinusVysledek;
        }
        static float Cosinus(float x) //s pomocí přítele na telefonu a chatu GPT
        {
            double uhelVeStupnich = x;
            double uhelVRadianech = uhelVeStupnich * (Math.PI / 180.0);
            double cosinusVysledek = Math.Cos(uhelVRadianech);
            if (Math.Abs(cosinusVysledek) < 1e-6)
            {
                return 0f;
            }
            return (float)cosinusVysledek;
        }
        static float Tangens(float x) //s pomocí přítele na telefonu a chatu GPT
        {
            double uhelVeStupnich = x;
            double uhelVRadianech = uhelVeStupnich * (Math.PI / 180.0);
            double tangensVysledek = Math.Tan(uhelVRadianech);
            if (x == 90)
            {
                Console.WriteLine("SYNTAX ERROR");
                operaceBez0 = false;
                return 0;
            }
            else if (x == 270)
            {
                Console.WriteLine("SYNTAX ERROR");
                operaceBez0 = false;
                return 0;
            }
            return (float)tangensVysledek;
        }
        static float Cotangens(float x) //s pomocí přítele na telefonu a chatu GPT
        {
            double uhelVeStupnich = x;
            double uhelVRadianech = uhelVeStupnich * (Math.PI / 180.0);
            double cotangensVysledek = Math.Tan(uhelVRadianech);
            if (x == 0)
            {
                Console.WriteLine("SYNTAX ERROR");
                operaceBez0 = false;
                return 0;
            }
            else if (x == 180)
            {
                Console.WriteLine("SYNTAX ERROR");
                operaceBez0 = false;
                return 0;
            }
            else if (x == 360)
            {
                Console.WriteLine("SYNTAX ERROR");
                operaceBez0 = false;
                return 0;
            }
            return (float)(1 / cotangensVysledek);
        }
        
        static void Main(string[] args)
        {
            /*
             * Pokud se budes chtit na neco zeptat a zrovna budu pomahat jinde, zkus se zeptat ChatGPT ;) - https://chat.openai.com/
             * 
             * ZADANI
             * Vytvor program ktery bude fungovat jako kalkulacka. Kroky programu budou nasledujici:
             * 1) Nacte vstup pro prvni cislo od uzivatele (vyuzijte metodu Console.ReadLine() - https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=netframework-4.8.
             * 2) Zkonvertuje vstup od uzivatele ze stringu do integeru - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number.
             * 3) Nacte vstup pro druhe cislo od uzivatele a zkonvertuje ho do integeru. (zopakovani kroku 1 a 2 pro druhe cislo)
             * 4) Nacte vstup pro ciselnou operaci. Rozmysli si, jak operace nazves. Muze to byt "soucet", "rozdil" atd. nebo napr "+", "-", nebo jakkoliv jinak.
             * 5) Nadefinuj integerovou promennou result a prirad ji prozatimne hodnotu 0.
             * 6) Vytvor podminky (if statement), podle kterych urcis, co se bude s cisly dit podle zadane operace
             *    a proved danou operaci - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements.
             * 7) Vypis promennou result do konzole
             * 
             * Mozna rozsireni programu pro rychliky / na doma (na poradi nezalezi):
             * 1) Vypis do konzole pred nactenim kazdeho uzivatelova vstupu co po nem chces
             * 2) a) Kontroluj, ze uzivatel do vstupu zadal, co mel (cisla, popr. ciselnou operaci). Pokud zadal neco jineho, napis mu, co ma priste zadat a program ukoncete.
             * 2) b) To same, co a) ale misto ukonceni programu opakovane cti vstup, dokud uzivatel nezada to, co ma
             *       - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement
             * 3) Umozni uzivateli zadavat i desetinna cisla, tedy prekopej kalkulacku tak, aby umela pracovat s floaty
             */
            bool exitRequested = false; //chat GPT
      while (!exitRequested) //chat GPT
      { 
            float a; //definice hodnoty
            float b;
            float result = 0f; //result jsem si nastavil na nulu
            bool validInput = false;
        while (!validInput) //sám
        { 
          try //z chatu GPT
          { 
            Console.WriteLine("Napiš první číslo"); //text napíšu do uvozovek protože je to prostě text
            string vstup = Console.ReadLine(); //přečte řádek z konzole a uloží do proměnné vstup

                        if (string.IsNullOrWhiteSpace(vstup)) //chat GPT
                        {
                            exitRequested = true;
                            break;
                        }
                        // Kontrola, zda uživatel zadal pouze čísla
                        if (!IsNumeric(vstup))
                        {
                            Console.WriteLine("Zadávejte pouze čísla.");
                            continue;  // Pokračujeme v dalším cyklu while pro opětovné zadání vstupu
                        }

            vstup = vstup.Replace('.', ','); //pro to když uživatel napíše desetinné číslo s tečkou aby se to neseklo a tečka se přeměnila na čárku
            a = float.Parse(vstup); //funkce parse zkonvertuje text do čísla, uživatel zadal první číslo
            Console.WriteLine("Napiš operaci +, -, *, /, na, z, log, sin, cos, tan, cotan");
            string operace = Console.ReadLine();    // uživatel zadal operaci
      
            if (operace == "sin") //sám
        { 
                result = Sinus(a);
        }
            else if (operace == "cos") //sám
            {
                result = Cosinus(a);
            }
            else if (operace == "tan") //sám
            {
                result = Tangens(a);
            }
            else if (operace == "cotan") //sám
            {
                result = Cotangens(a);
            }
            else //s pomocí přítele na telefonu a chatu GPT
            { 
                Console.WriteLine("Napiš druhé číslo");
                vstup = Console.ReadLine(); //pro zjištění co uživatel zadal, zadal druhé číslo
                vstup = vstup.Replace('.', ',');
                b = float.Parse(vstup);

                if (operace == "+") //sám
                {
                    result  = Soucet(a, b); 
                }         
                else if (operace == "-") //sám
                {
                    result = Rozdil(a, b);
                }
                else if (operace == "*") //sám
                {
                    result = Soucin(a, b);
                }
                else if (operace == "/") //sám
                {
                    result = Podil(a, b);
                }
                else if (operace == "na") //sám
                {
                    result = Mocneni(a, b);
                }
                else if (operace == "z") //sám
                {
                    result = Odmocneni(a, b);
                }
                else if (operace == "log") //sám
                {
                    result = Logaritmus(a, b);
                }
                else  //sám
                    { 
                    Console.WriteLine("nevymýšlej si vlastní operace");
                    }
}
            if (operaceBez0 == true) 
            { 
                Console.WriteLine("Vysledek je " + result);
            }
            else 
            {
                Console.WriteLine("Operaci nelze vyřešit");
            }
            validInput = true;
                    }
            catch (FormatException) //chat GPT
            {
                Console.WriteLine("Chybný vstup. Zadejte platné číslo.");
            }
            catch (Exception ex) //chat GPT
            {
                Console.WriteLine("Došlo k neočekávané chybě: " + ex.Message);
            }
        
        }
                if (exitRequested) //chat GPT
                    break;

                if (validInput) //chat GPT
                {                 
                    Console.WriteLine("Pro ukončení stiskněte Enter. Pro zahájení nového příkladu stiskněte mezerník.");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                        exitRequested = true;
                }
      }
            Console.WriteLine("Ukonči entrem");
            Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.

        }
    }
}
