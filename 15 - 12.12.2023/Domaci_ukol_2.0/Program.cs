using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domaci_ukol_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CardDeck player = new CardDeck("player");           
            CardDeck dealer = new CardDeck("dealer");
            dealer.PrintPlayer(); // odkážu se na classu, pak na funkci
            

            Console.WriteLine("Napište ano nebo ne pro přičtění čísla.");
            CardDeck decision = new CardDeck(Console.ReadLine()); //jakt o udělám
            


            Console.ReadKey();
        }
    }
}
