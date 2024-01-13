using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Domácí_úkol___hra.Programme;

namespace Domácí_úkol___hra
{
    internal class Players
    {       
        //AUTOR: já
        public string name;        
        public int card;
        public int hand;
        public int typeOfCard;
        public int valueOfDrawnCard;
        public int drawnCard;
        public int drawnColor;
        Random random;
       
        //AUTOR: já
        public enum Cards
        {
            Ace,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
        }
        public enum Colors
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades,
        }
        
        //AUTOR: já + CHAT gpt
        private List<(Cards, Colors)> Hand { get; set; } = new List<(Cards, Colors)>(); 
        private Dictionary<Cards, int> valuesOfDrawnCards = new Dictionary<Cards, int>
        {
            { Cards.Ace, 1 },
            { Cards.Two, 2 },
            { Cards.Three, 3 },
            { Cards.Four, 4 },
            { Cards.Five, 5 },
            { Cards.Six, 6 },
            { Cards.Seven, 7 },
            { Cards.Eight, 8 },
            { Cards.Nine, 9 },
            { Cards.Ten, 10 },
            { Cards.Jack, 10 },
            { Cards.Queen, 10 },
            { Cards.King, 10 }
        };



        //BEGINING OF THE TEMPLATE FOR PLAYER/DEALER -> autor: já
        public Players(string name)
        {            
            this.name = name;
            hand = 0;
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{name} was created.");
            Console.ResetColor();
        }
        //END OF THE TEMPLATE FOR PLAYER/DEALER



        //BEGINING OF THE CARD DECK -> autor: já + chat gpt
        public void DealCard()
        {
            random = new Random();
            card = random.Next(13);
            typeOfCard = random.Next(4);
            Thread.Sleep(1);

            Cards drawnCard = (Cards)card;
            Colors drawnColor = (Colors)typeOfCard;
            Hand.Add((drawnCard, drawnColor));

            valueOfDrawnCard = valuesOfDrawnCards[drawnCard];
            

            if (name == "player")
            {
                Console.WriteLine($"{name} drew: {drawnCard} of {drawnColor}, value of this card is: {valueOfDrawnCard}");                
            }         
        }
        //END OF THE CARD DECK



        //BEGINING OF CALCULATION OF THE TOTAL VALUE -> autor: chat gpt + já

        //private int soucetTahu = 0;

        //public int CalculateHandValue(bool resetSoucet = false)
        //{
        //    if (resetSoucet)
        //    {
        //        soucetTahu = 0;
        //    }

        //    foreach (var karta in Hand)
        //    {
        //        soucetTahu += valuesOfDrawnCards[karta.Item1];
        //    }

        //    Console.WriteLine($"Total value of drawn cards in hand is: {soucetTahu}");
        //    return soucetTahu;
        //}

        public int CalculateHandValue()
        {
            foreach (var karta in Hand)
            {
                hand += valuesOfDrawnCards[karta.Item1];
            }
            Console.WriteLine($"Total value of drawn cards in hand is: {hand}");
            return hand;
        }
        //END OF CALCULATION OF THE TOTAL VALUE



            public void ShowHand() //AUTOR: JÁ
        {
            Console.WriteLine($"{name} drew: {(Cards)card} of {(Colors)typeOfCard}, value of this card is: {valueOfDrawnCard}");            
        }
    }
}
