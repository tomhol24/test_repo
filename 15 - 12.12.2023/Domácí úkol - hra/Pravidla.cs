using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domácí_úkol___hra
{
    internal class Pravidla
    {
        public int wallet;
        public int wallet2;
        public int bank;
        public int bank2;
        public int playerHand = 0;
        public int dealerHand1 = 0;        
        public int amountBet;
        public int amountWon;
        public int cardDeck2;
        public int cardDeck3;   
        public int deathCheck;
        

        public void Wallet()
        {
            wallet = 1000;
        }       
        public void PrintWallet() //Hotovo
        {
            Console.WriteLine($"Stav peněženky: {wallet2} Kč");
        }



        public void Bank() //Hotovo
        {
            bank = 2 * wallet;
            PrintBank();
        }
        public void PrintBank() //Hotovo
        { 
            Console.WriteLine($"Stav banku: {bank} Kč");
        }



        public void Won() //Hotovo
        {
            Console.WriteLine();
            Console.WriteLine("Výhra");
            Console.WriteLine();
            
            amountWon = amountBet * 2;
            wallet2 += amountWon;
            bank -= (amountBet);
            
            PrintBank();
            PrintWallet();    
        }
        public void GameOver() //Hotovo
        { 
            Console.WriteLine();
            Console.WriteLine("Je nám líto, ale prohrál jste.");
            Console.WriteLine();

            bank += amountBet;
                       
            PrintBank();            
            PrintWallet();            
        }



        public void Bet() //Hotovo
        {
            Console.WriteLine();
            Console.WriteLine($"Obsah vaší peněženky: {wallet} Kč");
            Console.WriteLine();
            Console.WriteLine("Zadejte sázku:");
            Console.WriteLine();    
            amountBet = Convert.ToInt32(Console.ReadLine());
            

            if (amountBet < wallet)
            {
                Console.WriteLine();
                Console.WriteLine("Vaše sázka proběhla úspěšně");
                Console.WriteLine();

                wallet2 = wallet - amountBet;
            }
            while (amountBet > wallet)
            {                
                Console.WriteLine($"Vsadili jste více peněž než máte k dispozici: {wallet} Kč");
                Console.WriteLine("Zadejte sázku:");
                Console.WriteLine();

                amountBet = Convert.ToInt32(Console.ReadLine());
            }            
        }
        


        public void CardDeck() //Hotovo
        {                                 
            Random random1 = new Random();

            for (int i = 1; i <= 2; i++)
            {                
                int numpl = random1.Next(1,12);

                Console.WriteLine();
                Console.WriteLine($"Balíček vylosoval hráčovi číslo: {numpl}");
                
                playerHand += numpl;
               
            }
            Console.WriteLine();
            Console.WriteLine($"Hráčova ruka: {playerHand}");

            CardDeckDealer();           
        }
        public void CardDeck2()
        {            
            Random random2 = new Random();
            cardDeck2 = random2.Next(1, 12);

            Console.WriteLine();
            Console.WriteLine($"Balíček vylosoval číslo: {cardDeck2}");

            dealerHand1 += cardDeck2;

            Console.WriteLine();
            Console.WriteLine($"Dealerova ruka: {dealerHand1}");

        }
        public void CardDeckDealer() //Hotovo
        { 
            Random random3 = new Random();
                                       
            int numdl = random3.Next(1, 12);


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Balíček vylosoval dealerovi číslo: {numdl}");
            Console.WriteLine();

            dealerHand1 += numdl;

            Console.WriteLine($"Dealerova ruka: {dealerHand1}");

            numdl = random3.Next(1, 12);
            dealerHand1 += numdl;                           
        }
        public void CardDeck3()
        {
            Random random4 = new Random();
            cardDeck3 = random4.Next(1, 12);

            Console.WriteLine();    
            Console.WriteLine($"Balíček vylosoval číslo: {cardDeck3}");

            playerHand += cardDeck3;

            Console.WriteLine();
            Console.WriteLine($"Hráčova ruka: {playerHand}");
        }



        public void DeathOrWinCheck() //Hotovo
        {
            switch (playerHand)
            {
                case 21:
                    {
                        Won();
                        break;
                    }
                case var _ when playerHand > 21: //chat gpt
                    {
                        GameOver();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }    
        


        public void HitPass() 
        {
            Console.WriteLine();
            Console.WriteLine("Chete dále táhnout?");
            Console.WriteLine();

            string decidion = Console.ReadLine();


            switch(decidion.ToLower())//ToLower převede na malá písmena, tohle jsem dostal od chatu gpt a přijde mi to geniální -> ušetřím casy a usnadní mi to život
            {
                case "ano": //odstranit to Chcete dále táhnout po prohře nebo výhře
                {                       
                    CardDeck3();                                                                        
                    DeathOrWinCheck();

                    if (playerHand < 21) 
                    {                  
                        Console.WriteLine();
                        Console.WriteLine("Chcete dále táhnout?");
                        decidion = Console.ReadLine(); 
                        
                        while (decidion.ToLower() == "ano")
                        {                           
                            CardDeck3();                                                        
                            DeathOrWinCheck();

                            if (playerHand < 21) 
                            {                                
                                Console.WriteLine();
                                Console.WriteLine("Chcete dále táhnout?");
                                decidion = Console.ReadLine();
                            }
                        }                            
                    }                                            
                break;
                } 
                default: 
                {
                    Console.WriteLine("Na tahu je Dealer");
                    break;
                }
            }
        } 
        


        public void DealerRound() 
        {
            Console.WriteLine($"Dealerova ruka je: {dealerHand1}");
            switch (dealerHand1)
            {
                case 21: //Mělo by být v pořádku
                {
                    Console.WriteLine("Dealer měl v prvním tahu přesně 21.");
                    GameOver();
                    break;
                }
                case var _ when dealerHand1 > 21: //Mělo by být v pořádku
                {
                    Console.WriteLine("Dealer měl v prvním tahu více než 21.");
                    Won();
                    break;
                }
                case var _ when dealerHand1 <= 16:
                {
                    CardDeck2();

                    if (dealerHand1 == 21)
                    {
                        Console.WriteLine("Dealer měl ve druhém tahu přesně 21.");
                        GameOver();
                    }
                    else if (dealerHand1 > 21) 
                    {
                        Console.WriteLine("Dealer měl ve druhém tahu více než 21.");
                        Won();                       
                    }
                    else if (dealerHand1 > playerHand)
                    {
                        Console.WriteLine("Dealer měl ve druhém tahu hodnotu ruky vyšší než hráč.");
                        GameOver();
                    }
                    else if (playerHand > dealerHand1)
                    {
                        Console.WriteLine("Dealer měl ve druhém tahu hodnotu ruky nižší než hráč.");
                        Won();                                             
                    }
                    break;
                }
                case var _ when dealerHand1 >= 17 && dealerHand1 < 21: 
                {
                    if (dealerHand1 > playerHand)
                    {
                        Console.WriteLine("Dealer měl v prvním tahu hodnotu ruky vyšší než hráč.");
                        GameOver();
                    }
                    else if (dealerHand1 < playerHand)
                    {
                        Console.WriteLine("Dealer měl v prvním tahu hodnotu ruky nižší než hráč.");
                        Won();
                    }
                    break; 
                }
            }           
        }       
    }
}