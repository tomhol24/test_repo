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

        public int valueOfDrawnCardPlayer;
        public int valueOfDrawnCardDealer;




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
        private List<(Cards, Colors)> Hand { get; set; } = new List<(Cards, Colors)>(); //Vytváří List(seznam) s položkami, které jsou uspořádanými dvojicemi obsahujícími hodnoty enumu (Cards and Colors). Tento seznam reprezentuje ruku hráče, každá položka představuje vylosovanu kartu a její barvu. Pak je tam iniciovaný Hand jako nový prázdný seznam aby byl připraven na ukládání karet.
        private Dictionary<Cards, int> valuesOfDrawnCards = new Dictionary<Cards, int> //Vytváří slovník, který páruje hodnoty enumu (Cards) s odpovídajícími celočíselnými hodnotami, Tento slovník bude sloužit k přiřazování hodnot vylosovaným kartám, kdy klíčem bude typ karty a hodnotou její číselná hodnota.
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

            Cards drawnCard = (Cards)card; //Přetypování hodnoty card na enum Cards. Toto přetypování převede číselnou hodnotu odpovídající hodnotě enumu Cards.
            Colors drawnColor = (Colors)typeOfCard; //Přetypování hodnoty typeOfCard. To převede číselnou hodnotu na odpovídající hodnotu enumu Colors.
            Hand.Add((drawnCard, drawnColor)); //vytváří novou dvojici (tuple) a přidává ji do seznamu Hand. Tato dvojice reprezentuje právě vylosovanou kartu s odpovídající barvou.

            valueOfDrawnCard = valuesOfDrawnCards[drawnCard]; //Přistupuje to ve k hodnotě ve slovníku valuesOfDrawnCards pomocí klíče drawnCard a přiřazuje enum Cards. DrawCard je hodnota enumu Cards, která byla předchozím k=odem vylosována a přidána do seznamu Hand. ValuesOfDrawnCards je slovník který mapuje hodnoty enumu Cards na odpovídající číselné hodnoty. ValuesOfDrawnCard je proměnná do které je přiřazena číselná hodnota vylosované karty.


            if (name == "player")
            {
                Console.WriteLine($"{name} drew: {drawnCard} of {drawnColor}, value of this card is: {valueOfDrawnCard}");
                this.valueOfDrawnCardPlayer += valueOfDrawnCard;
            }
            else if (name == "dealer") 
            {
                this.valueOfDrawnCardDealer += valueOfDrawnCard;
            }
        }



        //END OF THE CARD DECK
        public void PrintIt() //Autor: já
        {
            if (name == "player") 
            {
                Console.WriteLine();
                Console.ForegroundColor= ConsoleColor.Magenta;
                Console.WriteLine($"Total value of player's drawn cards in hand is: {valueOfDrawnCardPlayer}");
                Console.ResetColor();
            }
            else if (name == "dealer") 
            {
                Console.WriteLine();
                Console.WriteLine($"Total value of dealer's drawn cards in hand is: {valueOfDrawnCardDealer}");
                Console.WriteLine();
            }
            
        }

        public void ShowHand() //AUTOR: JÁ
        {
            Console.WriteLine($"{name} drew: {(Cards)card} of {(Colors)typeOfCard}, value of this card is: {valueOfDrawnCard}");            
        }
    }
}
