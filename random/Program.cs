using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random rand = new Random();
            int number1;
            number1 = rand.Next(1, 10);
            Console.SetCursorPosition(2, 6);
            Console.WriteLine(number1);


            Console.Read();
        }
    }
}
