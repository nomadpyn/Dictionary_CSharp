using System;
using System.Collections.Generic;
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
    }
}
