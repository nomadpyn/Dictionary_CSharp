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
        
    }
}
