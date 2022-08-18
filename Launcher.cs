using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons
{
    internal class Launcher 
    {
        static public int ExitLvl = 0;
        /// <summary>
        /// Этот метод выравнивает строку по центру
        /// </summary>
        /// <param name="str"></param>
        static public void Centering(string str)
        {
            int margin = (48 - str.Length)/2;
            for (int i = 0; i < margin; i++)
            {
            Console.Write(" ");
            }
            Console.Write(str);
        }
        
        static public void Centering(int stroke, string str)
        {
            int margin = (48 - str.Length) / 2;
                Console.WriteLine();
            for (int i = 0; i < margin; i++)
            {
                Console.Write(" ");
            }
            Console.Write(str);
        }
        /// <summary>
        /// Отступает N строк, пишет строку по центру
        /// </summary>
        /// <param name="str"></param>
        /// <param name="stroke"></param>
        /// 
        static public void CenteringI(int stroke, string str )
        {
            int margin = (48 - str.Length) / 2;
            for (int i = 0; i < stroke; i++)
            {
            Console.WriteLine();
            }
            for (int i = 0; i < margin; i++)
            {
                Console.Write(" ");
            }
            Console.Write(str);
        }
        /// <summary>
        /// Отступает N строк, пишет строку по центру, отступает N строк
        /// </summary>
        /// <param name="n"></param>
        /// <param name="str"></param>
        static public void CenteringW(int n, string str)
        {
            int margin = (48 - str.Length) / 2;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
            }
            for (int i = 0; i < margin; i++)
            {
                Console.Write(" ");
            }
            Console.Write(str);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
            }
        }
        static public void Main()
        { 
            Console.Clear();
            Console.CursorVisible = false;
            R CodeR = new R();
            V CodeV = new V();
            
            Console.WriteLine("\t\tВыберите версию игры:\n" +
                "\n > Версия Ростика - клавиша R" +
                "\n > Версия Вити(Демо) - клавиша V\n\n Для выхода из игры нажмите Esc");
            Console.WriteLine($"              _\r\n            ,/A\\,\r\n          .//`_`\\\\,\r\n        ,//`____-`\\\\,\r\n      ,//`[_ROVER_]`\\\\,\r\n    ,//`=  ==  __-  _`\\\\,\r\n   //|__=  __- == _  __|\\\\\r\n   ` |  __ .-----.  _  | `\r\n     | - _/       \\-   |\r\n     |__  | .-\"-. | __=|\r\n     |  _=|/)   (\\|    |\r\n     |-__ (/ a a \\) -__|\r\n     |___ /`\\_Y_/`\\____|\r\n          \\)8===8(/");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.R: Console.Clear(); CodeR.Run(); break;
                case ConsoleKey.V: Console.Clear(); CodeV.Run(); break;
                case ConsoleKey.Escape: Environment.Exit(0); break;
                default:
                    Console.Clear();
                    Console.WriteLine("Не та кнопка. Нажмите указанные!");
                    Main();
                break;
            }
        }
    }
}
