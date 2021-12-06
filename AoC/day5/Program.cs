using System;
using System.Collections.Generic;
using System.IO;
namespace AoC
{
    class Day5
    {
        public static void Solve(string[] args)
        {
            //problem1(@"C:\Users\jesols\workspace\aoc2021\AoC\day5\input.txt");
            problem2(@"C:\Users\jesols\workspace\aoc2021\AoC\day5\input.txt");
        }

        public static void problem1(string filename)
        {
            String[] lines = File.ReadAllLines(filename);
            int[,] board = new int[1000, 1000];
            for (int i = 0; i < 1000*1000; i++) board[i % 1000, i / 1000] = 0;
            foreach (string line in lines)
            {
                int x1 = int.Parse(line.Split("->")[0].Trim().Split(',')[0]);
                int y1 = int.Parse(line.Split("->")[0].Trim().Split(',')[1]);
                int x2 = int.Parse(line.Split("->")[1].Trim().Split(',')[0]);
                int y2 = int.Parse(line.Split("->")[1].Trim().Split(',')[1]);

                if (x1 == x2)
                {
                    if (y1 > y2)
                    {
                        var tmp = y1;
                        y1 = y2;
                        y2 = tmp;
                    }

                    for ( int i = y1; i <= y2; i++)
                    {
                        board[i, x1] += 1; 
                    }
                }
                if (y1 == y2)
                {
                    if (x1 > x2)
                    {
                        var tmp = x1;
                        x1 = x2;
                        x2 = tmp;
                    }

                    for (int i = x1; i <= x2; i++)
                    {
                        board[y1, i] += 1;
                    }
                }
            }

            int count = 0;
            for (int i = 0; i < 1000 * 1000; i++)
            {
                if (board[i % 1000, i / 1000] > 1) count++;
            }
            Console.WriteLine(count);
        }

        public static void problem2(string filename)
        {
            String[] lines = File.ReadAllLines(filename);
            int n = 1000;
            int[,] board = new int[n, n];
            for (int i = 0; i < n * n; i++) board[i % n, i / n] = 0;
            foreach (string line in lines)
            {
                int x1 = int.Parse(line.Split("->")[0].Trim().Split(',')[0]);
                int y1 = int.Parse(line.Split("->")[0].Trim().Split(',')[1]);
                int x2 = int.Parse(line.Split("->")[1].Trim().Split(',')[0]);
                int y2 = int.Parse(line.Split("->")[1].Trim().Split(',')[1]);

              //  Console.WriteLine(x1 + " " + y1 + "->" + x2 + " " + y2);
              //  var keyPress = Console.ReadKey();

                if (x1 == y1 && x2 == y2)
                {
                    if (x1 > x2)
                    {
                        var tmp = y1;
                        y1 = y2;
                        y2 = tmp;
                        tmp = x1;
                        x1 = x2;
                        x2 = tmp;
                    }
                    for (int i = x1; i <= x2; i++)
                    {
                        board[i, i] += 1;
                    }
                    continue;
                }

                if (Math.Abs(x1-x2) == Math.Abs(y1 - y2))
                {
                    if (x1 > x2)
                    {
                        var tmp = y1;
                        y1 = y2;
                        y2 = tmp;
                        tmp = x1;
                        x1 = x2;
                        x2 = tmp;
                    }
                    int dir = 1;
                    if (y2 < y1) dir = -1;
                    for (int i = 0; i <= Math.Abs(x1-x2); i++)
                    {
                        board[y1 + (i * dir), x1 + i] += 1;
                    }
                    continue;

                }

                if (x1 == x2)
                {
                    if (y1 > y2)
                    {
                        var tmp = y1;
                        y1 = y2;
                        y2 = tmp;
                    }

                    for (int i = y1; i <= y2; i++)
                    {
                        board[i, x1] += 1;
                    }
                }
                if (y1 == y2)
                {
                    if (x1 > x2)
                    {
                        var tmp = x1;
                        x1 = x2;
                        x2 = tmp;
                    }

                    for (int i = x1; i <= x2; i++)
                    {
                        board[y1, i] += 1;
                    }
                }
            }
           // printBoard(board);
            Console.WriteLine();
            Console.WriteLine();
            int count = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] > 1) count++;
                }
            }
            Console.WriteLine(count);

        }
        public static void printBoard(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
