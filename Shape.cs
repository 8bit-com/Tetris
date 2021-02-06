using static Tetris.Consts;
using System;

namespace Tetris
{
    class Shape
    {
        Random rand = new Random();

        public int[,] arr;

        public int[,] arrNext = new int[,] {  {  1, 1 },
                                              {  1, 1 } };
        public int X { get; set; }
        public int Y { get; set; }
        public Shape(int y, int x)
        {
            X = x;

            Y = y;

            Init();
        }

        public void Init()
        {
            arr = arrNext;

            switch (rand.Next(0, 8))
            {
                case 0:
                    arrNext = new int[,] {  {  1, 1 },
                                            {  1, 1 } };
                    break;
                case 1:
                    arrNext = new int[,] {  {1, 0, 1 },
                                            {1, 1, 1 } };
                    break;
                case 2:
                    arrNext = new int[,] {  {1, 1, 1, 1 } };
                    break;
                case 3:
                    arrNext = new int[,] {  {  1, 0 },
                                            {  1, 0 },
                                            {  1, 1 } };
                    break;
                case 4:
                    arrNext = new int[,] {  { 0, 1, 0 },
                                            { 1, 1, 1 } };
                    break;
                case 5:
                    arrNext = new int[,] {  {0, 1, 0 },
                                            {1, 1, 1 },
                                            {0, 1, 0 } };
                    break;
                case 6:
                    arrNext = new int[,] {  {0, 1, 1 },
                                            {1, 1, 0 } };
                    break;
                case 7:
                    arrNext = new int[,] {  {  0, 1 },
                                            {  0, 1 },
                                            {  1, 1 } };
                    break;
                default:
                    break;
            }
        }
        public void Rotate()
        {
            int[,] newArr = new int[arr.GetLength(1), arr.GetLength(0)];

            for (int i = 0; i < arr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    newArr[i, newArr.GetLength(1) - 1 - j] = arr[j, i];
                }
            }

            arr = newArr;
        }
        public void MoveDown()
        {
            int length = HIGHT - arr.GetLength(0);

            if (Y < length)
                Y++;
            else
                Y = 0;          
        }
        public void MoveRight()
        {
            int length = WIDTH - arr.GetLength(1) + 1;

            if (X < length) X++;
        }
        public void MoveLeft()
        {
            if (X > 0) X--;
        }
    }
}