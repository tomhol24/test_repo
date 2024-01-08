using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassPlayground
{
    internal class Rectangle
    {
        public float width;
        public float height;

        public Rectangle (float width, float height) 
        { 
            this.width = width;
            this.height = height;                         
        }

        public float CalculateArea() 
        { 
         float area = width * height;
            return area;           
        }
                                
        public void CalculateAspectRation () 
        { 
         if ( (width/height) < 1 ) 
         {                
                Console.WriteLine("Vysoký obdelník");           
         }
         else if ( (width/height) > 1 ) 
         {
                Console.WriteLine("Široký obdelník");

         }
         else if ( (height/width) == 1) 
         {
                Console.WriteLine("Čtverec");

         }
        } 

        public void PrintRectangle() 
        {
            float printedRectangle = CalculateArea();
            Console.WriteLine($"Obsah obdelníku je {printedRectangle} cm2");
        }

        public bool ContainsPoint() //může být i void
        { 
            Console.WriteLine("Zadej x");           
            int x = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Zadej y");
            int y = Convert.ToInt32(Console.ReadLine());

            if ( (x < 0 || x > width) || (y < 0 || y > height)) 
            { 
                Console.WriteLine("Bod neleží v obdelníku");
                return false;
            }
            else 
            { 
                Console.WriteLine("Bod leží v obdelníku");
                return true;
            } 
        }
    }



    internal class BankAccount 
    {
        public int accountNumber;
        public string holderName;
        public int currency;
        public int balance;
        public int balance2;

        public void Deposit() 
        {
            Console.WriteLine("Zadej počet peněz");           
            int amountOfMoney = Convert.ToInt32(Console.ReadLine());

            balance = amountOfMoney;
        }
        public void PrintDeposit()
        {
            Console.WriteLine($"Stav vašeho účtu je: {balance} Kč");
        }
        
        
        public void Withdraw() 
        {
            Console.WriteLine("Zadej částku kterou chcete vybrat");
            int withdrawAmount = Convert.ToInt32(Console.ReadLine());

            if (balance < withdrawAmount) 
            {
                Console.WriteLine($"Na Vašem účtu není dostatek peněz k výběru: {balance}");                               
            }
            else 
            { 
                balance -= withdrawAmount;
            }
        }
        public void PrintWithdraw()
        {            
            Console.WriteLine($"Stav vašeho účtu je: {balance} Kč");
        }






        public void TransferMoney() 
        {
            Console.WriteLine("Zadejte množství peněz které chcete poslat:");
            int transferAmount = Convert.ToInt32(Console.ReadLine());

            if (transferAmount < balance)
            {
                balance -= transferAmount;

                Console.WriteLine("Zadejte číslo účtu kam chcete peníze poslat:");
                int transDes = Convert.ToInt32(Console.ReadLine());
                if (transDes == 2) 
                {
                    balance2 += transferAmount;
                    Console.WriteLine($"Množství peněz na účtu 2 se zvýšilo o {transferAmount} Kč na {balance2} Kč");
                }
                else if (transDes == 1) 
                {
                    balance += transferAmount; 
                    Console.WriteLine($"Platba se nezdařila. Peníze Vám byly připsány zpátky na účet {balance}.");
                }
            }
            else
            {
                Console.WriteLine($"Na účtě nemáte dostatek prostředků pro povedení platby. Stav Vašeho účtu je: {balance} Kč");
            }                    
        }
    }
}
