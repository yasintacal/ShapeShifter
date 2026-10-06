using System;

class Program
{
    static void Main(string[] args)
    {
        #region Oyun Başlığı ve Giriş
        Console.WriteLine("================================================================================");
        Console.WriteLine("                        [ 3x3 SHAPESHIFTER STRATEGY GAME ]");
        Console.WriteLine("================================================================================\n");

        Console.Write("Please choose player (Human: 1, Computer: 2): ");
        int player = Convert.ToInt32(Console.ReadLine());
        while (player != 1 && player != 2)
        {
            Console.Write("Invalid input. (1 or 2): ");
            player = Convert.ToInt32(Console.ReadLine());
        }

        Console.Write("Choose Number of Types of Symbols (NOTOS) (1-5): ");
        int notos = Convert.ToInt32(Console.ReadLine());
        while (notos < 1 || notos > 5)
        {
            Console.Write("Invalid input (1-5): ");
            notos = Convert.ToInt32(Console.ReadLine());
        }

        Console.Write("Choose Number of Symbols (NOS) (1-6): ");
        int nos = Convert.ToInt32(Console.ReadLine());
        while (nos < 1 || nos > 6)
        {
            Console.Write("Invalid input (1-6): ");
            nos = Convert.ToInt32(Console.ReadLine());
        }

        Console.Write("Choose Number of Shifts (NOSH) (1-20): ");
        int nosh = Convert.ToInt32(Console.ReadLine());
        while (nosh < 1 || nosh > 20)
        {
            Console.Write("Invalid input (1-20): ");
            nosh = Convert.ToInt32(Console.ReadLine());
        }
        #endregion

        #region Tahtaların İlk Kurulumu
        char a1 = ' ', a2 = ' ', a3 = ' ', a4 = ' ', a5 = ' ', a6 = ' ', a7 = ' ', a8 = ' ', a9 = ' ';
        char t1 = ' ', t2 = ' ', t3 = ' ', t4 = ' ', t5 = ' ', t6 = ' ', t7 = ' ', t8 = ' ', t9 = ' ';

        Random rand = new Random();
        int yerlesen = 0;

        while (yerlesen < nos)
        {
            char rchar = (char)rand.Next(65, 65 + notos);
            int secim = rand.Next(1, 10);
            bool solaKondu = false;

            if (secim == 1 && a1 == ' ') { a1 = rchar; solaKondu = true; }
            else if (secim == 2 && a2 == ' ') { a2 = rchar; solaKondu = true; }
            else if (secim == 3 && a3 == ' ') { a3 = rchar; solaKondu = true; }
            else if (secim == 4 && a4 == ' ') { a4 = rchar; solaKondu = true; }
            else if (secim == 5 && a5 == ' ') { a5 = rchar; solaKondu = true; }
            else if (secim == 6 && a6 == ' ') { a6 = rchar; solaKondu = true; }
            else if (secim == 7 && a7 == ' ') { a7 = rchar; solaKondu = true; }
            else if (secim == 8 && a8 == ' ') { a8 = rchar; solaKondu = true; }
            else if (secim == 9 && a9 == ' ') { a9 = rchar; solaKondu = true; }

            if (solaKondu)
            {
                bool sagaKondu = false;
                while (!sagaKondu)
                {
                    int secim2 = rand.Next(1, 10);
                    if (secim2 == 1 && t1 == ' ') { t1 = rchar; sagaKondu = true; }
                    else if (secim2 == 2 && t2 == ' ') { t2 = rchar; sagaKondu = true; }
                    else if (secim2 == 3 && t3 == ' ') { t3 = rchar; sagaKondu = true; }
                    else if (secim2 == 4 && t4 == ' ') { t4 = rchar; sagaKondu = true; }
                    else if (secim2 == 5 && t5 == ' ') { t5 = rchar; sagaKondu = true; }
                    else if (secim2 == 6 && t6 == ' ') { t6 = rchar; sagaKondu = true; }
                    else if (secim2 == 7 && t7 == ' ') { t7 = rchar; sagaKondu = true; }
                    else if (secim2 == 8 && t8 == ' ') { t8 = rchar; sagaKondu = true; }
                    else if (secim2 == 9 && t9 == ' ') { t9 = rchar; sagaKondu = true; }
                }
                yerlesen++;
            }
        }
        #endregion

        #region Ana Oyun Döngüsü
        int round = 1;
        bool oyunBitti = false;

        while (round <= nosh && !oyunBitti)
        {
            // 1. Puan Hesaplama (Köşeler: 1, Kenarlar: 2, Merkez: 4)
            int boardScore = 0;
            if (a1 != ' ' && a1 == t1) boardScore += (a1 - 'A' + 1) * 1;
            if (a2 != ' ' && a2 == t2) boardScore += (a2 - 'A' + 1) * 2;
            if (a3 != ' ' && a3 == t3) boardScore += (a3 - 'A' + 1) * 1;
            if (a4 != ' ' && a4 == t4) boardScore += (a4 - 'A' + 1) * 2;
            if (a5 != ' ' && a5 == t5) boardScore += (a5 - 'A' + 1) * 4;
            if (a6 != ' ' && a6 == t6) boardScore += (a6 - 'A' + 1) * 2;
            if (a7 != ' ' && a7 == t7) boardScore += (a7 - 'A' + 1) * 1;
            if (a8 != ' ' && a8 == t8) boardScore += (a8 - 'A' + 1) * 2;
            if (a9 != ' ' && a9 == t9) boardScore += (a9 - 'A' + 1) * 1;

            // 2. Ekranı Yazdırma
            Console.WriteLine($"\n--- Round {round} ---                                --- Target Board ---");
            Console.WriteLine($"Board Score: {boardScore}");
            Console.WriteLine("     7  8  9                                    7  8  9");
            Console.WriteLine("   +---------+                                +---------+");
            Console.WriteLine($" 1 | {a1}  {a2}  {a3} | 4                            1 | {t1}  {t2}  {t3} | 4");
            Console.WriteLine($" 2 | {a4}  {a5}  {a6} | 5                            2 | {t4}  {t5}  {t6} | 5");
            Console.WriteLine($" 3 | {a7}  {a8}  {a9} | 6                            3 | {t7}  {t8}  {t9} | 6");
            Console.WriteLine("   +---------+                                +---------+");
            Console.WriteLine("    10 11 12                                   10 11 12");

            // 3. Hedefe Tam Ulaşıldı mı Kontrolü
            if (a1 == t1 && a2 == t2 && a3 == t3 &&
                a4 == t4 && a5 == t5 && a6 == t6 &&
                a7 == t7 && a8 == t8 && a9 == t9)
            {
                Console.WriteLine("\n Tebrikler! Hedef tahtayı tamamladınız!");
                oyunBitti = true;
                break;
            }

            // 4. Hamle Alma (Human)
            Console.Write("\nShift (1-12): ");
            int shift = Convert.ToInt32(Console.ReadLine());
            while (shift < 1 || shift > 12)
            {
                Console.Write("Geçersiz hamle! Lütfen 1-12 arası bir shift girin: ");
                shift = Convert.ToInt32(Console.ReadLine());
            }

            // 5. Kaydırma (Shift) Mantığı
            char x1 = ' ', x2 = ' ', x3 = ' ';

            // İlgili satır/sütun elemanlarını al
            if (shift == 1 || shift == 4) { x1 = a1; x2 = a2; x3 = a3; }
            else if (shift == 2 || shift == 5) { x1 = a4; x2 = a5; x3 = a6; }
            else if (shift == 3 || shift == 6) { x1 = a7; x2 = a8; x3 = a9; }
            else if (shift == 7 || shift == 10) { x1 = a1; x2 = a4; x3 = a7; }
            else if (shift == 8 || shift == 11) { x1 = a2; x2 = a5; x3 = a8; }
            else if (shift == 9 || shift == 12) { x1 = a3; x2 = a6; x3 = a9; }

            // Dolu olan harfleri sırayla topla
            char c1 = ' ', c2 = ' ', c3 = ' ';
            int doluSayisi = 0;
            if (x1 != ' ') { if (doluSayisi == 0) c1 = x1; else if (doluSayisi == 1) c2 = x1; else c3 = x1; doluSayisi++; }
            if (x2 != ' ') { if (doluSayisi == 0) c1 = x2; else if (doluSayisi == 1) c2 = x2; else c3 = x2; doluSayisi++; }
            if (x3 != ' ') { if (doluSayisi == 0) c1 = x3; else if (doluSayisi == 1) c2 = x3; else c3 = x3; doluSayisi++; }

            // Sağa ya da Aşağı Kaydırma (1, 2, 3 veya 7, 8, 9) -> Sona yaslanır
            if (shift >= 1 && shift <= 3 || shift >= 7 && shift <= 9)
            {
                if (doluSayisi == 1) { x1 = ' '; x2 = ' '; x3 = c1; }
                else if (doluSayisi == 2) { x1 = ' '; x2 = c1; x3 = c2; }
                else if (doluSayisi == 3) { x1 = c1; x2 = c2; x3 = c3; }
            }
            // Sola ya da Yukarı Kaydırma (4, 5, 6 veya 10, 11, 12) -> Başa yaslanır
            else
            {
                if (doluSayisi == 1) { x1 = c1; x2 = ' '; x3 = ' '; }
                else if (doluSayisi == 2) { x1 = c1; x2 = c2; x3 = ' '; }
                else if (doluSayisi == 3) { x1 = c1; x2 = c2; x3 = c3; }
            }

            // Değişen harfleri tahtadaki yerlerine geri yaz
            if (shift == 1 || shift == 4) { a1 = x1; a2 = x2; a3 = x3; }
            else if (shift == 2 || shift == 5) { a4 = x1; a5 = x2; a6 = x3; }
            else if (shift == 3 || shift == 6) { a7 = x1; a8 = x2; a9 = x3; }
            else if (shift == 7 || shift == 10) { a1 = x1; a4 = x2; a7 = x3; }
            else if (shift == 8 || shift == 11) { a2 = x1; a5 = x2; a8 = x3; }
            else if (shift == 9 || shift == 12) { a3 = x1; a6 = x2; a9 = x3; }

            round++;
        }
        #endregion

        #region Oyun Sonu Puanı (Game Score)
        int finalBoardScore = 0;
        if (a1 != ' ' && a1 == t1) finalBoardScore += (a1 - 'A' + 1) * 1;
        if (a2 != ' ' && a2 == t2) finalBoardScore += (a2 - 'A' + 1) * 2;
        if (a3 != ' ' && a3 == t3) finalBoardScore += (a3 - 'A' + 1) * 1;
        if (a4 != ' ' && a4 == t4) finalBoardScore += (a4 - 'A' + 1) * 2;
        if (a5 != ' ' && a5 == t5) finalBoardScore += (a5 - 'A' + 1) * 4;
        if (a6 != ' ' && a6 == t6) finalBoardScore += (a6 - 'A' + 1) * 2;
        if (a7 != ' ' && a7 == t7) finalBoardScore += (a7 - 'A' + 1) * 1;
        if (a8 != ' ' && a8 == t8) finalBoardScore += (a8 - 'A' + 1) * 2;
        if (a9 != ' ' && a9 == t9) finalBoardScore += (a9 - 'A' + 1) * 1;

        int kullanilanHamle = round - 1;
        int gameScore = (10 * finalBoardScore) + (notos * nos * (nosh - kullanilanHamle));

        Console.WriteLine("\n================ GAME OVER ================");
        Console.WriteLine($"Final Board Score : {finalBoardScore}");
        Console.WriteLine($"Remaining Shifts  : {nosh - kullanilanHamle}");
        Console.WriteLine($"Total Game Score  : {gameScore}");
        Console.WriteLine("===========================================");
        Console.ReadLine();
        #endregion
    }
}
