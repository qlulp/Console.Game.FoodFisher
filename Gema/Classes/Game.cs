using System;
using System.Threading;

namespace Game
{
    public class Game
    {
        private int[] FieldSize = new int[2]; // i - строки, j - столбцы
        private Player player;
        private Food food;
        private int Score = 0;
        private int MaxScore = 0;
        int Interval;
        private void Initialize(int i, int j) // Инициализация 
        {
            Score = 0;
            Interval = 200;
            FieldSize[0] = i;
            FieldSize[1] = j;
            player = new Player(FieldSize, Sign: "/\\");
            food = new Food(FieldSize);
        }

        public void Start(int i = 10, int j = 10)
        {
            Initialize(i, j);
            do
            {
                while (Console.KeyAvailable == false && player.Alive)
                {
                    Console.Clear();
                    food.Fall();
                    Output();
                    ScoreCheck();
                    Thread.Sleep(Interval); // Loop until input is entered.
                }
                    player.Step();
            } while (player.Alive);
            End();
        }

        private void End()
        {
            if (Score > MaxScore)
                MaxScore = Score;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ДЕД ВНУТРИ");
            Console.WriteLine("Score: {0}\nMax Score: {1}\n", Score, MaxScore);
            Console.ReadLine();
            Start(FieldSize[0], FieldSize[1]);
        }
        private bool ScoreCheck()
        {
            int MinInterval = 20;
            if (food.Position[0] == player.Position[0] && food.Position[1] == player.Position[1]) // условие food.Position == player.Position не работает
            {
                Score++;
                if (Interval > MinInterval)
                    Interval -= 10;
            }
            else if (food.Position[0] == FieldSize[0] - 1) // Заново
            {
                player.Alive = false;
            }
            return true;
        }

        private void Output() // Вывод
        {
            for (int i = 0; i < FieldSize[0]; i++)
            {
                for (int j = 0; j < FieldSize[1]; j++)
                {
                    
                    Console.BackgroundColor = ConsoleColor.Black;

                    if (food.Position[0] == i && food.Position[1] == j) // Еда
                        Console.BackgroundColor = food.Color;

                    if (player.Position[0] == i && player.Position[1] == j) // Игрок
                    {
                        Console.ForegroundColor = food.Color;
                        Console.Write(player.Sign);
                    }
                    else Console.Write("  ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
            Info();
        }

        private void Info()
        {
            Console.ForegroundColor = ConsoleColor.White;
            double Speed = 1000 / Interval; // Это ещё и FPS
            Console.WriteLine("Score: {0}\nSpeed: {1}", Score, Speed);
            Console.ForegroundColor = food.Color;
            Console.WriteLine(food.Name);
        }
    }
}
