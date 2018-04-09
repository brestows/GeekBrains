using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonFour
{
    /// <summary>
    /// Статический класс, с методами обработки коллекций
    /// </summary>
    public static class ListMetod
    {
        /// <summary>
        /// Метод подсчета сопадений элементов коллекции 
        /// </summary>
        /// <param name="lst">Анализируемая коллекция</param>
        public static void intListElementMatch(List<int> lst)
        {
            SortedDictionary<int, int> dic = new SortedDictionary<int, int>();
            foreach (int i in lst)
                dic[i] = (dic.ContainsKey(i)) ? ++dic[i] : 1;
            foreach (KeyValuePair<int, int> item in dic)
                Console.WriteLine($"{item.Key} найдено сопадений: {item.Value}.");
        }
        /// <summary>
        /// Не отличается от метода intListElentMatch
        /// </summary>
        /// <typeparam name="T">Тип обрабатываемой коллекции</typeparam>
        /// <param name="lst">Анализируемая коллекция</param>
        public static void tmpListElementMatch<T> (List<T> lst)
        {
            SortedDictionary<T, int> dic = new SortedDictionary<T, int>();
            foreach (T i in lst)
                dic[i] = (dic.ContainsKey(i)) ? ++dic[i] : 1;
            foreach (KeyValuePair<T, int> item in dic)
                Console.WriteLine($"{item.Key} найдено сопадений: {item.Value}.");
        }
        /// <summary>
        /// Анализируем коллекцию спомощью linq
        /// </summary>
        /// <param name="lst">Анализируемая коллекция</param>
        public static void lnqListElementMatch(List<int> lst)
        {
            SortedDictionary<int, int> dic = new SortedDictionary<int, int>();
            foreach (int i in lst)
            {
                var tmp = from n in lst where n == i select n;
                if (!dic.ContainsKey(i))  dic[i] = tmp.Count();
            }
            foreach (KeyValuePair<int, int> item in dic)
                Console.WriteLine($"{item.Key} найдено сопадений: {item.Value}.");
        }
    }
}
