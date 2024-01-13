//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Domaci_ukol_2._0
//{
//    internal class CardDeck
//    {       
//        public string who;        
//        public int cardValue;
//        public int type;
//        Random random;

//        public CardDeck(string who) 
//        {
//            this.who = who;
//            random = new Random();
//        }
//        public CardDeck()
//        {
//            DealCard();
//            Type();
//            Console.WriteLine($"You pulled{cardValue}of{type}");
//        }
//        public object DealCard()
//        {
//            int cardValue = random.Next(1, 14);

//            switch (cardValue)
//            {
//                case 1:
//                    return "Ace";
//                case 11:
//                    return "Jack";
//                case 12:
//                    return "Queen";
//                case 13:
//                    return "King";
//                default:
//                    throw new InvalidOperationException("Unexpected card value");
//            }
//        }
//        public object Type()
//        {
//            int type = random.Next(0, 4);

//            switch (type)
//            {
//                case 0:
//                    return "hearts";
//                case 1:
//                    return "diamonds";
//                case 2:
//                    return "spades";
//                case 3:
//                    return "clubs";
//                default:
//                    throw new InvalidOperationException("Unexpected card type");
//            }
//            return type;
//        }
//        public int GetCardValue()
//        {
//            return cardValue;
//        }

//        public string GetCardType()
//        {
//            return type;
//        }
//    }
//}
