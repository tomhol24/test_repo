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
            //CardDeck player = new CardDeck("player");           
            //CardDeck dealer = new CardDeck("dealer");           
            //CardDeck player = new CardDeck("player");                                 
            //dealer.PrintPlayer(); // odkážu se na classu, pak na funkci          
            //Console.WriteLine("Napište ano nebo ne pro přičtění čísla.");
            //CardDeck decision = new CardDeck(Console.ReadLine()); //jakt o udělám
            

            Player dealer = new Player("dealer");            
            Player player = new Player("player");

            //dealer.JoinedTheGame();
            //player.JoinedTheGame();

            dealer.DealCard();
            player.DealCard();
            player.DealCard();
            dealer.ShowHand();
            player.ShowHand();


            Console.ReadKey();
        }
    }
}
