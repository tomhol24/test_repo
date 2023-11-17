using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pole_úkol
{
    internal class Program
    {
        static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB) //autorem je chat GPT, nepřepisoval jsem to nijak neboť tomu nerozumím a nechtěl jsem to pokazit
        {
            int rowsA = matrixA.GetLength(0);// Získání rozměrů první matice
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);// Získání rozměrů druhé matice
            int colsB = matrixB.GetLength(1);

            if (colsA != rowsB) // Kontrola kompatibility matic pro násobení
            {
                return null; // Pokud matice nejsou kompatibilní, vrátí se null jako indikátor chyby
            }

            int[,] resultMatrix = new int[rowsA, colsB];

            // Matrix multiplication
            for (int i = 0; i < rowsA; i++) // Násobení matic
            {
                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;

                    for (int k = 0; k < colsA; k++) // Výpočet součtu pro každý prvek výsledné matice
                    {
                        sum += matrixA[i, k] * matrixB[k, j];
                    }
                    resultMatrix[i, j] = sum; // Přiřazení součtu do odpovídajícího prvku výsledné matice
                }
            }

            return resultMatrix;
        }

        static void PrintMatrix(int[,] matrix) //autor - chat gpt
        {
            for (int i = 0; i < matrix.GetLength(0); i++) // Procházení řádků matice
            {
                for (int j = 0; j < matrix.GetLength(1); j++) // Procházení sloupců matice
                {
                    Console.Write(matrix[i, j] + " "); // Výpis hodnoty prvku matice do konzole s mezerou jako oddělovačem
                }
                Console.Write("\n"); // Přidání nového řádku po každém dokončení výpisu řádku matice
            }
            Console.WriteLine();
        }

        static void MultiplyMatrixByScalar(int[,] matrix, int scalar)
        {
            int rows = matrix.GetLength(0); // Získání počtu řádků matice
            int columns = matrix.GetLength(1); // Získání počtu sloupců matice

            for (int i = 0; i < rows; i++) // Procházení každého prvku matice
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] *= scalar; // Násobení každého prvku matice skalárem
                }
            }
        }

        static Random random = new Random(); //Z videa na které je odkaz níže
  
        
        
        static void Main(string[] args)
        {
            //Zadání počtu řádků pole uživatelem - autor: zkopířováno z úkolu -> vpodstatě celý první krok až na nějaké malé předělávky
            Console.WriteLine("Zadej počet řádků pole: ");
            string a = Console.ReadLine();
            int row1 = int.Parse(a); //Parse to ze stringu vezme do intu

            //Zadání počtu sloupců pole uživatelem 
            Console.WriteLine("Zadej počet sloupců pole pole: ");
            string b = Console.ReadLine(); //Uložím to co napsal uživatel do stringu
            int column1 = int.Parse(b); //Pomocí parsu to vezmu ze stringu a uložím do intu

            //Samostatné vytvoření pole z hodnot které zadal uživatel 
            int[,] my2DArray = new int[row1, column1]; //vytvořil jsem si 2D pole, velikost kterou zadal uživatel -> sám

            //Naplnění dvourozměrného pole hodnotamy od 1
            int numberToAdd = 1;//zkopírpváno z 2DplayGround úkolu z hodiny (i ten for cyklus), čílo o které chci aby se mi pole zvyšovalo
            for (int i = 0; i < my2DArray.GetLength(0); i++) //řádky - vnější cyklus, Lenght vrací rozměr pole - 25 -> proto použiju getlenght
            {
                for (int j = 0; j < my2DArray.GetLength(1); j++) //GetLenght 0 je pro řádky, s jedničnou 1 je to pro sloupce, Getlenght je vstupní parametr funcke
                {
                    my2DArray[i, j] = numberToAdd;
                    numberToAdd++;
                    Console.Write(my2DArray[i, j] + " ");
                }
                Console.Write("\n"); // \n znamená enter           
            }
            Console.WriteLine();


            //Prohození dvou hodnot v poli které si vybere uživatel

            //Vytvoření klonu pole my2DArray
            int[,] tempArray2 = (int[,])my2DArray.Clone(); //Vytvořil jsem si klon výchozího pole, následně pracuji jen s klonem (nápad na to mi dal Ondran Augusta a taky mi to pomohl vytvořit)

            //Nadpis - autor: já
            Console.WriteLine("Prohazování dvou prvků mezi sebou"); 
            Console.WriteLine();

            //Instrukce - autor: já
            Console.WriteLine("Zadej souřadnice prvku A který cheš prohodit");
            Console.WriteLine();

            //Zadání žádku uživatelem - autor: zkopírováno z úkolu který jsme dělali na hodině, následně jsem si to předělal
            Console.WriteLine($"Zadej y souřadnici (číslo řádku od 0 do {row1 - 1}): ");
            string swapRow = Console.ReadLine();
            int xFirst = int.Parse(swapRow);
            Console.WriteLine();

            //Zadání sloupce uživatelem - autor: zkopírováno z úkolu který jsme dělali na hodině, následně jsem si to předělal
            Console.WriteLine($"Zadej x souřadnici (číslo sloupce od 0 do {column1 - 1}): ");
            string swapColumn = Console.ReadLine();
            int yFirst = int.Parse(swapColumn);
            Console.WriteLine();

            //Instrukce2 - autor: já
            Console.WriteLine("Zadej souřadnice prvku B který cheš prohodit");
            Console.WriteLine();

            //Zadání řádku uživatelem - autor: zkopírováno z úkolu který jsme dělali na hodině, následně jsem si to předělal
            Console.WriteLine($"Zadej y souřadnici (číslo sloupce od 0 do {row1 - 1}): ");
            string swapRow2 = Console.ReadLine();
            int xSecond = int.Parse(swapRow2);
            Console.WriteLine();

            //Zadání sloupce uživatelem - autor: zkopírováno z úkolu který jsme dělali na hodině, následně jsem si to předělal
            Console.WriteLine($"Zadej x souřadnici (číslo sloupce od 0 do {column1 - 1}): ");
            string swapColumn2 = Console.ReadLine();
            int ySecond = int.Parse(swapColumn2);
            Console.WriteLine();

            //|Samotné prohození hodnot - autor: zkopírováno z úkolu, předěláno mnou
            int first = tempArray2[xFirst, yFirst]; //definoval jsem si proměnnou - proměnná je určité číslo v poli tempArry2 na určitých souřadnicích
            int second = tempArray2[xSecond, ySecond];
            int temp = first; //definoval jsem si proměnnou navíc do které jsem si swapnul firsta
            tempArray2[xFirst, yFirst] = second; //swapnutí proměn
            tempArray2[xSecond, ySecond] = temp;

            //Vypsání pole - autor: zkopírováno z úkolu, předěláno mnou
            Console.WriteLine("Výsledné pole: "); // Vypíše "Výsledné pole: " na konzoli
            for (int i = 0; i < tempArray2.GetLength(0); i++) // Prochází prvky v prvním rozměru dvourozměrného pole
            {
                for (int j = 0; j < tempArray2.GetLength(1); j++) // Prochází prvky ve druhém rozměru dvourozměrného pole
                {
                    Console.Write(tempArray2[i, j] + " "); // Vypíše prvek pole na konzoli s mezerou za ním
                }
                Console.Write("\n"); // Vytvoří nový řádek na konzoli po dokončení jednoho řádku pole
            }
            Console.WriteLine(); // Vypíše prázdný řádek na konzoli pro oddělení


            //Prohazování řádků

            //Vytvoření klonu pole my2DArray - autor: já
            int[,] tempArray3 = (int[,])my2DArray.Clone();

            //Nadpis - autor: já
            Console.WriteLine("Prohazování dvou řádků mezi sebou");
            Console.WriteLine();

            //Zadání řádku A uživatelem - autor: zkopírovno z úkolu, předěláno mnou
            Console.WriteLine($"Zadej číslo řádku A který chceš prohodit (od 0 do {row1 - 1}):"); 
            string rowSwapA = Console.ReadLine();
            int nRowSwap = int.Parse(rowSwapA);
            Console.WriteLine();

            //Zadání řádku B uživatelem - autor: zkopírováno z úkolu, předěláno mnou
            Console.WriteLine($"Zadej číslo řádku B který chceš prohodit (od 0 do {row1 - 1}):");
            string rowSwapB = Console.ReadLine();
            int mRowSwap = int.Parse(rowSwapB);
            Console.WriteLine();

            //Vytvoření nového pole pro přechodné uložení
            int[] tempArray = new int[Math.Max(row1, column1)];// Vytváří nové jednorozměrné pole typu int s délkou rovnou větší hodnotě
                                                               // mezi proměnnými row1 a column1

            //Zkopírování nRowSpap řádku do pomocného pole tempArray
            for (int j = 0; j < tempArray3.GetLength(1); j++) // Kopírování prvků z řádku nRowSwap pole tempArray3 do jednorozměrného pole tempArray
            {
                tempArray[j] = tempArray3[nRowSwap, j];
            }

            //Přepsání nRowSwap rádku řádkem mRowSwap
            for (int j = 0; j < tempArray2.GetLength(1); j++) // Přepsání řádku nRowSwap pole tempArray3 hodnotami z řádku mRowSwap
            {
                tempArray3[nRowSwap, j] = tempArray3[mRowSwap, j];
            }

            //Přepsání mRowSwap řádku pomocným polem tempArray
            for (int j = 0; j < tempArray3.GetLength(1); j++) // Přepsání řádku mRowSwap pole tempArray3 hodnotami z jednorozměrného pole tempArray
            {
                tempArray3[mRowSwap, j] = tempArray[j];
            }

            //Vypsání do konzole - klasika, už nebudu vypisovat co to dělá, protože jsem to udělal víš a ono se to jen opakuje
            Console.WriteLine("Pole po prohození řádků");
            for (int i = 0; i < tempArray3.GetLength(0); i++)
            {
                for (int j = 0; j < tempArray3.GetLength(1); j++)
                {
                    Console.Write(tempArray3[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();


            //Prohazování sloupců - autor: zkopírováné z úkolu, předělané mnou - popisky: jen to co jsem ještě nepopisoval

            //Vytvoření klonu pole my2DArray
            int[,] tempArray4 = (int[,])my2DArray.Clone(); //vytvoření klonu pole

            //Nadpis
            Console.WriteLine("Prohazování dvou sloupců mezi sebou");
            Console.WriteLine();

            //Zadání sloupce A uživatelem
            Console.WriteLine($"Zadej číslo sloupce A který chceš prohodit (od 0 do {column1 - 1}):");
            string colmnSwapA = Console.ReadLine();
            int nColSwap = int.Parse(colmnSwapA);
            Console.WriteLine();

            //Zadání sloupce B uživatelem
            Console.WriteLine($"Zadej číslo sloupce B který chceš prohodit (od 0 do {column1 - 1}):");
            string colmnSwapB = Console.ReadLine();
            int mColSwap = int.Parse(colmnSwapB);
            Console.WriteLine();

            //Vytvoření přechodného pole pro uložení hodnot
            int[] tempArrayColumn = new int[Math.Max(row1, column1)];

            //Zkopírování nColSwap sloupce do pomocného pole tempArrayColumn
            for (int i = 0; i < tempArray4.GetLength(0); i++) // Tento blok kopíruje hodnoty sloupce nColSwap z pole tempArray4 do jednorozměrného pole tempArrayColumn. Tím se ukládají hodnoty sloupce nColSwap pro pozdější použití.
            {
                tempArrayColumn[i] = tempArray4[i, nColSwap]; // Uložení hodnoty z nColSwap sloupce do jednorozměrného pole
            }

            //Přepsání nColSwap sloupce sloupcem mColSwap
            for (int i = 0; i < tempArray4.GetLength(0); i++) //V tomto bloku jsou hodnoty sloupce mColSwap v poli tempArray4 přepsány do sloupce nColSwap. Tím dojde k prohození hodnot mezi sloupci nColSwap a mColSwap.
            {
                tempArray4[i, nColSwap] = tempArray4[i, mColSwap]; // Přepsání hodnoty z mColSwap sloupce do nColSwap sloupce
            }

            //Přepsání mColSwap sloupce pomocným polem tempArrayColumn
            for (int i = 0; i < tempArray4.GetLength(0); i++) //Poslední blok přepisuje hodnoty z jednorozměrného pole tempArrayColumn zpět do sloupce mColSwap v poli tempArray4. Tím je dokončen proces prohození hodnot mezi sloupci nColSwap a mColSwap.
            {
                tempArray4[i, mColSwap] = tempArrayColumn[i]; // Přepsání hodnoty z jednorozměrného pole do mColSwap sloupce
            }

            //Vypsání do konzole
            Console.WriteLine("Pole po prohození sloupců:");
            for (int i = 0; i < tempArray4.GetLength(0); i++)
            {
                for (int j = 0; j < tempArray4.GetLength(1); j++)
                {
                    Console.Write(tempArray4[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();


            //Prohození pořadí prvků na hlavní diagonále - autor: zkopírováno z úkolu, předěláno mnou

            //Nadpis
            Console.WriteLine("Prohození pořadí prvků na hlavní diagonále: ");
            Console.WriteLine();

            //Vytvoření klonu pole my2DArray
            int[,] tempArray5 = (int[,])my2DArray.Clone();

            //Vytvoření pomocné proměnné
            int tempHelp1 = Math.Min(row1, column1);

            //Samotné prohození
            for (int i = 0; i <= tempHelp1 / 2; i++) //= je tam kvůli prostřednímu prvku // Prochází položky diagonály až do poloviny matice
            {
                int temp1 = tempArray5[i, i]; // Ukládá hodnotu diagonálního prvku na pozici (i, i) do dočasné proměnné temp1
                int reversedIndex = tempHelp1 - i - 1; //bez toho i by mi to napsalo totální blbosti - prohodilo by se to naprosto náhodně // Spočítá index reverzního prvku diagonály (druhá polovina matice)
                tempArray5[i, i] = tempArray5[reversedIndex, reversedIndex];// Prohazuje hodnotu diagonálního prvku (i, i) s hodnotou reverzního prvku (reversedIndex, reversedIndex)
                tempArray5[reversedIndex, reversedIndex] = temp1; // Přiřazuje původní hodnotu diagonálního prvku (i, i) na místo reverzního prvku (reversedIndex, reversedIndex)
            }

            //Vypsání do konzole
            for (int i = 0; i < tempArray5.GetLength(0); i++)
            {
                for (int j = 0; j < tempArray5.GetLength(1); j++)
                {
                    Console.Write(tempArray5[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();


            //Prohození prvků na vedlejší diagonále - autor: zkopírováno z úkolu, předěláno chatem GTP a některé prvky i mnou

            //Nadpis
            Console.WriteLine("Prohození pořadí prvků na vedlejší diagonále diagonále ");
            Console.WriteLine();

            //Vytvoření klonu pole my2DArray
            int[,] tempArray6 = (int[,])my2DArray.Clone();

            //Vytvoření pomocné proměnné
            int tempHelp2 = Math.Min(row1, column1);

            //Samotné prohození
            for (int i = 0; i < tempHelp2 / 2; i++) // Prochází položky diagonály matice až do poloviny matice
            {
                int tempH = tempArray6[i, tempHelp2 - i - 1]; // Ukládá hodnotu diagonálního prvku na pozici (i, tempHelp2 - i - 1) do dočasné proměnné tempH
                int t = tempHelp2 - i - 1; // Spočítá index reverzního prvku diagonály v druhé polovině matice
                tempArray6[i, t] = tempArray6[t, i]; // Prohazuje hodnotu diagonálního prvku (i, tempHelp2 - i - 1) s hodnotou reverzního prvku (tempHelp2 - i - 1, i)
                tempArray6[t, i] = tempH; // Přiřazuje původní hodnotu diagonálního prvku (i, tempHelp2 - i - 1) na místo reverzního prvku (tempHelp2 - i - 1, i)
            }

            //Vypsání do konzole
            for (int i = 0; i < tempArray6.GetLength(0); i++)
            {
                for (int j = 0; j < tempArray6.GetLength(1); j++)
                {
                    Console.Write(tempArray6[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();


            //Vynásobení jednotlivých prvků matice číslem - autor: Chat GPT + Ondra Augusta + já

            //Vytvoření klonu pole my2DArray
            int[,] tempArray7 = (int[,])my2DArray.Clone(); 

            //Instrukce
            Console.WriteLine("Zadej číslo kterým se bude matice násobit");
            string numToMulti = Console.ReadLine();
            int multipl = int.Parse(numToMulti);
            Console.WriteLine();

            //Nadpis
            Console.WriteLine($"Násobím číslem {multipl}:");
            Console.WriteLine();

            //Samotné násobení
            MultiplyMatrixByScalar(tempArray7, multipl); //Použije funkci MultiplyMatrixByScalar (která je difinována ve staticu) k násobení matice tempArray7 číslem multipl.
            Console.WriteLine("Vynásobená matice:");
            
            //Vypsání pole
            PrintMatrix(tempArray7); //Použije funkci PrintMatrix (také ve staticu) k vypsání výsledné matice tempArray7.


            //Součet dvou matic - autor: YTB kanál Petr Voborník: https://www.youtube.com/watch?v=Ulx1On49xsY&t=18s 

            //Nadpis
            Console.WriteLine("Pole náhodných čísel které se bude sčítat s polem od uživatele:");
            Console.WriteLine(); 

            //Vytvoření nového pole které se naplní náhodnými prvky
            var my2DArrayRnd = new int[row1, column1]; //var je implicitní tipování proměnných -> To znamená, že kompilátor automaticky určí datový typ proměnné na základě její hodnoty při deklaraci., Vytvoří nové dvourozměrné pole typu int s počtem řádků dáným proměnnou row1 a počtem sloupců dáným proměnnou column1.

            //Naplnění náhodnými prvky
            for (int i = 0; i < my2DArrayRnd.GetLength(0); i++) // Inicializace dvourozměrné matice my2DArrayRnd s náhodnými čísly
            {
                for (int j = 0; j < my2DArrayRnd.GetLength(1); j++)
                {
                    my2DArrayRnd[i, j] = random.Next(10); // Generování náhodného čísla od 0 do 9 a přiřazení do prvků matice
                    Console.Write(my2DArrayRnd[i, j] + " ");// Výpis hodnoty prvku matice do konzole s oddělovačem mezi čísly
                }
                Console.Write("\n"); // Přidání nového řádku po každém dokončení výpisu řádku matice
            }
            Console.WriteLine();

            //Samotné sčítání dvou polí (jednoho od uživatele a druhého náhodně vygenerovaného

            //Nadpis
            Console.WriteLine("Výsledek sčítání dvou maticových polí:");

            //Vytvoření výsledného pole 
            var my2DArraySum = new int[row1, column1];

            //Samotné sečtení a vypsání
            for (int i = 0; i < my2DArrayRnd.GetLength(0); i++)
            {
                for (int j = 0; j < my2DArrayRnd.GetLength(1); j++)
                {
                    my2DArraySum[i, j] = my2DArray[i, j] + my2DArrayRnd[i, j]; // Součet odpovídajících prvků matic my2DArray a my2DArrayRnd
                    Console.Write(my2DArraySum[i, j] + " "); // Výpis hodnoty prvku matice do konzole s oddělovačem mezi čísly
                }
                Console.Write("\n");
            }
            Console.WriteLine();



            //Odečtení dvou  matic - autor: já, protoře se tam měnilo jen jedno znaménko, takže jsem si to jen zkopíroval a změnil jej

            //Nadpis
            Console.WriteLine("Pole náhodných čísel které se bude odčítat od pole uživatele:");
            
            //Vytvořní nového pole které se naplní náhodnými prvky
            var my2DArrayRnd2 = new int[row1, column1]; //var je implicitní tipování proměnných

            //Naplnění pole 
            for (int i = 0; i < my2DArrayRnd2.GetLength(0); i++)
            {
                for (int j = 0; j < my2DArrayRnd2.GetLength(1); j++)
                {
                    my2DArrayRnd2[i, j] = random.Next(10);
                    Console.Write(my2DArrayRnd2[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();

            //Výpsání výsledného pole po odečtení
            Console.WriteLine("Výsledek odčítání dvou maticových polí:");
            var my2DArraySub = new int[row1, column1];
            for (int i = 0; i < my2DArrayRnd2.GetLength(0); i++)
            {
                for (int j = 0; j < my2DArrayRnd2.GetLength(1); j++)
                {
                    my2DArraySub[i, j] = my2DArray[i, j] - my2DArrayRnd2[i, j];
                    Console.Write(my2DArraySub[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();


            //Transpozice matice podle hlavní diagonály - autor: Chat GPT, pomohl mi s tím Ondra Augusta

            //Zadefinování transpozicované matice
            int[,] transposedMatrix = new int[column1, row1];

            // Transpozice matice
            for (int i = 0; i < row1; i++)
            {
                for (int j = 0; j < column1; j++)
                {
                    transposedMatrix[j, i] = my2DArray[i, j]; // Přiřazení prvků z původní matice na nové pozice pro transpozici
                }
            }

            // Vypsání transponované matice do konzole
            Console.WriteLine("Transponovaná matice:");
            for (int i = 0; i < column1; i++)
            {
                for (int j = 0; j < row1; j++)
                {
                    Console.Write(transposedMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }

        
            // Násobení dvou matic - autor: Chat gpt - uplně - protože jsem byl úplně v háji když jsem se o to pokoušel sám
            int[,] resultMatrix = MultiplyMatrices(my2DArray, my2DArrayRnd); // Násobení matic a uložení výsledku do resultMatrix
            if (resultMatrix != null) // Kontrola, zda bylo provedení násobení úspěšné
            {
                Console.WriteLine("Tuto matici:"); // Výpis první matice my2DArray
                PrintMatrix(my2DArray);
                Console.WriteLine("Násobím touto maticí"); // Výpis druhé matice my2DArrayRnd
                PrintMatrix(my2DArrayRnd);
                Console.WriteLine();
                Console.WriteLine("A výsledek násobení je:"); // Výpis výsledné matice resultMatrix
                PrintMatrix(resultMatrix);
            }
            else
            {
                Console.WriteLine("Tyto dvě matice násobit neumím. Je mi líto"); // Výpis chybového hlášení, pokud násobení není možné
            }

            Console.ReadKey();
            }
        }
    }

