//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Domaci_ukol_2._0
//{
//    internal class CardDeck
//    {
//        //tady si zadefinuji vše s čím budu pracovat
//        public int hand;
//        public string who;
//        public string decision;
//        Random random; 
//        //Udělat si funkci give card (bude dávat jednu) a další funkci print card
//        //Pro práci mezi třídama -> zavolám si třídu nahoře a pak se na ní odkazuji tak že dám název a funkci 

//        //Jestli to musím mít všechno ve funkcích nebo jestli to musím mít v tom public Třída
//        public CardDeck(string who)//jestli je nutný tady ten string, jaký je rozdíl mezi this.xxx a xxx
//        {
//            this.who = who;
//            random = new Random(); //v konstruktoru nechat jen tyhle dva řádky
//            if (who == "player") //tohle celé dát do třídy 
//            {
//                for (int i = 1; i <= 2; i++)
//                {
//                    int numrd = random.Next(1, 12);  //Jestli se nexty dají stakovat na sebe

//                    Console.WriteLine();
//                    Console.WriteLine($"Balíček vylosoval {who} číslo: {numrd}");

//                    this.hand += numrd;
//                    Thread.Sleep(1);
//                }
//            }           
//            else if (decision == "ano") // Jak bych tohle mohl dát do podmínky jestli to vůbec jde 
//            {
//                int numrd = random.Next(1, 12);

//                Console.WriteLine();
//                Console.WriteLine($"Balíček vylosoval {who} číslo: {numrd}");

//                //player += numrd;
//            }
//            Console.WriteLine();
//            Console.WriteLine($"{who} ruka: {this.hand}");
//        }
//        public void PrintPlayer() //Jestli to mohu vůbec udělat
//        {
//            Console.WriteLine($"{who} ruka: {this.hand}");
//        }
//    }
//}
