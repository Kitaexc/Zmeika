using System;

namespace Практическая___9
{
    public class UserInterface
    {
        public void ShowMainMenu()
        {
            bool isRunning = true;
            int selectedButton = 0;

            while (isRunning)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("                                           Разминай свои пальчики, будет жарко!");
                Console.ForegroundColor = ConsoleColor.White;

                DisplayButton("Играть", 0, selectedButton == 0);
                DisplayButton("Таблица рекордов", 1, selectedButton == 1);
                DisplayButton("Уйти:(", 2, selectedButton == 2);

                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedButton = Math.Max(0, selectedButton - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedButton = Math.Min(2, selectedButton + 1);
                        break;
                    case ConsoleKey.Enter:
                        ExecuteButtonAction(selectedButton, ref isRunning);
                        break;
                }
            }
        }

        static void DisplayButton(string text, int position, bool isSelected)
        {
            int consoleWidth = Console.WindowWidth;
            int textLength = text.Length;
            int centerPosition = (consoleWidth / 2) - (textLength / 2);
            int verticalSpacing = 1; 
            int verticalPosition = position * verticalSpacing + 2;

            if (isSelected)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.SetCursorPosition(centerPosition, verticalPosition);
            Console.WriteLine(text);

            Console.ResetColor();
        }

        static void ExecuteButtonAction(int buttonIndex, ref bool isRunning)
        {
            switch (buttonIndex)
            {
                case 0:
                    SnakeGame game = new SnakeGame();
                    game.Run();
                    break;
                case 1:
                    TableRecord table = new TableRecord();
                    table.Recording();
                    break;
                case 2:
                    Exit exit = new Exit();
                    exit.Exiting();
                    isRunning = false;
                    break;
            }
        }
    }
}