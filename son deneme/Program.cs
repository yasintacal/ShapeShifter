using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace son_deneme
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

            #region Oyuncu seçimi
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
            Console.WriteLine("-------------------------------------------------------");

            #endregion

            int notos, nos, nosh;
            char rchar;
            Random rand = new Random();
            notos = rand.Next(1, 6);
            if (notos== 1)
            {
                nos = rand.Next(1, 2);
                rchar = (char)rand.Next(65, 66);
            }
            else if ( notos == 2)
            {
                nos = rand.Next(1, 3);
                rchar = (char)rand.Next(65, 67);
            }
            else if ( notos == 3)
            {
                nos = rand.Next(1, 4);
                rchar = (char)rand.Next(65, 68);
            }
            else if ( notos == 4)
            {
                nos = rand.Next(1, 5);
                rchar = (char)rand.Next(65, 69);
            }
            else if ( notos == 5)
            {
                nos = rand.Next(1, 6);
                rchar = (char)rand.Next(65, 70);
            }
           


            





        }
    }
}
