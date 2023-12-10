using System;
using System.Threading;

namespace Практическая___9
{
    internal class Exit
    {
        public void Exiting()
        {
            ConsoleColor[] colors = new ConsoleColor[] {
                ConsoleColor.Red,
                ConsoleColor.Green,
                ConsoleColor.Blue,
                ConsoleColor.Yellow,
                ConsoleColor.Magenta,
                ConsoleColor.Cyan,
                ConsoleColor.White
            };

            var startTime = DateTime.Now;

            while ((DateTime.Now - startTime).TotalSeconds < 7) 
            {
                foreach (var color in colors)
                {
                    if ((DateTime.Now - startTime).TotalSeconds >= 7) 
                        break;

                    Console.ForegroundColor = color;
                    PrintMessage();
                    Thread.Sleep(50);
                    Console.Clear();
                }
            }

        }

        static void PrintMessage()
        {
            Console.WriteLine("ДАМЫ И ГОСПОДА, \n\nЧУШПАН.exe ТЕПЕРЬ ВЛАСТЕЛИН ПК (#_#)");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("---------_/|_____|\\_---------");
            Console.WriteLine("-_   _--|           |--_   _-");
            Console.WriteLine("/ |_| \\-|   #   #   |-/ |_| \\");
            Console.WriteLine("| #_# |-|  _______  |-| #_# |");
            Console.WriteLine("\\_____/-|  |_|_|_|  |-\\_____/");
            Console.WriteLine("--| |   |___________|---| |-- ");
            Console.WriteLine("--| |---___|     |___---| |-- ");
            Console.WriteLine("--\\ \\--| #ЧУШПАН.exe |--/_/--");
            Console.WriteLine("---\\_^^|  **ЕЗДА ПК  |^^_/---");
            Console.WriteLine("-------|___/\\/.\\/\\___|-------");
        }
    }
}
