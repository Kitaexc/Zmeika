using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая___9
{
    class SnakeGame
    {
        private int width = 20;
        private int height = 20;
        private int[] food = new int[2];
        private List<int[]> snake = new List<int[]>();
        private string direction = "RIGHT";
        private bool gameOver;
        public SnakeGame()
        {
            Console.CursorVisible = false;
            StartPosition();
            CreateFood();
        }

        private void StartPosition()
        {
            gameOver = false;
            snake.Clear();
            snake.Add(new int[] { width / 2, height / 2 });
            snake.Add(new int[] { width / 2 - 1, height / 2 });
            snake.Add(new int[] { width / 2 - 2, height / 2 });
        }

        private void CreateFood()
        {
            Random rnd = new Random();
            food[0] = rnd.Next(1, width - 1);
            food[1] = rnd.Next(1, height - 1);
        }

        private void Input()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.W:
                        if (direction != "DOWN") direction = "UP";
                        break;
                    case ConsoleKey.S:
                        if (direction != "UP") direction = "DOWN";
                        break;
                    case ConsoleKey.A:
                        if (direction != "RIGHT") direction = "LEFT";
                        break;
                    case ConsoleKey.D:
                        if (direction != "LEFT") direction = "RIGHT";
                        break;
                }
            }
        }

        private void Logic()
        {
            //Туша движется
            for (int i = snake.Count - 1; i > 0; i--)
            {
                snake[i] = new int[] { snake[i - 1][0], snake[i - 1][1] };
            }
            //Ебало движется
            switch (direction)
            {
                case "UP":
                    snake[0][1]--;
                    break;
                case "DOWN":
                    snake[0][1]++;
                    break;
                case "LEFT":
                    snake[0][0]--;
                    break;
                case "RIGHT":
                    snake[0][0]++;
                    break;
            }

            if (snake[0][0] == food[0] && snake[0][1] == food[1]) // Хуярить в еду
            {
                int[] lastSegment = snake[snake.Count - 1];
                int[] newSegment = new int[2];
                newSegment[0] = lastSegment[0];
                newSegment[1] = lastSegment[1];
                snake.Add(newSegment);
                CreateFood();
            }

            for (int i = 1; i < snake.Count; i++) // Хуярить в тело 
            {
                if (snake[i][0] == snake[0][0] && snake[i][1] == snake[0][1])
                {
                    gameOver = true;
                }
            }

            // ЧИШО, ХУЯРИМ В СТЕНУ?
            if (snake[0][0] < 0 || snake[0][0] >= width || snake[0][1] < 0 || snake[0][1] >= height)
            {
                gameOver = true;
            }
        }

        private void Draw()
        {
            Console.Clear();

            // Нашпакливали стену
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("#");
                Console.SetCursorPosition(i, height);
                Console.Write("#");
            }
            for (int i = 0; i <= height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("#");
                Console.SetCursorPosition(width, i);
                Console.Write("#");
            }

            // Нашпакливали еду 
            Console.SetCursorPosition(food[0], food[1]);
            Console.Write("*");

            // Ебать змея, вся в меня, нашпаклюем
            foreach (int[] part in snake)
            {
                Console.SetCursorPosition(part[0], part[1]);
                Console.Write("o");
            }

            // Я скорость, КЧАУ НАХУЙ
            Thread.Sleep(100);
        }

        public void Run()
        {
            while (!gameOver)
            {
                Draw();
                Input();
                Logic();
            }
            Console.SetCursorPosition(width / 2 - 4, height / 2);
            Console.Write("Game Over");
            Thread.Sleep(1000);
        }
    }
}