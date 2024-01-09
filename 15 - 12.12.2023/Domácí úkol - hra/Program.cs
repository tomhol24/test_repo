using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domácí_úkol___hra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pravidla game1 = new Pravidla();

            game1.Wallet();
            game1.Bet();
            game1.Bank();
            game1.CardDeck();
            game1.DeathOrWinCheck();
            game1.HitPass();
            game1.DealerRound();
            

                    
            Console.ReadKey();
        }
    }
}
