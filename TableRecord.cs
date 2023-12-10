using System;
using System.Threading;

namespace Практическая___9
{
    internal class TableRecord
    {
        public void Recording()
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
            Console.WriteLine("ХИ-ХИ-ХИ-ХИ-ХИ-ХИ-ХИ ТАКОГО В ТЗ НЕ БЫЛО №_№ x:D");
        }
    }
}
