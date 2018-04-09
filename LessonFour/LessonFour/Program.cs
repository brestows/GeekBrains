using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonFour
{
    class Program
    {
        static void Main(string[] args)
        {
            //Кол-во элементов в списке
            int maxElement = 30;
            Random rnd = new Random();
            // Заполняем список случайными числами от  0 до 10
            List<int> RandomList = Enumerable.Range(0, maxElement).Select(x => rnd.Next(0,10)).ToList();
            foreach (int i in RandomList)
                Console.Write($"{i}, ");
            Console.WriteLine("");
            // Задание А
            ListMetod.intListElementMatch(RandomList);
            List<string> CityList = new List<string>()
            {
                "Париж","Лондон","Минск", "Варшава","Москва","Ливерпуль","Лисабон","Киев", "Кишинев",
                "Брест","Лондон","Минск", "Варшава","Кравков","Мадрид","Лисабон","Киев", "Берлин",
                "Париж","Санкт-Петербург","Минск", "Варшава","Москва","Мадрид","Лисабон","Киев", "Кишинев",
                "Брест","Лондон","Минск", "Варшава","Москва","Мадрид","Лисабон","Киев", "Кишинев",
                "Париж","Лондон","Минск", "Варшава","Москва","Барселона","Лисабон","Киев", "Кишинев",
                "Париж","Манчестер","Минск", "Гданьск","Москва","Санкт-Петербург","Лисабон","Киев", "Сочи",

            };
            // Задание Б
            ListMetod.tmpListElementMatch(CityList);
            //Задание В
            ListMetod.lnqListElementMatch(RandomList);

            Console.ReadKey();
        }
    }
}
