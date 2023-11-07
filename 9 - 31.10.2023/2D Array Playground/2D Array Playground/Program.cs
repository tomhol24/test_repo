using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace _2D_Array_Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové 2D pole velikosti 5 x 5, naplň ho čísly od 1 do 25 a vypiš ho do konzole (5 řádků po 5 číslech).
           


            //i jsou řádky, j jsou sloupce
            int[,] my2DArray = new int[5, 5]; //ta jedna čárka znamená 2D pole, první jsou řádky, pak sloupce [y,x], vytvořil jsem to pole
            int numberToAdd = 1;
            for (int i = 0; i < my2DArray.GetLength(0);i++) //řádky - vnější cyklus, Lenght vrací rozměr pole - 25 -> proto použiju getlenght
            {
             for (int j = 0; j < my2DArray.GetLength(1);j++) //GetLenght 0 je pro řádky, s jedničnou 1 je to pro sloupce
             {
                my2DArray[i, j] = numberToAdd;
                numberToAdd++;
                    Console.Write(my2DArray[i, j] + " ");
             }
             Console.Write("\n"); // \n znamená enter           
            }
            Console.WriteLine();



            //TODO 2: Vypiš do konzole n-tý řádek pole, kde n určuje proměnná nRow.
            
            
            
            int nRow = 0; //nastavím to číslo na jaký řádek chci vypsat
            for(int j = 0; j < my2DArray.GetLength(1); j++) 
            {
                Console.Write(my2DArray[nRow,j] + " "); //nRow se nemění a mění se mi jenom j, tím tak vypíšu čísla do řádku po řádku        
            }

            Console.Write('\n');



            //TODO 3: Vypiš do konzole n-tý sloupec pole, kde n určuje proměnná nColumn.
            
            
            
            int nColumn = 0; //sloupec
            for (int i = 0; i < my2DArray.GetLength(0); i++) 
            {
                Console.Write(my2DArray[i,nColumn] + " ");             
            }
            Console.Write('\n');



            //BONUS TODO: vypište prvky na hlavní diagonále = na diagonále z levého horního rohu do dolního pravého rohu, vedlejší diagonála je pravým opakem



            for (int i = 0; i < my2DArray.GetLength(0);i++) 
            {
                Console.Write(my2DArray[i, i] + " ");           
            }
            Console.Write('\n');



            //BONUS TODO: to samé ale pro vedlejší diagonálu
            
            
            
            for (int i = 4; i >=0; i--)
            {
                Console.Write(my2DArray[i, my2DArray.GetLength(0) - i - 1] + " ");
            }
            Console.Write('\n');

            Console.WriteLine();



            //TODO 4: Prohoď prvek na souřadnicích [xFirst, yFirst] s prvkem na souřadnicích [xSecond, ySecond] a vypiš celé pole do konzole po prohození.
            //Nápověda: Budeš potřebovat proměnnou navíc, do které si uložíš první z prvků před tím, než ho přepíšeš druhým, abys hodnotou prvního prvku potom mohl přepsat druhý



            int xFirst = 0; //zde si nastavím souřadnice proměnných, které chci prohodit
            int yFirst = 0;
            int xSecond = 0;
            int ySecond = 0;

            int first = my2DArray[xFirst, yFirst];
            int second = my2DArray[xSecond, ySecond];
            int temp = first; //přechodná hodnota
            my2DArray[xFirst, yFirst] = second;
            my2DArray[xSecond, ySecond] = temp;


            for (int i = 0; i < my2DArray.GetLength(0); i++) //řádky - vnější cyklus, Lenght vrací rozměr pole - 25 -> proto použiju getlenght
            {
                for (int j = 0; j < my2DArray.GetLength(1); j++) //GetLenght 0 je pro řádky, s jedničnou 1 je to pro sloupce
                {
                    Console.Write(my2DArray[i, j] + " ");
                }
                Console.Write("\n"); // \n znamená enter           
            }
            Console.WriteLine();


            //TODO 5: Prohoď n-tý řádek v poli s m-tým řádkem (n je dáno proměnnou nRowSwap, m mRowSwap) a vypiš celé pole do konzole po prohození.



            int nRowSwap = 0;
            int mRowSwap = 1;
            int[] tempArray = new int[5];

           
           //Zkopírování nRowSpap řádku do pomocného pole tempArray
           for (int j = 0; j < my2DArray.GetLength(1); j++) 
           {
                tempArray[j] = my2DArray[nRowSwap, j]; //j je vždy stejné, to kolikátý řádek prohazuje je pojmenované m nebo n RowSwap
           }

           ////Přepsání nRowSwap rádku řádkem mRowSwap
           //for (int j = 0; j < my2DArray.GetLength(1); j++)
           //{
           //    my2DArray[nRowSwap, j] = my2DArray[mRowSwap, j]; 
           //}

           // //Přepsání mRowSwap řádku pomocným polem tempArray
           // for (int j = 0; j < my2DArray.GetLength(1); j++)
           // {
           //     my2DArray[mRowSwap, j] = tempArray[j]; //j je jediná proměnná kterou právě iteruji
           // }

            //Vypsání do konzole
            for (int i = 0; i < my2DArray.GetLength(0); i++) //řádky - vnější cyklus, Lenght vrací rozměr pole - 25 -> proto použiju getlenght
            {
                for (int j = 0; j < my2DArray.GetLength(1); j++) //GetLenght 0 je pro řádky, s jedničnou 1 je to pro sloupce
                {
                    Console.Write(my2DArray[i, j] + " ");
                }
                Console.Write("\n"); // \n znamená enter           
            }
            Console.WriteLine();



            //TODO 6: Prohoď n-tý sloupec v poli s m-tým sloupcem (n je dáno proměnnou nColSwap, m mColSwap) a vypiš celé pole do konzole po prohození.



            int nColSwap = 0;
            int mColSwap = 1;
            int[] tempArrayColumn = new int[5];

            //Zkopírování nColSwap sloupce do pomocného pole tempArrayColumn
            for (int i = 0; i < my2DArray.GetLength(0); i++) //i je vždy stejné, souřadnici j má takovou hodnotu podle toho s kterým sloupcem ji prohazuji
            {
                tempArrayColumn[i] = my2DArray[i, nColSwap];
            }
            ////Přepsání nColSwap sloupce sloupcem mColSwap
            //for (int i = 0; i < my2DArray.GetLength(0); i++)
            //{
            //  my2DArray[i, nColSwap] = my2DArray[i, mColSwap];
            //}
            ////Přepsání mColSwap sloupce pomocným polem tempArrayColumn
            //for (int i = 0; i < my2DArray.GetLength(0); i++)
            //{
            //    my2DArray[i, mColSwap] = tempArrayColumn[i];
            //}

            //Vypsání do konzole
            for (int i = 0; i < my2DArray.GetLength(0); i++)
            {
                for (int j = 0; j < my2DArray.GetLength(1); j++)
                {
                    Console.Write(my2DArray[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();



            //TODO 7: Otoč pořadí prvků na hlavní diagonále (z levého horního rohu do pravého dolního rohu) a vypiš celé pole do konzole po otočení.



            //for (int i = 0; i <= my2DArray.GetLength(0) / 2; i++) //= je tam kvůli prostřednímu prvku
            //{
            //    int temp1 = my2DArray[i, i];
            //    int reversedIndex = my2DArray.GetLength(0) - i - 1; //bez toho i by mi to napsalo totální blbosti - prohodilo by se to naprosto náhodně
            //    my2DArray[i, i] = my2DArray[reversedIndex, reversedIndex];
            //    my2DArray[reversedIndex, reversedIndex] = temp1;

            //}

            //Vypsání do konzole
            for (int i = 0; i < my2DArray.GetLength(0); i++)
            {
                for (int j = 0; j < my2DArray.GetLength(1); j++)
                {
                    Console.Write(my2DArray[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();



            //TODO 8: Otoč pořadí prvků na vedlejší diagonále (z pravého horního rohu do levého dolního rohu) a vypiš celé pole do konzole po otočení.



            for (int i = 4; i > my2DArray.GetLength(0)/2; i--) //4, 3, 2
            {
                int tempH = my2DArray[i, my2DArray.GetLength(0) - i - 1];
                my2DArray[i, my2DArray.GetLength(0) - i - 1] = my2DArray[my2DArray.GetLength(0) - i - 1, i];
                my2DArray[my2DArray.GetLength(0) - i - 1, i] = tempH;

            }

            //Vypsání do konzole
            for (int i = 0; i < my2DArray.GetLength(0); i++)
            {
                for (int j = 0; j < my2DArray.GetLength(1); j++)
                {
                    Console.Write(my2DArray[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
