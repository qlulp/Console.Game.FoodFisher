using System;

namespace Game
{
    class Food
    {
        private int[] ArrSize = new int[2] { 10, 10 };
        public int[] Position = new int[2];
        public ConsoleColor Color;
        public string Name;

        public Food(int[] ArrSize)
        {
            this.ArrSize = ArrSize;
            Generate();
        }

        private void Generate()
        {
            Random Rand = new Random();
            Position[0] = 0;
            Position[1] = Rand.Next(0, ArrSize[1]);

            switch (Rand.Next(0, 3))
            {
                case 0:
                    Name = "Orange";
                    Color = ConsoleColor.Yellow;
                    break;
                case 1:
                    Name = "Apple";
                    Color = ConsoleColor.Red;
                    break;
                case 2:
                    Name = "Qiwi";
                    Color = ConsoleColor.Green;
                    break;
            }
        }

        public void Fall()
        {
            if (Position[0] < ArrSize[0] - 1)
                Position[0]++;
            else Generate();

        }
    }
}
