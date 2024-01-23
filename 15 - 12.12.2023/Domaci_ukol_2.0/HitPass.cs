using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domaci_ukol_2._0
{
    internal class Player
    {
        public string name;
        public int wallet;
        public int card;
        public int hand;
        public Player(string name) 
        { 
            this.name = name;
            hand = 0;
            wallet = 1000;
        }        
        public void DealCard() // volám 2x u playera a 1x u dealera
        {
            Random random = new Random();
            card = random.Next(1, 11);
            hand += card;
            Console.WriteLine($"{name} got a card:{card}");
            Thread.Sleep(1);
        }
        public void ShowHand()
        {
            Console.WriteLine($"{name}'s hand equals to:{hand}");
        }        
    }
}
