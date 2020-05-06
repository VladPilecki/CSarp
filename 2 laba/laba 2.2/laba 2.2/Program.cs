using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;

            string lettersRUS = "ЁЙЦУКЕНГШЩЗХЪЭЖДЛОРПАВЫФЯЧСМИТЬБЮ";

            str = Console.ReadLine();

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < lettersRUS.Length; j++)
                {
                    if (str[i] == lettersRUS[j])

                        Console.Write(str[i]);
                   
                }
                
            }
            Console.ReadKey();
        }
        
    }
    
}
