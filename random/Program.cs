using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace deneme
{
    internal class Program
    {
        static void Main(string[] args)
        {


            #region Oyun İsmi

            Console.WriteLine("================================================================================" +
                "\r\n    ____  _   _    _    ____  _____    ____  _   _ ___ _____ _____ _____ ____  " +
                "\r\n   / ___|| | | |  / \\  |  _ \\| ____|  / ___|| | | |_ _|  ___|_   _| ____|  _ \\ " +
                "\r\n   \\___ \\| |_| | / _ \\ | |_) |  _|    \\___ \\| |_| || || |_    | | |  _| | |_) |" +
                "\r\n    ___) |  _  |/ ___ \\|  __/| |___    ___) |  _  || ||  _|   | | | |___|  _ < " +
                "\r\n   |____/|_| |_/_/   \\_\\_|   |_____|  |____/|_| |_|___|_|     |_| |_____|_| \\_\\" +
                "\r\n                                                                                 " +
                "\r\n                         [ 3x3 PUZZLE STRATEGY GAME ]" +
                "\r\n================================================================================");

            #endregion

            #region Değişkenler, Seçimler ve Oyun Başlangıcı

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Please touch any key to start the game...");
            Console.WriteLine("-----------------------------------------------");
            Console.ReadKey(true);

            Console.Write("Please choose player (Human:1 , Computer:2): ");
            int player = Convert.ToInt32(Console.ReadLine());
            while (player != 1 && player != 2)
            {
                Console.Write("Invalid input. Please choose player (Human:1 , Computer:2): ");
                player = Convert.ToInt32(Console.ReadLine());
            }
            if (player == 1)
            {
                Console.WriteLine("-------------------------------------------------------");
                Console.Write("1:A  or  2:A,B  or  3:A,B,C  or  4:A,B,C,D  or  5:A,B,C,D,E \r\nPlease choose Number of Types of Symbols (NOTOS): ");
                int notos = Convert.ToInt32(Console.ReadLine());
                while (notos < 1 || notos > 5)
                {
                    Console.Write("Invalid input. Please choose Number of Types of Symbols (NOTOS) (1-5): ");
                    notos = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("-------------------------------------------------------");

                int nos = 0;
                Console.Write($"How many symbols there are on the board ({notos}-6) \r\nPlease choose Number of Symbols (NOS): ");
                nos = Convert.ToInt32(Console.ReadLine());
                while (nos < notos || nos > 6)
                {
                    Console.Write($"Invalid input. Please choose number of symbols ({notos}-6): ");
                    nos = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("-------------------------------------------------------");

                Console.Write("How many random shifts generate the target board (1-20) \r\nPlease choose Number of Shifts (NOSH): ");
                int nosh = Convert.ToInt32(Console.ReadLine());
                while (nosh < 1 || nosh > 20)
                {
                    Console.Write("Invalid input. Please choose number of shifts (1-20): ");
                    nosh = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("-------------------------------------------------------");

            #endregion

                #region Initial Board ve Target Board Üretimi

                Console.WriteLine($"Player = {player}");
                Console.WriteLine($"Number of Types of Symbols = {notos}");
                Console.WriteLine($"Number Of Symbols = {nos}");
                Console.WriteLine($"Number Of Shifts = {nosh}");
                Console.WriteLine("---------------------------------------------------------");

                int rountSayısı = 1;
                char a1 = ' ', a2 = ' ', a3 = ' ', a4 = ' ', a5 = ' ', a6 = ' ', a7 = ' ', a8 = ' ', a9 = ' ';
                Random rand = new Random();

                // 1. Zorunlu harfleri tahtaya yerleştir (NOTOS kadar: A, B, C...)
                for (int i = 0; i < notos; i++)
                {
                    char rchar = (char)(65 + i);
                    bool boardKoyuldu = false;

                    while (!boardKoyuldu)
                    {
                        int chooseNumber = rand.Next(1, 10);
                        if (chooseNumber == 1 && a1 == ' ') { a1 = rchar; boardKoyuldu = true; }
                        else if (chooseNumber == 2 && a2 == ' ') { a2 = rchar; boardKoyuldu = true; }
                        else if (chooseNumber == 3 && a3 == ' ') { a3 = rchar; boardKoyuldu = true; }
                        else if (chooseNumber == 4 && a4 == ' ') { a4 = rchar; boardKoyuldu = true; }
                        else if (chooseNumber == 5 && a5 == ' ') { a5 = rchar; boardKoyuldu = true; }
                        else if (chooseNumber == 6 && a6 == ' ') { a6 = rchar; boardKoyuldu = true; }
                        else if (chooseNumber == 7 && a7 == ' ') { a7 = rchar; boardKoyuldu = true; }
                        else if (chooseNumber == 8 && a8 == ' ') { a8 = rchar; boardKoyuldu = true; }
                        else if (chooseNumber == 9 && a9 == ' ') { a9 = rchar; boardKoyuldu = true; }
                    }
                }

                // 2. Kalan harfleri rastgele yerleştir (NOS tamamlanana kadar)
                int yerlesen = notos;
                while (yerlesen < nos)
                {
                    char rchar = (char)rand.Next(65, 65 + notos);
                    int chooseNumber = rand.Next(1, 10);

                    if (chooseNumber == 1 && a1 == ' ') { a1 = rchar; yerlesen++; }
                    else if (chooseNumber == 2 && a2 == ' ') { a2 = rchar; yerlesen++; }
                    else if (chooseNumber == 3 && a3 == ' ') { a3 = rchar; yerlesen++; }
                    else if (chooseNumber == 4 && a4 == ' ') { a4 = rchar; yerlesen++; }
                    else if (chooseNumber == 5 && a5 == ' ') { a5 = rchar; yerlesen++; }
                    else if (chooseNumber == 6 && a6 == ' ') { a6 = rchar; yerlesen++; }
                    else if (chooseNumber == 7 && a7 == ' ') { a7 = rchar; yerlesen++; }
                    else if (chooseNumber == 8 && a8 == ' ') { a8 = rchar; yerlesen++; }
                    else if (chooseNumber == 9 && a9 == ' ') { a9 = rchar; yerlesen++; }
                }

                // 3. TARGET BOARD'U BAŞLANGIÇ TAHTASINDAN KOPYALA
                char t1 = a1, t2 = a2, t3 = a3;
                char t4 = a4, t5 = a5, t6 = a6;
                char t7 = a7, t8 = a8, t9 = a9;

                int yapilanHamle = 0;
                while (yapilanHamle < nosh)
                {
                    // Hamle öncesi tahtanın yedeğini tut
                    char eski_t1 = t1, eski_t2 = t2, eski_t3 = t3;
                    char eski_t4 = t4, eski_t5 = t5, eski_t6 = t6;
                    char eski_t7 = t7, eski_t8 = t8, eski_t9 = t9;

                    int randomShift = rand.Next(1, 13);

                    // 1-3: Satırları Sağa Kaydır
                    if (randomShift == 1)
                    {
                        if (t2 == ' ') { t2 = t1; t1 = ' '; }
                        if (t3 == ' ') { t3 = t2; t2 = ' '; }
                        if (t2 == ' ') { t2 = t1; t1 = ' '; }
                    }
                    else if (randomShift == 2)
                    {
                        if (t5 == ' ') { t5 = t4; t4 = ' '; }
                        if (t6 == ' ') { t6 = t5; t5 = ' '; }
                        if (t5 == ' ') { t5 = t4; t4 = ' '; }
                    }
                    else if (randomShift == 3)
                    {
                        if (t8 == ' ') { t8 = t7; t7 = ' '; }
                        if (t9 == ' ') { t9 = t8; t8 = ' '; }
                        if (t8 == ' ') { t8 = t7; t7 = ' '; }
                    }
                    // 4-6: Satırları Sola Kaydır
                    else if (randomShift == 4)
                    {
                        if (t2 == ' ') { t2 = t3; t3 = ' '; }
                        if (t1 == ' ') { t1 = t2; t2 = ' '; }
                        if (t2 == ' ') { t2 = t3; t3 = ' '; }
                    }
                    else if (randomShift == 5)
                    {
                        if (t5 == ' ') { t5 = t6; t6 = ' '; }
                        if (t4 == ' ') { t4 = t5; t5 = ' '; }
                        if (t5 == ' ') { t5 = t6; t6 = ' '; }
                    }
                    else if (randomShift == 6)
                    {
                        if (t8 == ' ') { t8 = t9; t9 = ' '; }
                        if (t7 == ' ') { t7 = t8; t8 = ' '; }
                        if (t8 == ' ') { t8 = t9; t9 = ' '; }
                    }
                    // 7-9: Sütunları Aşağı Kaydır
                    else if (randomShift == 7)
                    {
                        if (t4 == ' ') { t4 = t1; t1 = ' '; }
                        if (t7 == ' ') { t7 = t4; t4 = ' '; }
                        if (t4 == ' ') { t4 = t1; t1 = ' '; }
                    }
                    else if (randomShift == 8)
                    {
                        if (t5 == ' ') { t5 = t2; t2 = ' '; }
                        if (t8 == ' ') { t8 = t5; t5 = ' '; }
                        if (t5 == ' ') { t5 = t2; t2 = ' '; }
                    }
                    else if (randomShift == 9)
                    {
                        if (t6 == ' ') { t6 = t3; t3 = ' '; }
                        if (t9 == ' ') { t9 = t6; t6 = ' '; }
                        if (t6 == ' ') { t6 = t3; t3 = ' '; }
                    }
                    // 10-12: Sütunları Yukarı Kaydır
                    else if (randomShift == 10)
                    {
                        if (t4 == ' ') { t4 = t7; t7 = ' '; }
                        if (t1 == ' ') { t1 = t4; t4 = ' '; }
                        if (t4 == ' ') { t4 = t7; t7 = ' '; }
                    }
                    else if (randomShift == 11)
                    {
                        if (t5 == ' ') { t5 = t8; t8 = ' '; }
                        if (t2 == ' ') { t2 = t5; t5 = ' '; }
                        if (t5 == ' ') { t5 = t8; t8 = ' '; }
                    }
                    else if (randomShift == 12)
                    {
                        if (t6 == ' ') { t6 = t9; t9 = ' '; }
                        if (t3 == ' ') { t3 = t6; t6 = ' '; }
                        if (t6 == ' ') { t6 = t9; t9 = ' '; }
                    }

                    // Tahta gerçekten değişti mi kontrol et (Boş satır/sütun hamlesini sayma)
                    bool degisti = (eski_t1 != t1 || eski_t2 != t2 || eski_t3 != t3 ||
                                    eski_t4 != t4 || eski_t5 != t5 || eski_t6 != t6 ||
                                    eski_t7 != t7 || eski_t8 != t8 || eski_t9 != t9);

                    if (degisti)
                    {
                        yapilanHamle++;
                    }
                }

                // 5. BAŞLANGIÇ SKORUNU HESAPLA
                int boardScore = 0;
                if (a1 == t1 && a1 != ' ') boardScore += (a1 - 64) * 1;
                if (a2 == t2 && a2 != ' ') boardScore += (a2 - 64) * 2;
                if (a3 == t3 && a3 != ' ') boardScore += (a3 - 64) * 1;
                if (a4 == t4 && a4 != ' ') boardScore += (a4 - 64) * 2;
                if (a5 == t5 && a5 != ' ') boardScore += (a5 - 64) * 4;
                if (a6 == t6 && a6 != ' ') boardScore += (a6 - 64) * 2;
                if (a7 == t7 && a7 != ' ') boardScore += (a7 - 64) * 1;
                if (a8 == t8 && a8 != ' ') boardScore += (a8 - 64) * 2;
                if (a9 == t9 && a9 != ' ') boardScore += (a9 - 64) * 1;

                // İLK TAHTAYI EKRANA ÇİZ
                Console.WriteLine($"--- Round {rountSayısı} ---                    --- Target Board ---");
                Console.WriteLine();
                Console.WriteLine("    7  8  9                              7  8  9");
                Console.WriteLine("  +---------+                          +---------+");
                Console.WriteLine($"1 | {a1}  {a2}  {a3} | 4                      1 | {t1}  {t2}  {t3} | 4                Board Score: {boardScore}");
                Console.WriteLine($"2 | {a4}  {a5}  {a6} | 5                      2 | {t4}  {t5}  {t6} | 5 ");
                Console.WriteLine($"3 | {a7}  {a8}  {a9} | 6                      3 | {t7}  {t8}  {t9} | 6");
                Console.WriteLine("  +---------+                          +---------+ ");
                Console.WriteLine("  10  11  12                           10  11  12     ");
                Console.WriteLine("---------------------------------------------------------");

                #endregion

                #region Shift Uygulama
                int shiftSayısı = 0;
                for (int i = 1; i < 200000000; i++)
                {
                    Console.Write("Please input shift (1 ,12)  or if you want to end this game input 0: ");
                    int shift = Convert.ToInt32(Console.ReadLine());
                    rountSayısı++;
                    if (shift == 0)
                    {
                        int gamescore = (10 * boardScore) + (notos * nos * (nosh - (rountSayısı - 1)));
                        Console.WriteLine();
                        Console.WriteLine("=========================================================");
                        Console.WriteLine(" Oyun kullanıcı tarafından sonlandırıldı. Pes ettiniz!");
                        Console.WriteLine($" Toplam denenen round: {rountSayısı - 1}");
                        Console.WriteLine($" Toplam yapılan hamle: {shiftSayısı}");
                        Console.WriteLine($" Son Tahta Skoru     : {boardScore}");
                        Console.WriteLine($" Toplam Oyun Skoru   : {gamescore}");
                        Console.WriteLine("=========================================================");
                        break;
                    }
                    if (shift == 1)
                    {
                        if (a2 == ' ') { a2 = a1; a1 = ' '; }
                        if (a3 == ' ') { a3 = a2; a2 = ' '; }
                        if (a2 == ' ') { a2 = a1; a1 = ' '; }
                    }
                    if (shift == 2)
                    {
                        if (a5 == ' ') { a5 = a4; a4 = ' '; }
                        if (a6 == ' ') { a6 = a5; a5 = ' '; }
                        if (a5 == ' ') { a5 = a4; a4 = ' '; }
                    }
                    if (shift == 3)
                    {
                        if (a8 == ' ') { a8 = a7; a7 = ' '; }
                        if (a9 == ' ') { a9 = a8; a8 = ' '; }
                        if (a8 == ' ') { a8 = a7; a7 = ' '; }
                    }
                    if (shift == 4)
                    {
                        if (a2 == ' ') { a2 = a3; a3 = ' '; }
                        if (a1 == ' ') { a1 = a2; a2 = ' '; }
                        if (a2 == ' ') { a2 = a3; a3 = ' '; }
                    }
                    if (shift == 5)
                    {
                        if (a5 == ' ') { a5 = a6; a6 = ' '; }
                        if (a4 == ' ') { a4 = a5; a5 = ' '; }
                        if (a5 == ' ') { a5 = a6; a6 = ' '; }
                    }
                    if (shift == 6)
                    {
                        if (a8 == ' ') { a8 = a9; a9 = ' '; }
                        if (a7 == ' ') { a7 = a8; a8 = ' '; }
                        if (a8 == ' ') { a8 = a9; a9 = ' '; }
                    }
                    if (shift == 7)
                    {
                        if (a4 == ' ') { a4 = a1; a1 = ' '; }
                        if (a7 == ' ') { a7 = a4; a4 = ' '; }
                        if (a4 == ' ') { a4 = a1; a1 = ' '; }
                    }
                    if (shift == 8)
                    {
                        if (a5 == ' ') { a5 = a2; a2 = ' '; }
                        if (a8 == ' ') { a8 = a5; a5 = ' '; }
                        if (a5 == ' ') { a5 = a2; a2 = ' '; }
                    }
                    if (shift == 9)
                    {
                        if (a6 == ' ') { a6 = a3; a3 = ' '; }
                        if (a9 == ' ') { a9 = a6; a6 = ' '; }
                        if (a6 == ' ') { a6 = a3; a3 = ' '; }
                    }
                    if (shift == 10)
                    {
                        if (a4 == ' ') { a4 = a7; a7 = ' '; }
                        if (a1 == ' ') { a1 = a4; a4 = ' '; }
                        if (a4 == ' ') { a4 = a7; a7 = ' '; }
                    }
                    if (shift == 11)
                    {
                        if (a5 == ' ') { a5 = a8; a8 = ' '; }
                        if (a2 == ' ') { a2 = a5; a5 = ' '; }
                        if (a5 == ' ') { a5 = a8; a8 = ' '; }
                    }
                    if (shift == 12)
                    {
                        if (a6 == ' ') { a6 = a9; a9 = ' '; }
                        if (a3 == ' ') { a3 = a6; a6 = ' '; }
                        if (a6 == ' ') { a6 = a9; a9 = ' '; }
                    }

                    boardScore = 0;
                    if (a1 == t1 && a1 != ' ') boardScore += (a1 - 64) * 1;
                    if (a2 == t2 && a2 != ' ') boardScore += (a2 - 64) * 2;
                    if (a3 == t3 && a3 != ' ') boardScore += (a3 - 64) * 1;
                    if (a4 == t4 && a4 != ' ') boardScore += (a4 - 64) * 2;
                    if (a5 == t5 && a5 != ' ') boardScore += (a5 - 64) * 4;
                    if (a6 == t6 && a6 != ' ') boardScore += (a6 - 64) * 2;
                    if (a7 == t7 && a7 != ' ') boardScore += (a7 - 64) * 1;
                    if (a8 == t8 && a8 != ' ') boardScore += (a8 - 64) * 2;
                    if (a9 == t9 && a9 != ' ') boardScore += (a9 - 64) * 1;


                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine($"--- Round {rountSayısı} ---                    --- Target Board ---");
                    Console.WriteLine();
                    Console.WriteLine("    7  8  9                             7  8  9");
                    Console.WriteLine("  +---------+                         +---------+");
                    Console.WriteLine($"1 | {a1}  {a2}  {a3} | 4                     1 | {t1}  {t2}  {t3} | 4                Board Score: {boardScore}");
                    Console.WriteLine($"2 | {a4}  {a5}  {a6} | 5                     2 | {t4}  {t5}  {t6} | 5 ");
                    Console.WriteLine($"3 | {a7}  {a8}  {a9} | 6                     3 | {t7}  {t8}  {t9} | 6");
                    Console.WriteLine("  +---------+                         +---------+ ");
                    Console.WriteLine("  10  11  12                          10  11  12     ");
                    Console.WriteLine("---------------------------------------------------------");
                    shiftSayısı++;

                    if (a1 == t1 && a2 == t2 && a3 == t3 && a4 == t4 && a5 == t5 && a6 == t6 && a7 == t7 && a8 == t8 && a9 == t9)
                    {

                        int gamescore = (10 * boardScore) + (notos * nos * (nosh - (rountSayısı - 1)));
                        Console.WriteLine();
                        Console.WriteLine("=========================================================");
                        Console.WriteLine("   TEBRİKLER! HEDEF TAHTAYA BAŞARIYLA ULAŞTINIZ!        ");
                        Console.WriteLine("=========================================================");
                        Console.WriteLine($"  Toplam Round Sayısı : {rountSayısı}");
                        Console.WriteLine($"  Yapılan Hamle Sayısı: {shiftSayısı}");
                        Console.WriteLine($"  Son Tahta Skoru     : {boardScore}");
                        Console.WriteLine($"  Toplam Oyun Skoru   : {gamescore}");
                        Console.WriteLine("=========================================================");
                        Console.WriteLine("\nÇıkmak için Enter tuşuna basın...");
                        Console.ReadLine();
                        break; // Oyunu ve döngüyü tamamen bitirir
                    }



                }
            }
                #endregion

            #region computer
            else if (player == 2)
            {
                Console.WriteLine("-------------------------------------------------------");
                Console.Write("1:A  or  2:A,B  or  3:A,B,C  or  4:A,B,C,D  or  5:A,B,C,D,E \r\n Please choose Number of Types of Symbols (NOTOS)  : ");
                int notos = Convert.ToInt32(Console.ReadLine());
                while (notos < 1 || notos > 5)
                {
                    Console.Write("Invalid input. Please choose Number of Types of Symbols (NOTOS) (1-5): ");
                    notos = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("-------------------------------------------------------");

                int nos = 0;
                Console.Write($" How many symbols there are on the board ({notos}-6) \r\n Please choose Number of Symbols (NOS): ");
                nos = Convert.ToInt32(Console.ReadLine());
                while (nos < notos || nos > 6)
                {
                    Console.Write($"Invalid input. Please choose number of symbols ({notos}-6): ");
                    nos = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("-------------------------------------------------------");

                Console.Write("How many random shifts generate the target board (1-20) \r\nPlease choose Number of Shifts (NOSH): ");
                int nosh = Convert.ToInt32(Console.ReadLine());
                while (nosh < 1 || nosh > 20)
                {
                    Console.Write("Invalid input. Please choose number of shifts (1-20): ");
                    nosh = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("-------------------------------------------------------");

                // Başlangıç tahtasını boşluklarla oluştur
                char a1 = ' ', a2 = ' ', a3 = ' ', a4 = ' ', a5 = ' ', a6 = ' ', a7 = ' ', a8 = ' ', a9 = ' ';
                Random rand = new Random();

                // 1. Zorunlu sembolleri yerleştir (NOTOS kadar)
                for (int i = 0; i < notos; i++)
                {
                    char rchar = (char)(65 + i);
                    bool boardKoyuldu = false;

                    while (!boardKoyuldu)
                    {
                        int chooseNumber = rand.Next(1, 10);
                        if (chooseNumber == 1 && a1 == ' ') { a1 = rchar; boardKoyuldu = true; }
                        else if (chooseNumber == 2 && a2 == ' ') { a2 = rchar; boardKoyuldu = true; }
                        else if (chooseNumber == 3 && a3 == ' ') { a3 = rchar; boardKoyuldu = true; }
                        else if (chooseNumber == 4 && a4 == ' ') { a4 = rchar; boardKoyuldu = true; }
                        else if (chooseNumber == 5 && a5 == ' ') { a5 = rchar; boardKoyuldu = true; }
                        else if (chooseNumber == 6 && a6 == ' ') { a6 = rchar; boardKoyuldu = true; }
                        else if (chooseNumber == 7 && a7 == ' ') { a7 = rchar; boardKoyuldu = true; }
                        else if (chooseNumber == 8 && a8 == ' ') { a8 = rchar; boardKoyuldu = true; }
                        else if (chooseNumber == 9 && a9 == ' ') { a9 = rchar; boardKoyuldu = true; }
                    }
                }

                // 2. Kalan harfleri rastgele yerleştir (NOS tamamlanana kadar)
                int yerlesen = notos;
                while (yerlesen < nos)
                {
                    char rchar = (char)rand.Next(65, 65 + notos);
                    int chooseNumber = rand.Next(1, 10);

                    if (chooseNumber == 1 && a1 == ' ') { a1 = rchar; yerlesen++; }
                    else if (chooseNumber == 2 && a2 == ' ') { a2 = rchar; yerlesen++; }
                    else if (chooseNumber == 3 && a3 == ' ') { a3 = rchar; yerlesen++; }
                    else if (chooseNumber == 4 && a4 == ' ') { a4 = rchar; yerlesen++; }
                    else if (chooseNumber == 5 && a5 == ' ') { a5 = rchar; yerlesen++; }
                    else if (chooseNumber == 6 && a6 == ' ') { a6 = rchar; yerlesen++; }
                    else if (chooseNumber == 7 && a7 == ' ') { a7 = rchar; yerlesen++; }
                    else if (chooseNumber == 8 && a8 == ' ') { a8 = rchar; yerlesen++; }
                    else if (chooseNumber == 9 && a9 == ' ') { a9 = rchar; yerlesen++; }
                }

                // 3. TARGET BOARD'U BAŞLANGIÇ TAHTASINDAN KOPYALA
                char t1 = a1, t2 = a2, t3 = a3;
                char t4 = a4, t5 = a5, t6 = a6;
                char t7 = a7, t8 = a8, t9 = a9;

                int yapilanHamle = 0;
                while (yapilanHamle < nosh)
                {
                    // Hamle öncesi tahtanın yedeğini tut
                    char eski_t1 = t1, eski_t2 = t2, eski_t3 = t3;
                    char eski_t4 = t4, eski_t5 = t5, eski_t6 = t6;
                    char eski_t7 = t7, eski_t8 = t8, eski_t9 = t9;

                    int randomShift = rand.Next(1, 13);

                    // 1-3: Satırları Sağa Kaydır
                    if (randomShift == 1)
                    {
                        if (t2 == ' ') { t2 = t1; t1 = ' '; }
                        if (t3 == ' ') { t3 = t2; t2 = ' '; }
                        if (t2 == ' ') { t2 = t1; t1 = ' '; }
                    }
                    else if (randomShift == 2)
                    {
                        if (t5 == ' ') { t5 = t4; t4 = ' '; }
                        if (t6 == ' ') { t6 = t5; t5 = ' '; }
                        if (t5 == ' ') { t5 = t4; t4 = ' '; }
                    }
                    else if (randomShift == 3)
                    {
                        if (t8 == ' ') { t8 = t7; t7 = ' '; }
                        if (t9 == ' ') { t9 = t8; t8 = ' '; }
                        if (t8 == ' ') { t8 = t7; t7 = ' '; }
                    }
                    // 4-6: Satırları Sola Kaydır
                    else if (randomShift == 4)
                    {
                        if (t2 == ' ') { t2 = t3; t3 = ' '; }
                        if (t1 == ' ') { t1 = t2; t2 = ' '; }
                        if (t2 == ' ') { t2 = t3; t3 = ' '; }
                    }
                    else if (randomShift == 5)
                    {
                        if (t5 == ' ') { t5 = t6; t6 = ' '; }
                        if (t4 == ' ') { t4 = t5; t5 = ' '; }
                        if (t5 == ' ') { t5 = t6; t6 = ' '; }
                    }
                    else if (randomShift == 6)
                    {
                        if (t8 == ' ') { t8 = t9; t9 = ' '; }
                        if (t7 == ' ') { t7 = t8; t8 = ' '; }
                        if (t8 == ' ') { t8 = t9; t9 = ' '; }
                    }
                    // 7-9: Sütunları Aşağı Kaydır
                    else if (randomShift == 7)
                    {
                        if (t4 == ' ') { t4 = t1; t1 = ' '; }
                        if (t7 == ' ') { t7 = t4; t4 = ' '; }
                        if (t4 == ' ') { t4 = t1; t1 = ' '; }
                    }
                    else if (randomShift == 8)
                    {
                        if (t5 == ' ') { t5 = t2; t2 = ' '; }
                        if (t8 == ' ') { t8 = t5; t5 = ' '; }
                        if (t5 == ' ') { t5 = t2; t2 = ' '; }
                    }
                    else if (randomShift == 9)
                    {
                        if (t6 == ' ') { t6 = t3; t3 = ' '; }
                        if (t9 == ' ') { t9 = t6; t6 = ' '; }
                        if (t6 == ' ') { t6 = t3; t3 = ' '; }
                    }
                    // 10-12: Sütunları Yukarı Kaydır
                    else if (randomShift == 10)
                    {
                        if (t4 == ' ') { t4 = t7; t7 = ' '; }
                        if (t1 == ' ') { t1 = t4; t4 = ' '; }
                        if (t4 == ' ') { t4 = t7; t7 = ' '; }
                    }
                    else if (randomShift == 11)
                    {
                        if (t5 == ' ') { t5 = t8; t8 = ' '; }
                        if (t2 == ' ') { t2 = t5; t5 = ' '; }
                        if (t5 == ' ') { t5 = t8; t8 = ' '; }
                    }
                    else if (randomShift == 12)
                    {
                        if (t6 == ' ') { t6 = t9; t9 = ' '; }
                        if (t3 == ' ') { t3 = t6; t6 = ' '; }
                        if (t6 == ' ') { t6 = t9; t9 = ' '; }
                    }

                    // Tahta gerçekten değişti mi kontrol et (Boş satır/sütun hamlesini sayma)
                    bool degisti = (eski_t1 != t1 || eski_t2 != t2 || eski_t3 != t3 ||
                                    eski_t4 != t4 || eski_t5 != t5 || eski_t6 != t6 ||
                                    eski_t7 != t7 || eski_t8 != t8 || eski_t9 != t9);

                    if (degisti)
                    {
                        yapilanHamle++;
                    }
                }

                // 5. BAŞLANGIÇ SKORUNU HESAPLA
                int boardScore = 0;
                if (a1 == t1 && a1 != ' ') boardScore += (a1 - 64) * 1;
                if (a2 == t2 && a2 != ' ') boardScore += (a2 - 64) * 2;
                if (a3 == t3 && a3 != ' ') boardScore += (a3 - 64) * 1;
                if (a4 == t4 && a4 != ' ') boardScore += (a4 - 64) * 2;
                if (a5 == t5 && a5 != ' ') boardScore += (a5 - 64) * 4;
                if (a6 == t6 && a6 != ' ') boardScore += (a6 - 64) * 2;
                if (a7 == t7 && a7 != ' ') boardScore += (a7 - 64) * 1;
                if (a8 == t8 && a8 != ' ') boardScore += (a8 - 64) * 2;
                if (a9 == t9 && a9 != ' ') boardScore += (a9 - 64) * 1;

                int rountSayısı = 1;
                // İLK TAHTAYI EKRANA ÇİZ
                Console.WriteLine($"--- Round {rountSayısı} ---                    --- Target Board ---");
                Console.WriteLine();
                Console.WriteLine("    7  8  9                              7  8  9");
                Console.WriteLine("  +---------+                          +---------+");
                Console.WriteLine($"1 | {a1}  {a2}  {a3} | 4                      1 | {t1}  {t2}  {t3} | 4                Board Score: {boardScore}");
                Console.WriteLine($"2 | {a4}  {a5}  {a6} | 5                      2 | {t4}  {t5}  {t6} | 5 ");
                Console.WriteLine($"3 | {a7}  {a8}  {a9} | 6                      3 | {t7}  {t8}  {t9} | 6");
                Console.WriteLine("  +---------+                          +---------+ ");
                Console.WriteLine("  10  11  12                           10  11  12     ");
                Console.WriteLine("---------------------------------------------------------");

                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("Computer Oyuna Başlıyor...");
                Console.WriteLine("Hamleleri izlemek için bir tuşa basın...");
                Console.ReadKey(true);

                int shiftSayısı = 0;

                while (true)
                {
                    // 1. KAZANMA KONTROLÜ
                    if (a1 == t1 && a2 == t2 && a3 == t3 &&
                        a4 == t4 && a5 == t5 && a6 == t6 &&
                        a7 == t7 && a8 == t8 && a9 == t9)
                    {
                        int gamescore = (10 * boardScore) + (notos * nos * nosh) - (rountSayısı - 1);
                        Console.WriteLine();
                        Console.WriteLine("=========================================================");
                        Console.WriteLine("   BİLGİSAYAR HEDEF TAHTAYA ULAŞTI!                    ");
                        Console.WriteLine("=========================================================");
                        Console.WriteLine($"  Toplam Round Sayısı : {rountSayısı}");
                        Console.WriteLine($"  Yapılan Hamle Sayısı: {shiftSayısı}");
                        Console.WriteLine($"  Son Tahta Skoru     : {boardScore}");
                        Console.WriteLine($"  Toplam Oyun Skoru   : {gamescore}");
                        Console.WriteLine("=========================================================");
                        break;
                    }

                    // Sonsuz döngüye girmemesi için tur sınırı (İsteğe bağlı)
                    if (rountSayısı >= 100)
                    {
                        Console.WriteLine("\nBilgisayar 100 turda hedefe ulaşamadı ve durduruldu.");
                        break;
                    }

                    int eniyiscore = -1;
                    int eniyishift = -1;

                    for (int testshift = 1; testshift <= 12; testshift++)
                    {
                        char c1 = a1, c2 = a2, c3 = a3;
                        char c4 = a4, c5 = a5, c6 = a6;
                        char c7 = a7, c8 = a8, c9 = a9;

                        // 1-3: Satırları Sağa Kaydır
                        if (testshift == 1)
                        {
                            if (c2 == ' ') { c2 = c1; c1 = ' '; }
                            if (c3 == ' ') { c3 = c2; c2 = ' '; }
                            if (c2 == ' ') { c2 = c1; c1 = ' '; }
                        }
                        else if (testshift == 2)
                        {
                            if (c5 == ' ') { c5 = c4; c4 = ' '; }
                            if (c6 == ' ') { c6 = c5; c5 = ' '; }
                            if (c5 == ' ') { c5 = c4; c4 = ' '; }
                        }
                        else if (testshift == 3)
                        {
                            if (c8 == ' ') { c8 = c7; c7 = ' '; }
                            if (c9 == ' ') { c9 = c8; c8 = ' '; }
                            if (c8 == ' ') { c8 = c7; c7 = ' '; }
                        }
                        // 4-6: Satırları Sola Kaydır
                        else if (testshift == 4)
                        {
                            if (c2 == ' ') { c2 = c3; c3 = ' '; }
                            if (c1 == ' ') { c1 = c2; c2 = ' '; }
                            if (c2 == ' ') { c2 = c3; c3 = ' '; }
                        }
                        else if (testshift == 5)
                        {
                            if (c5 == ' ') { c5 = c6; c6 = ' '; }
                            if (c4 == ' ') { c4 = c5; c5 = ' '; }
                            if (c5 == ' ') { c5 = c6; c6 = ' '; }
                        }
                        else if (testshift == 6)
                        {
                            if (c8 == ' ') { c8 = c9; c9 = ' '; }
                            if (c7 == ' ') { c7 = c8; c8 = ' '; }
                            if (c8 == ' ') { c8 = c9; c9 = ' '; }
                        }
                        // 7-9: Sütunları Aşağı Kaydır
                        else if (testshift == 7)
                        {
                            if (c4 == ' ') { c4 = c1; c1 = ' '; }
                            if (c7 == ' ') { c7 = c4; c4 = ' '; }
                            if (c4 == ' ') { c4 = c1; c1 = ' '; }
                        }
                        else if (testshift == 8)
                        {
                            if (c5 == ' ') { c5 = c2; c2 = ' '; }
                            if (c8 == ' ') { c8 = c5; c5 = ' '; }
                            if (c5 == ' ') { c5 = c2; c2 = ' '; }
                        }
                        else if (testshift == 9)
                        {
                            if (c6 == ' ') { c6 = c3; c3 = ' '; }
                            if (c9 == ' ') { c9 = c6; c6 = ' '; }
                            if (c6 == ' ') { c6 = c3; c3 = ' '; }
                        }
                        // 10-12: Sütunları Yukarı Kaydır
                        else if (testshift == 10)
                        {
                            if (c4 == ' ') { c4 = c7; c7 = ' '; }
                            if (c1 == ' ') { c1 = c4; c4 = ' '; }
                            if (c4 == ' ') { c4 = c7; c7 = ' '; }
                        }
                        else if (testshift == 11)
                        {
                            if (c5 == ' ') { c5 = c8; c8 = ' '; }
                            if (c2 == ' ') { c2 = c5; c5 = ' '; }
                            if (c5 == ' ') { c5 = c8; c8 = ' '; }
                        }
                        else if (testshift == 12)
                        {
                            if (c6 == ' ') { c6 = c9; c9 = ' '; }
                            if (c3 == ' ') { c3 = c6; c6 = ' '; }
                            if (c6 == ' ') { c6 = c9; c9 = ' '; }
                        }

                        int simScore = 0;
                        if (c1 == t1 && c1 != ' ') simScore += (c1 - 64) * 1;
                        if (c2 == t2 && c2 != ' ') simScore += (c2 - 64) * 2;
                        if (c3 == t3 && c3 != ' ') simScore += (c3 - 64) * 1;
                        if (c4 == t4 && c4 != ' ') simScore += (c4 - 64) * 2;
                        if (c5 == t5 && c5 != ' ') simScore += (c5 - 64) * 4;
                        if (c6 == t6 && c6 != ' ') simScore += (c6 - 64) * 2;
                        if (c7 == t7 && c7 != ' ') simScore += (c7 - 64) * 1;
                        if (c8 == t8 && c8 != ' ') simScore += (c8 - 64) * 2;
                        if (c9 == t9 && c9 != ' ') simScore += (c9 - 64) * 1;

                        if (simScore > eniyiscore)
                        {
                            eniyiscore = simScore;
                            eniyishift = testshift;
                        }

                    }

                    if (eniyishift == -1 || eniyiscore <= boardScore)
                    {
                        eniyishift = rand.Next(1, 13);
                    }

                    int chosenShift = eniyishift;
                    rountSayısı++;
                    shiftSayısı++;

                    if (chosenShift == 1)
                    {
                        if (a2 == ' ') { a2 = a1; a1 = ' '; }
                        if (a3 == ' ') { a3 = a2; a2 = ' '; }
                        if (a2 == ' ') { a2 = a1; a1 = ' '; }
                    }
                    else if (chosenShift == 2)
                    {
                        if (a5 == ' ') { a5 = a4; a4 = ' '; }
                        if (a6 == ' ') { a6 = a5; a5 = ' '; }
                        if (a5 == ' ') { a5 = a4; a4 = ' '; }
                    }
                    else if (chosenShift == 3)
                    {
                        if (a8 == ' ') { a8 = a7; a7 = ' '; }
                        if (a9 == ' ') { a9 = a8; a8 = ' '; }
                        if (a8 == ' ') { a8 = a7; a7 = ' '; }
                    }
                    // 4-6: Satırları Sola Kaydır
                    else if (chosenShift == 4)
                    {
                        if (a2 == ' ') { a2 = a3; a3 = ' '; }
                        if (a1 == ' ') { a1 = a2; a2 = ' '; }
                        if (a2 == ' ') { a2 = a3; a3 = ' '; }
                    }
                    else if (chosenShift == 5)
                    {
                        if (a5 == ' ') { a5 = a6; a6 = ' '; }
                        if (a4 == ' ') { a4 = a5; a5 = ' '; }
                        if (a5 == ' ') { a5 = a6; a6 = ' '; }
                    }
                    else if (chosenShift == 6)
                    {
                        if (a8 == ' ') { a8 = a9; a9 = ' '; }
                        if (a7 == ' ') { a7 = a8; a8 = ' '; }
                        if (a8 == ' ') { a8 = a9; a9 = ' '; }
                    }
                    // 7-9: Sütunları Aşağı Kaydır
                    else if (chosenShift == 7)
                    {
                        if (a4 == ' ') { a4 = a1; a1 = ' '; }
                        if (a7 == ' ') { a7 = a4; a4 = ' '; }
                        if (a4 == ' ') { a4 = a1; a1 = ' '; }
                    }
                    else if (chosenShift == 8)
                    {
                        if (a5 == ' ') { a5 = a2; a2 = ' '; }
                        if (a8 == ' ') { a8 = a5; a5 = ' '; }
                        if (a5 == ' ') { a5 = a2; a2 = ' '; }
                    }
                    else if (chosenShift == 9)
                    {
                        if (a6 == ' ') { a6 = a3; a3 = ' '; }
                        if (a9 == ' ') { a9 = a6; a6 = ' '; }
                        if (a6 == ' ') { a6 = a3; a3 = ' '; }
                    }
                    // 10-12: Sütunları Yukarı Kaydır
                    else if (chosenShift == 10)
                    {
                        if (a4 == ' ') { a4 = a7; a7 = ' '; }
                        if (a1 == ' ') { a1 = a4; a4 = ' '; }
                        if (a4 == ' ') { a4 = a7; a7 = ' '; }
                    }
                    else if (chosenShift == 11)
                    {
                        if (a5 == ' ') { a5 = a8; a8 = ' '; }
                        if (a2 == ' ') { a2 = a5; a5 = ' '; }
                        if (a5 == ' ') { a5 = a8; a8 = ' '; }
                    }
                    else if (chosenShift == 12)
                    {
                        if (a6 == ' ') { a6 = a9; a9 = ' '; }
                        if (a3 == ' ') { a3 = a6; a6 = ' '; }
                        if (a6 == ' ') { a6 = a9; a9 = ' '; }
                    }

                    boardScore = 0;
                    if (a1 == t1 && a1 != ' ') boardScore += (a1 - 64) * 1;
                    if (a2 == t2 && a2 != ' ') boardScore += (a2 - 64) * 2;
                    if (a3 == t3 && a3 != ' ') boardScore += (a3 - 64) * 1;
                    if (a4 == t4 && a4 != ' ') boardScore += (a4 - 64) * 2;
                    if (a5 == t5 && a5 != ' ') boardScore += (a5 - 64) * 4;
                    if (a6 == t6 && a6 != ' ') boardScore += (a6 - 64) * 2;
                    if (a7 == t7 && a7 != ' ') boardScore += (a7 - 64) * 1;
                    if (a8 == t8 && a8 != ' ') boardScore += (a8 - 64) * 2;
                    if (a9 == t9 && a9 != ' ') boardScore += (a9 - 64) * 1;

                    Console.WriteLine();
                    Console.WriteLine($"Computer Shift: {chosenShift}");
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine($"--- Round {rountSayısı} ---                    --- Target Board ---");
                    Console.WriteLine();
                    Console.WriteLine("    7  8  9                             7  8  9");
                    Console.WriteLine("  +---------+                         +---------+");
                    Console.WriteLine($"1 | {a1}  {a2}  {a3} | 4                     1 | {t1}  {t2}  {t3} | 4                Board Score: {boardScore}");
                    Console.WriteLine($"2 | {a4}  {a5}  {a6} | 5                     2 | {t4}  {t5}  {t6} | 5 ");
                    Console.WriteLine($"3 | {a7}  {a8}  {a9} | 6                     3 | {t7}  {t8}  {t9} | 6");
                    Console.WriteLine("  +---------+                         +---------+ ");
                    Console.WriteLine("  10  11  12                          10  11  12     ");
                    Console.WriteLine("---------------------------------------------------------");

                    // Hamlelerin ekranda akıcı görünmesi için 1 saniye bekleme
                    System.Threading.Thread.Sleep(1000);


                }
            }
                    #endregion


            Console.Read();
            
        }

    }
}

