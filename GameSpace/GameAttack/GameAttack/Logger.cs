using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAttack
{
    /// <summary>
    /// Класс содержит два метода
    /// для записи в консоль и в файл 
    /// событий игры
    /// </summary>
    static class Logger
    {
                       
        static public void WriteToConsole(string msg)
        {
            Console.WriteLine("CONSOLE LOG:" + msg);
        }

        static public void WriteToFile(string msg)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"GameAttack.log", true))
            {
                file.WriteLine(msg);
            }
        }
    }
}
