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
                            Environment.Exit(0);
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
        static void Level2(ref Dctnr obj)
        {
            ConsoleKeyInfo choise;
            Console.WriteLine(obj);
            do
            {
                Console.WriteLine("1 - Показать весь словарь, 2 - Искать слово, 3 - Операции со словарем, 0 - В начало");
                choise = Console.ReadKey();
                Console.Clear();
                switch (choise.Key)
                {
                    case ConsoleKey.D1:
                        {
                            obj.showDctnr();
                            if (Menu.ContinueWork() == false)
                                Menu.Level();
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            obj.searchWord();
                            if (Menu.ContinueWork() == false)
                                Menu.Level();
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            Menu.Level3();
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
            while (choise.Key != ConsoleKey.D0);
        }
        static bool ContinueWork()
        {
                Console.WriteLine("Продолжить работу?\nY - Да, N(любое другое) - нет");
                ConsoleKeyInfo choise = Console.ReadKey();
            Console.Clear();
                if (choise.Key == ConsoleKey.Y)
                    return true;
                else 
                    return false;
        }
    }
}
    
