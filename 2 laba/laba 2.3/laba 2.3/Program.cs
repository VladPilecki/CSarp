using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            string letters = "abcdefghijklmnopqrstuvwxyz";
            string res;
            int letter;

            for (int i = 1; i <= 4; i++)
            {
                letter = random.Next(0, 26);
                res = String.Concat(letters[letter]);
                Console.Write(res);
            }
            Console.ReadKey();
        }
       
    }
   
}
