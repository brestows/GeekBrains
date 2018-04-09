using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four", 4 },
                {"two",  2 },
                { "one", 1 },
                {"three",3 },
            };
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> item) { return item.Value; });
            var l = dict.OrderBy(e => e.Value);
            
            //Исходный вариант
            foreach (var item in d)
                Console.WriteLine($"{item.Key} - {item.Value}");

            Console.WriteLine();

            //Лямда вариант
            foreach (var item in d)
                Console.WriteLine($"{item.Key} - {item.Value}");

            Console.ReadKey();
        }
    }
}
