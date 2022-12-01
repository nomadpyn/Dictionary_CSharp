using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_CSharp 
{
    public class Dctnr
    {
        public string Name { get; set; }
        public Dictionary<string, List<string>> Data = new Dictionary<string, List<string>>();

        public Dctnr(string name)
        {
            this.Name = name;
            Console.WriteLine($"Создан словарь {this.Name}");
        }
        public override string ToString()
        {
            return $"Словарь {this.Name}. Количество слов {this.Data.Count}";
        }
        public void showDctnr()
        {
            foreach (var k in this.Data.Keys)
            {
                Console.WriteLine(k);
                foreach (var s in this.Data[k])
                {
                    Console.Write($"{s} ");
                }
                Console.WriteLine();
            }
        }
        public void searchWord()
        {
            Console.WriteLine("Введите слово для поиска");
            string word_key = Func.getWord();
            if (this.Data.ContainsKey(word_key))
            {
                Console.WriteLine($"Все варианты перевода {word_key}");
                foreach (var s in this.Data[word_key])
                {
                    Console.Write($"{s} ");
                }
                Console.WriteLine();
            }
        }
        public void addWord()
        {
            Console.WriteLine("Введите слово для перевода");
            string word_key = Func.getWord();
            Console.WriteLine("Введите перевод слова");
            string word_value = Func.getWord();

            if (this.Data.ContainsKey(word_key))
            {
                if (this.Data[word_key].Contains(word_value))
                {
                    Console.WriteLine("Такой перевод для такого слова уже существует");
                }
                else
                {
                    this.Data[word_key].Add(word_value);
                }
            }
            else
            {
                this.Data.Add(word_key, new List<string>());
                this.Data[word_key].Add(word_value);
            }

        }
        public void renameKey()
        {
            Console.WriteLine("Введите слово, которое надо изменить");
            string word_key = Func.getWord();
            Console.WriteLine("Введите слово на которое надо поменять");
            string new_word_key = Func.getWord();

            if (this.Data.ContainsKey(word_key))
            {
                if (this.Data.ContainsKey(new_word_key))
                {
                    Console.WriteLine("Невозможно сделать замену, такой слово уже существует");
                }
                else
                {
                    this.Data.Add(new_word_key, new List<string>());
                    this.Data[new_word_key] = this.Data[word_key];
                    this.Data.Remove(word_key);
                }

            }
            else
            {
                Console.WriteLine("Невозможно сделать замену, такого искомого слова не существует");
            }
        }
        public void renameValue()
        {
            Console.WriteLine("Введите слово, перевод для которого надо изменить");
            string word_key = Func.getWord();
            Console.WriteLine("Введите перевод, который надо поменять");
            string value = Func.getWord();
            Console.WriteLine("Введите на что поменять");
            string new_value = Func.getWord();
            if (this.Data.ContainsKey(word_key))
            {
                if (this.Data[word_key].Contains(value))
                {
                    int ind = this.Data[word_key].IndexOf(value);
                    this.Data[word_key][ind] = new_value;
                }
                else
                {
                    Console.WriteLine("Такого перевода нет, слово добавлено в перевод");
                    this.Data[word_key].Add(new_value);
                }
            }
            else
            {
                Console.WriteLine("Такого слова нет в словаре");
            }
        }
        public void deleteWord()
        {
            Console.WriteLine("Введите слово, которое надо удалить из словаря");
            string word_key = Func.getWord();
            if (this.Data.ContainsKey(word_key))
            {
                this.Data.Remove(word_key);
                Console.WriteLine("Слово удалено из словаря");
            }
            else
            {
                Console.WriteLine("Такого слова нет в словаре");
            }
        }
        public void deleteTranslate()
        {
            Console.WriteLine("Введите слово, для которого надо удалить перевод");
            string word_key = Func.getWord();
            if (this.Data.ContainsKey(word_key))
            {
                Console.WriteLine($"{word_key}, вариантов перевода: {this.Data[word_key].Count}");
                foreach (var s in this.Data[word_key])
                {
                    Console.Write($"{s} ");
                }
                Console.WriteLine();
                if (this.Data[word_key].Count == 1)
                {
                    Console.WriteLine("Вы не можете удалить перевод данного слова, т.к. он последний");
                }
                else
                {
                    Console.WriteLine("Какое слово из этих удалить?");
                    string delete = Func.getWord();
                    if (this.Data[word_key].Contains(delete))
                    {
                        this.Data[word_key].Remove(delete);
                    }
                    else
                    {
                        Console.WriteLine("Вы неправильно указали слово");
                    }
                }
            }
            else
            {
                Console.WriteLine("Такого слова нет в словаре");
            }
        }
    }
}
