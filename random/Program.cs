using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace random
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Oyun İsmi

            Console.WriteLine("================================================================================" +
                "\r\n   ____  _   _    _    ____  _____    ____  _   _ ___ _____ _____ _____ ____  " +
                "\r\n  / ___|| | | |  / \\  |  _ \\| ____|  / ___|| | | |_ _|  ___|_   _| ____|  _ \\ " +
                "\r\n  \\___ \\| |_| | / _ \\ | |_) |  _|    \\___ \\| |_| || || |_    | | |  _| | |_) |" +
                "\r\n   ___) |  _  |/ ___ \\|  __/| |___    ___) |  _  || ||  _|   | | | |___|  _ < " +
                "\r\n  |____/|_| |_/_/   \\_\\_|   |_____|  |____/|_| |_|___|_|     |_| |_____|_| \\_\\" +
                "\r\n                                                                          " +
                "\r\n                        [ 3x3 PUZZLE STRATEGY GAME ]" +
                "\r\n================================================================================");


            #endregion

            #region değişkenleri seçimler ve oyun başlangıcı

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Please touch any key to start the game...");
            Console.WriteLine("-----------------------------------------------");
            Console.ReadKey(true);
            Console.Write("Please choose player (Human:1 , Computer:2): ");
            int player = Convert.ToInt32(Console.ReadLine());
            while (player !=1 && player != 2)
            {
                Console.Write("Invalid input. Please choose player (Human:1 , Computer:2): ");
                player = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("-------------------------------------------------------");
            Console.Write("1:A  or  2:A,B  or  3:A,B,C  or  4:A,B,C,D  or  5:A,B,C,D,E \r\n Please choose Number of Types of Symbols (NOTOS)  : ");
            int notos = Convert.ToInt32(Console.ReadLine());
            while (notos < 1 || notos > 5)
            {
                Console.Write("Invalid input. Please choose Number of Types of Symbols (NOTOS) (1-5): ");
                notos = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("-------------------------------------------------------");

            Console.Write(" How many symbols there are on the board (1-6) \r\n Please choose Number of Symbols (NOS): ");
            int nos = Convert.ToInt32(Console.ReadLine());
            while (nos < 1 || nos > 6)
            {
                Console.Write("Invalid input. Please choose number of symbols (1-6): ");
                nos = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("-------------------------------------------------------");

            Console.Write("How many random shifts generate the target board (1-20) \r\n Please choose Number of Shifts (NOSH): ");
            int nosh = Convert.ToInt32(Console.ReadLine());
            while (nosh < 1 || nosh > 20)
            {
                Console.Write("Invalid input. Please choose number of shifts (1-20): ");
                nosh = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("-------------------------------------------------------");


            #endregion

            #region Target Board and Game Board random Generation
            Console.WriteLine($"Player = {player}");
            Console.WriteLine($"Number of Types of Symbols = {notos} ");
            Console.WriteLine($"Number Of Symbols = {nos}");
            Console.WriteLine($"Number Of Shift = {nosh}");

            int rountSayısı = 1;
            char a1 = ' ', a2 = ' ', a3 = ' ', a4 = ' ', a5 = ' ', a6 = ' ', a7 = ' ', a8 = ' ', a9 = ' ';
            char t1 = ' ', t2 = ' ', t3 = ' ', t4 = ' ', t5 = ' ', t6 = ' ', t7 = ' ', t8 = ' ', t9 = ' ';

            Random rand = new Random();
            int yerlesen = 0;
           
            while (yerlesen < nos) //yerleşen harf giridiğimiz nos değerine eşit olana kadar dögüyü devam ettir
            {
                char rchar = (char)rand.Next(65, 65 + notos);
                int chooseNumber = rand.Next(1, 10);
                bool boardKoyuldu = false;
                     if (chooseNumber == 1 && a1 == ' ') { a1 = rchar; boardKoyuldu = true; }
                else if (chooseNumber == 2 && a2 == ' ') { a2 = rchar; boardKoyuldu = true; }
                else if (chooseNumber == 3 && a3 == ' ') { a3 = rchar; boardKoyuldu = true; }
                else if (chooseNumber == 4 && a4 == ' ') { a4 = rchar; boardKoyuldu = true; }
                else if (chooseNumber == 5 && a5 == ' ') { a5 = rchar; boardKoyuldu = true; }
                else if (chooseNumber == 6 && a6 == ' ') { a6 = rchar; boardKoyuldu = true; }
                else if (chooseNumber == 7 && a7 == ' ') { a7 = rchar; boardKoyuldu = true; }
                else if (chooseNumber == 8 && a8 == ' ') { a8 = rchar; boardKoyuldu = true; }
                else if (chooseNumber == 9 && a9 == ' ') { a9 = rchar; boardKoyuldu = true; }

                if (boardKoyuldu)
                {
                    bool targetKoyuldu = false;
                    while (!targetKoyuldu) //target boarda harf koyulana kadar döngüye gir
                    {
                        int chooseNumber2 = rand.Next(1, 10);
                             if (chooseNumber2 == 1 && t1 == ' ') { t1 = rchar; targetKoyuldu = true; }
                        else if (chooseNumber2 == 2 && t2 == ' ') { t2 = rchar; targetKoyuldu = true; }
                        else if (chooseNumber2 == 3 && t3 == ' ') { t3 = rchar; targetKoyuldu = true; }
                        else if (chooseNumber2 == 4 && t4 == ' ') { t4 = rchar; targetKoyuldu = true; }
                        else if (chooseNumber2 == 5 && t5 == ' ') { t5 = rchar; targetKoyuldu = true; }
                        else if (chooseNumber2 == 6 && t6 == ' ') { t6 = rchar; targetKoyuldu = true; }
                        else if (chooseNumber2 == 7 && t7 == ' ') { t7 = rchar; targetKoyuldu = true; }
                        else if (chooseNumber2 == 8 && t8 == ' ') { t8 = rchar; targetKoyuldu = true; }
                        else if (chooseNumber2 == 9 && t9 == ' ') { t9 = rchar; targetKoyuldu = true; }
                    }
                    yerlesen++;
                }
            }

            Console.WriteLine($"--- Round {rountSayısı} ---                    --- Target Board ---");
            Console.WriteLine();
            Console.WriteLine("    7  8  9                             7  8  9");
            Console.WriteLine("  +---------+                         +---------+");
            Console.WriteLine($"1 | {a1}  {a2}  {a3} | 4                     1 | {t1}  {t2}  {t3} | 4 ");
            Console.WriteLine($"2 | {a4}  {a5}  {a6} | 5                     2 | {t4}  {t5}  {t6} | 5 ");
            Console.WriteLine($"3 | {a7}  {a8}  {a9} | 6                     3 | {t7}  {t8}  {t9} | 6");
            Console.WriteLine("  +---------+                         +---------+ ");
            Console.Write("  10  11  12                          10  11  12     ");

           

            #endregion



           


            Console.Read();
        }
    }
}
