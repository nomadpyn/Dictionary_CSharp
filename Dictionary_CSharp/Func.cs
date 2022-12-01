using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        static public void saveFile(Dctnr obj)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            try
            {
                using (Stream fStream = File.Create($"{obj.Name}.bin"))
                {
                    binFormat.Serialize(fStream, obj);
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex);
            }            
        }
    }
}
