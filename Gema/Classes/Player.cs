using System;

namespace Game
{
    class Player
    {
        private int[] ArrSize = new int[2] { 10, 10 };
        public int[] Position = new int[2] { 0, 0 };
        public ConsoleColor Color = ConsoleColor.White;
        public string Name;
        public bool Alive;
        public string Sign = "__";

        public Player(int[] ArrSize, string Name = "Anton", string Sign = "__")
        {
            this.ArrSize = ArrSize;
            Position[0] = ArrSize[0] - 1;
            Position[1] = ArrSize[1] / 2;
            this.Name = Name;
            Alive = true;
            if (Sign.Length == 2)
                this.Sign = Sign;
        }

        public void Step() // Сделать шаг
        {
            if (this.Alive)
            {
                ConsoleKeyInfo InputKey = Console.ReadKey();
                switch (InputKey.Key)
                {
                    /*
                    case ConsoleKey.UpArrow:
                        if (Position[0] > 0)
                        {
                            Position[0]--;
                        }
                        else if (Position[0] == 0)
                            Position[0] = ArrSize[0] - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (Position[0] < ArrSize[0] - 1)
                        {
                            Position[0]++;
                        }
                        else if (Position[0] == ArrSize[0] - 1)
                            Position[0] = 0;
                        break;
                    */
                    case ConsoleKey.LeftArrow:
                        if (Position[1] > 0)
                        {
                            Position[1]--;
                        }
                        else if (Position[1] == 0)
                            Position[1] = ArrSize[1] - 1;
                        break;
                    case ConsoleKey.RightArrow:
                        if (Position[1] < ArrSize[1] - 1)
                        {
                            Position[1]++;
                        }
                        else if (Position[1] == ArrSize[1] - 1)
                            Position[1] = 0;
                        break;
                }
            }
        }
    }
}
