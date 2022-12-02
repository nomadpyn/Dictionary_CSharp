using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_CSharp
{
    internal class Menu
    {
        static public void Level()
        {
            Console.WriteLine("Программа \"Словари\"");
            Console.WriteLine("Что вы хотите сделать:");
            ConsoleKeyInfo choise;
            do
            {
                Console.WriteLine("1- Открыть словарь, 0 - Выход");
                choise = Console.ReadKey();
                Console.Clear();
                switch (choise.Key)
                {
                    case ConsoleKey.D1:
                        {
                            Console.Clear();
                            Menu.Level1();
                            break;
                        }
                    case ConsoleKey.D0:
                        {
                            Console.WriteLine("До свидания!");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Вы не сделали выбор");
                            break;
                        }
                }
            }
            while (choise.Key != ConsoleKey.D1 && choise.Key != ConsoleKey.D0);
  
        }
        static void Level1()
        {
            string path = Func.getPath();
            ConsoleKeyInfo choise;
            do
            {
                Console.WriteLine("1 - Создать(открыть) словарь, 0 - В начало");
                choise = Console.ReadKey();
                Console.Clear();
                switch (choise.Key)
                {
                    case ConsoleKey.D1:
                        {
                            Dctnr A = null;
                            if (path == "null")
                            {
                                Console.WriteLine("Введите имя словаря");
                                A = new Dctnr(Console.ReadLine());
                            }
                            else
                            {
                                A = Func.getFile(path);
                            }
                            Menu.Level2(ref A);
                            break;
                        }
                    case ConsoleKey.D0:
                        {
                            Menu.Level();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Вы не сделали выбор");
                            break;
                        }
                }
            }
            while (choise.Key != ConsoleKey.D1 && choise.Key != ConsoleKey.D0);

        }
        
    }
}
    
