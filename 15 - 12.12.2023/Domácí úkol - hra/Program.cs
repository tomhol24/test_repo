using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domácí_úkol___hra
{
    internal class Program
    {        
        public int wallet;
        public int bank;        
        public int amountBet;
        public int temporary;
                        
        public void Won() //AUTOR: já
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("VICTORY");
            Console.WriteLine("horray!");
            Console.ResetColor();
            Console.WriteLine();
            
            wallet += amountBet;
            bank -= amountBet;

            PrintBank();
            PrintWallet();
        }        
        public void GameOver() //AUTOR: já
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER");
            Console.ResetColor();
            Console.WriteLine();

            wallet -= amountBet;
            bank += amountBet;

            PrintBank();
            PrintWallet();
        }

        public void PrintWallet() //AUTOR: já
        {
            Console.ForegroundColor= ConsoleColor.Magenta;
            Console.WriteLine($"Your wallet: {wallet} Kč");
            Console.ResetColor();
        }
        public void PrintBank() //AUTOR: já
        {
            Console.WriteLine($"Bank: {bank} Kč");
        }
        


        static void Main(string[] args)
        {
           //CREATION OF PLAYERS and other classes
            Players dealer = new Players("dealer");
            Players player = new Players("player");
            Program program = new Program();

            program.wallet = 1000;
            program.bank = 2 * program.wallet;

            string stopGame = "continue";

            string anotherRound;
            Console.WriteLine();
            Console.WriteLine("Do you wan to start the game? (Yes/No)");
            anotherRound = Console.ReadLine();

            while(anotherRound.ToLower() == "yes") //.ToLower -> mám to od chatu gpt (jen tuhle malou vychytávku jinak je to vše ode mě) a dělá to to že to přijatý text přepíše pouze na malá písmena
            {                                      
                player.valueOfDrawnCardPlayer = 0;
                dealer.valueOfDrawnCardDealer = 0;

                //BEGINING OF "BET"
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Amount of money in your wallet: {program.wallet} Kč");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Set your bet in CZK (Kč):");
                Console.WriteLine();
                program.amountBet = Convert.ToInt32(Console.ReadLine());

                if (program.amountBet < program.wallet)
                {
                    Console.WriteLine();
                    Console.WriteLine("Your bet was sucsessful");
                    Console.WriteLine();
                }
                else if (program.wallet < 0) //tohle by mělo vyhodit game over poté co v peněžence už nejsou peníze a ukončit celou hru
                {
                    program.GameOver();
                    anotherRound = "no";
                }
                while (program.amountBet > program.wallet)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Vsadili jste více peněž než máte k dispozici: {program.wallet} Kč");
                    Console.ResetColor();
                    Console.WriteLine("Zadejte sázku:");
                    Console.WriteLine();

                    program.amountBet = Convert.ToInt32(Console.ReadLine());
                }
                //END OF "BET"



                //START OF DEALING CARDS                                 
                Console.ForegroundColor = ConsoleColor.Magenta;
                player.DealCard();
                player.DealCard();
                player.PrintIt();
                Console.WriteLine();
                Console.ResetColor();

                Console.WriteLine();
                dealer.DealCard();
                dealer.ShowHand();
                Console.WriteLine();
                Console.ForegroundColor= ConsoleColor.Blue;
                dealer.PrintIt();
                Console.ResetColor();
                Console.WriteLine();                   
                //END OF DEALING CARDS



                //BEGINING OF HIT/PASS
                Console.WriteLine();
                Console.WriteLine("Do you want to draw another card? (Yes/No)");
                Console.WriteLine();
                string decidion = Console.ReadLine();

                switch (decidion.ToLower())
                {
                    case "yes":
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        player.DealCard();
                        player.PrintIt();
                        Console.ResetColor();
                                
                        //BEGINING OF DEATH OR WIN CHECK    
                        switch (player.valueOfDrawnCardPlayer)
                        {
                            case 21:
                            {
                                program.Won();
                                stopGame = "stop";
                                break;
                            }
                            case var _ when player.valueOfDrawnCardPlayer > 21: //chat gpt
                            {
                                program.GameOver();
                                stopGame = "stop";
                                break;
                            }
                            default:
                            {
                                decidion = "no";
                                break;
                            }

                        }
                        //END OF THE --> DEATH OR WIN CHECK

                        if (player.valueOfDrawnCardPlayer < 21)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Do you want to draw another card?");
                            decidion = Console.ReadLine();

                            while (decidion.ToLower() == "yes")
                            {
                                Console.ForegroundColor= ConsoleColor.Magenta;
                                player.DealCard();
                                player.PrintIt();
                                Console.ResetColor();
                                    
                                //BEGINING OF THE --> DEATHORWINCHECK
                                switch (player.valueOfDrawnCardPlayer)
                                {
                                    case 21:
                                    {
                                        program.Won();
                                        dealer.ShowHand();
                                        decidion = "ne";
                                        stopGame = "stop";
                                        break;
                                    }
                                    case var _ when player.valueOfDrawnCardPlayer > 21: //chat gpt
                                    {
                                        program.GameOver();
                                        dealer.ShowHand();
                                        stopGame = "stop";
                                        break;
                                    }
                                            
                                }
                                //END OF THE --> DEATH OR WIN CHECK

                                if (player.valueOfDrawnCardPlayer < 21)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Do you want to draw another card? (Yes/No)");
                                    decidion = Console.ReadLine();
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }

                        break;
                    }
                    case "no":
                    {
                        Console.WriteLine("Nevermind, let's continue.");
                        Console.WriteLine();
                        break;
                    }                       
                }
                //END OF HIT/PASS



                //BEGINING OF DEALER ROUND                              
                if (stopGame != "stop") 
                { 
                    Console.WriteLine("Dealer's second card is:");
                    Console.WriteLine();
                    dealer.DealCard();
                    dealer.ShowHand();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    dealer.PrintIt();
                    Console.ResetColor();

                    switch (dealer.valueOfDrawnCardDealer)
                    {
                        case 21:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Dealer's had equals to 21.");
                            Console.ResetColor();
                            Console.WriteLine();
                            program.GameOver();
                            stopGame = "stop";
                            break;
                        }
                        case var _ when dealer.valueOfDrawnCardDealer > 21:
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Dealer's hand is over 21.");
                            Console.ResetColor();
                            Console.WriteLine();
                            program.Won();
                            stopGame = "stop";
                            break;
                        }
                        case var _ when dealer.valueOfDrawnCardDealer >= 17 && dealer.valueOfDrawnCardDealer < 21:
                        {
                            if (dealer.valueOfDrawnCardDealer > player.valueOfDrawnCardPlayer)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ahoj hele 17 až 21");
                                Console.WriteLine("Dealer's hand is higher that player's.");
                                Console.ResetColor();
                                Console.WriteLine();
                                program.GameOver();
                                stopGame = "stop";
                            }
                            else if (dealer.valueOfDrawnCardDealer < player.valueOfDrawnCardPlayer)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Dealer's hand is lower than player's.");
                                Console.ResetColor();
                                Console.WriteLine();
                                program.Won();
                                stopGame = "stop";
                            }
                            break;
                        }
                        case var _ when dealer.valueOfDrawnCardDealer <= 16: 
                        {
                            dealer.DealCard();
                            dealer.ShowHand();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            dealer.PrintIt();
                            Console.ResetColor();

                            if (dealer.valueOfDrawnCardDealer == 21)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Dealer's hand equals to 21.");
                                Console.ResetColor();
                                Console.WriteLine();
                                program.GameOver();
                                stopGame = "stop";
                            }
                            else if (dealer.valueOfDrawnCardDealer > 21)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Dealer's hand is higher than 21.");
                                Console.ResetColor();
                                Console.WriteLine();
                                program.Won();
                                stopGame = "stop";
                            }
                            else if (dealer.valueOfDrawnCardDealer < 21 && dealer.valueOfDrawnCardDealer >= 17 && dealer.valueOfDrawnCardDealer > player.valueOfDrawnCardPlayer)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Dealer's hand is higher than player's.");
                                Console.ResetColor();
                                Console.WriteLine();
                                program.GameOver();
                                stopGame = "stop";
                            }
                            else if (player.valueOfDrawnCardPlayer > dealer.valueOfDrawnCardDealer && dealer.valueOfDrawnCardDealer < 21 && dealer.valueOfDrawnCardDealer >= 17)
                            {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Dealer's hand is lower than player's.");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    program.Won();
                                    stopGame = "stop";
                            }
                            else if(dealer.valueOfDrawnCardDealer <= 16)
                            {
                                dealer.DealCard();
                                dealer.ShowHand();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                dealer.PrintIt();
                                Console.ResetColor();

                                if (dealer.valueOfDrawnCardDealer == 21)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Dealer's hand equals to 21.");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    program.GameOver();
                                    stopGame = "stop";
                                }
                                else if (dealer.valueOfDrawnCardDealer > 21)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Dealer's hand is higher than 21.");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    program.Won();
                                    stopGame = "stop";
                                }
                                else if (dealer.valueOfDrawnCardDealer < 21 && dealer.valueOfDrawnCardDealer >= 17 && dealer.valueOfDrawnCardDealer > player.valueOfDrawnCardPlayer)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Dealer's hand is higher than player's.");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    program.GameOver();
                                    stopGame = "stop";
                                }
                                else if (player.valueOfDrawnCardPlayer > dealer.valueOfDrawnCardDealer && dealer.valueOfDrawnCardDealer < 21 && dealer.valueOfDrawnCardDealer >= 17)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Dealer's hand is lower than player's.");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    program.Won();
                                    stopGame = "stop";
                                }
                            }                                                           
                            break;
                        }
                    }
                }              
                stopGame = "continue";
                Console.WriteLine("Do you want to play again? (Yes/No)");
                anotherRound = Console.ReadLine();               
            }
            //END OF DEALER ROUND                                        
            Console.ReadKey();
        }
    }
}
