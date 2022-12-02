using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
                                string name = Console.ReadLine();
                                if (Func.fileIsExist(name))
                                {
                                    Console.WriteLine("Такой словарь уже существует, загружаем его");
                                    A = Func.getFile(name+".bin");
                                }
                                else
                                {
                                    A = new Dctnr(name);
                                }
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
                            Menu.Level3(ref obj);
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
        static void Level3(ref Dctnr obj)
        {
            ConsoleKeyInfo choise;
            Console.WriteLine(obj);
            do
            {
                Console.WriteLine("1 - Добавить слово, 2 - Заменить слово или перевод, 3 - Удалить слово или перевод, 4 - Сохранить перевод в файл, 5 - Назад, 0 - в начало" );
                choise = Console.ReadKey();
                Console.Clear();
                switch (choise.Key)
                {
                    case ConsoleKey.D1:
                        {
                            obj.addWord();
                            Func.saveFile(obj);
                            if (Menu.ContinueWork() == false)
                                Menu.Level();
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            switch (Menu.oneOrTwo())
                            {
                                case 1:
                                    {
                                        obj.renameKey();
                                        if (Menu.ContinueWork() == false)
                                            Menu.Level();
                                        break;
                                    }
                                case 2:
                                    {
                                        obj.renameValue();
                                        if (Menu.ContinueWork() == false)
                                            Menu.Level();
                                        break;
                                    }
                                case 0:
                                    {
                                        break;
                                    }
                            }
                            Func.saveFile(obj);
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            switch (Menu.oneOrTwo())
                            {
                                case 1:
                                    {
                                        obj.deleteWord();
                                        if (Menu.ContinueWork() == false)
                                            Menu.Level();
                                        break;
                                    }
                                case 2:
                                    {
                                        obj.deleteTranslate();
                                        if (Menu.ContinueWork() == false)
                                            Menu.Level();
                                        break;
                                    }
                                case 0:
                                    {
                                        break;
                                    }
                            }
                            Func.saveFile(obj);
                            break;
                        }
                    case ConsoleKey.D4:
                        {
                            obj.saveTranslate();
                            break;
                        }
                    case ConsoleKey.D5:
                        {
                            break;
                        }
                    case ConsoleKey.D0:
                        {
                            Menu.Level();
                            break;
                        }
                }
            }while(choise.Key != ConsoleKey.D5);
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
        static byte oneOrTwo()
            {
                Console.WriteLine("1 - слово, 2 - перевод");
                byte choise = 0;
                try
                {
                    choise = byte.Parse(Console.ReadLine());
                    if (choise == 1)
                        return choise;
                    if (choise == 2)
                    return choise;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Неправильный формат ввода");
                }
                return choise;
            }
                
            
    }
}
    
