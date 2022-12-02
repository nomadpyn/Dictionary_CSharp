using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        static public Dctnr getFile(string fileName)
        {
            Dctnr temp = null;
            BinaryFormatter binFormat = new BinaryFormatter();
            try
            {
                using (Stream fStream = File.OpenRead(fileName))
                {
                    temp = (Dctnr)binFormat.Deserialize(fStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return temp;
        }
        static public string getPath()
        {
            DirectoryInfo dir = new DirectoryInfo(".");
            FileInfo[] files = dir.GetFiles("*.bin");
            if (files.Length > 0)
            {
                Console.WriteLine("В папке есть словари");

                foreach (FileInfo file in files)
                {
                    Console.WriteLine(file.Name);
                }
                Console.WriteLine($"Выберете словарь из списка по номеру до {files.Length} или нажмите 0");
                int choise = 0; 
                try 
                {
                choise = int.Parse(Console.ReadLine());
                }
                catch(FormatException e)
                {
                    Console.WriteLine("Неправильный формат ввода");
                }
                if (choise == 0)
                {
                    return "null";
                }
                else
                {
                    choise--;
                }
                try
                {
                    return files[choise].Name;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Вы неправильно выбрали номер файла.");
                    return "null";
                }

                
            }
            else
            {
                Console.WriteLine("В папке нет словарей");
                return "null";
            }
        }
    }
}
