using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_CSharp
{
    public class Func
    {
        static public string getWord()
        {
            string word;
            do
            {
                word = Console.ReadLine();

                if (word == "")
                {
                    Console.WriteLine("Вы не ввели слово");
                }
            }
            while (word == "");

            return word;
        }
    }
}
