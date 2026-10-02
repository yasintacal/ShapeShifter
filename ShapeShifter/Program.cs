using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeShifter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("----------------------------");
            Console.WriteLine("       ShapeShifter      ");
            Console.WriteLine("----------------------------");
            Console.WriteLine("----------------------------");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Game Mode");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Player = Human/Computer");
            Console.WriteLine("Symbols = A,B,C");
            Console.WriteLine("Number Of Symbols = 4");
            Console.WriteLine("Number Of Shift = 15");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine("--- Round 1 ---                    --- Target Board ---");
            Console.WriteLine();
            Console.WriteLine("    7  8  9                             7  8  9");
            Console.WriteLine("  +---------+                         +---------+");
            Console.WriteLine("1 |         | 4                     1 |         | 4 ");
            Console.WriteLine("2 |         | 5                     2 |         | 5           Board Score = 0 ");
            Console.WriteLine("3 |         | 6                     3 |         | 6");
            Console.WriteLine("  +---------+                         +---------+ ");
            Console.Write("  10  11  12                          10  11  12     ");

            Random rand = new Random();
            char rchar;
            int sütun = 0, satır = 0;
            rchar = (char)rand.Next('A', 'D');
            sütun = rand.Next(1, 4);
            satır = rand.Next(19, 22);
            Console.SetCursorPosition((sütun * 3) + 1, satır);
            Console.Write(rchar);


            char rchar2;
            int sütun2 = 0, satır2 = 0;
            rchar2 = (char)rand.Next('A', 'D');
            //sütun = rand.Next(1, 4);
            //satır = rand.Next(19, 22);
            bool cakisiyor2 = true;
            while (cakisiyor2)
            {
                sütun2 = rand.Next(1, 4);
                satır2 = rand.Next(19, 22);
                if (satır == satır2 && sütun == sütun2)
                {
                    cakisiyor2 = (true);

                }
                else
                {
                    cakisiyor2 = (false);

                }

            }

            Console.SetCursorPosition((sütun2 * 3) + 1, satır2);
            Console.Write(rchar2);


            char rchar3;
            int sütun3 = 0, satır3 = 0;
            rchar3 = (char)rand.Next('A', 'D');
            //sütun = rand.Next(1, 4);
            //satır = rand.Next(19, 22);
            bool cakisiyor3 = true;
            while (cakisiyor3)
            {
                sütun3 = rand.Next(1, 4);
                satır3 = rand.Next(19, 22);
                if (satır == satır3 && sütun == sütun3 || sütun2 == sütun3 && satır2 == satır3)
                {
                    cakisiyor3 = (true);
                }
                else
                {
                    cakisiyor3 = (false);
                }

            }
            Console.SetCursorPosition((sütun3 * 3) + 1, satır3);
            Console.Write(rchar3);

            //Random rand = new Random();

            //// --- 1. HARF ---
            //char rchar1 = (char)rand.Next('A', 'D');
            //int sutun1 = rand.Next(1, 4);
            //int satir1 = rand.Next(19, 22);

            //Console.SetCursorPosition((sutun1 * 3) + 1, satir1);
            //Console.Write(rchar1);


            //// --- 2. HARF ---
            //char rchar2 = (char)rand.Next('A', 'D');
            //int sutun2 = 0;
            //int satir2 = 0;
            //bool cakisiyor2 = true;

            //while (cakisiyor2)
            //{
            //    sutun2 = rand.Next(1, 4);
            //    satir2 = rand.Next(19, 22);

            //    // 1. harfle aynı yere denk geldi mi?
            //    if (sutun2 == sutun1 && satir2 == satir1)
            //    {
            //        cakisiyor2 = true;  // Çakışma var, döngü tekrar döner
            //    }
            //    else
            //    {
            //        cakisiyor2 = false; // Yer boş, döngü biter
            //    }
            //}

            //Console.SetCursorPosition((sutun2 * 3) + 1, satir2);
            //Console.Write(rchar2);


            //// --- 3. HARF ---
            //char rchar3 = (char)rand.Next('A', 'D');
            //int sutun3 = 0;
            //int satir3 = 0;
            //bool cakisiyor3 = true;

            //while (cakisiyor3)
            //{
            //    sutun3 = rand.Next(1, 4);
            //    satir3 = rand.Next(19, 22);

            //    // 1. veya 2. harfle aynı yere denk geldi mi?
            //    if ((sutun3 == sutun1 && satir3 == satir1) || (sutun3 == sutun2 && satir3 == satir2))
            //    {
            //        cakisiyor3 = true;  // Çakışma var, tekrar dene
            //    }
            //    else
            //    {
            //        cakisiyor3 = false; // İkisiyle de çakışmıyor, çık
            //    }
            //}

            //Console.SetCursorPosition((sutun3 * 3) + 1, satir3);
            //Console.Write(rchar3);








            Console.Read();

        }

    }
}
