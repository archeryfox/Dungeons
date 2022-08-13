using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons
{
    internal class Launcher 
    {
        static void Main(string[] args)
        {
            R CodeR = new R();
            V CodeV = new V();
            Console.WriteLine("\t\tВыберите версию игры:\n\n >Версия Ростика - клавиша R\n >Версия Вити - клавиша V\n");
            Console.WriteLine($"              _\r\n            ,/A\\,\r\n          .//`_`\\\\,\r\n        ,//`____-`\\\\,\r\n      ,//`[_ROVER_]`\\\\,\r\n    ,//`=  ==  __-  _`\\\\,\r\n   //|__=  __- == _  __|\\\\\r\n   ` |  __ .-----.  _  | `\r\n     | - _/       \\-   |\r\n     |__  | .-\"-. | __=|\r\n     |  _=|/)   (\\|    |\r\n     |-__ (/ a a \\) -__|\r\n     |___ /`\\_Y_/`\\____|\r\n          \\)8===8(/");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.R: CodeR.Run(); break;
                case ConsoleKey.V: CodeV.Run(); break;
                default:
                    Console.Clear();
                    Console.WriteLine("Не та кнопка. Нажмите указанные!");
                    Main(args);
                    break;
            }
            CodeV.Run();
            CodeR.Run();
        }
    }
}
