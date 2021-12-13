using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC
{
    class Day11
    {
        public static void Solve(string[] args)
        {
            problem1(@"C:\Users\jesols\workspace\aoc2021\AoC\day11\input.txt");
            //problem2(@"C:\Users\jesols\workspace\aoc2021\AoC\day11\input.txt");
        }
        public static void problem1(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            int n = 1000;
            int[,,] board = new int[lines.Length,lines[0].ToCharArray().Length,2];

            for (int i = 0; i < lines.Length; i++)
            {
                char[] line = lines[i].ToCharArray();
                for (int j = 0; j< line.Length; j++)
                {
                    board[i, j, 0] = int.Parse(line[j].ToString());
                    board[i, j, 1] = 1;
                }

            }
            int count = 0;
            for (int step = 0; step < n; step++)
            {
                int stepcount = 0;
                for (int i = 0; i < lines.Length; i++)
                {
                    for (int j = 0; j < lines[0].ToCharArray().Length; j++)
                    {
                        IncrementNumber(i, j, ref board, ref stepcount); 
                    }

                }
                count += stepcount;
                ResetBoard(ref board);
                if (stepcount == 100)
                {
                   Console.WriteLine("step" + step);
                    
                }
               // PrintBoard(board);
            }
            Console.WriteLine(count);

        }
        public static void PrintBoard(int[,,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j, 0]);
                }
                Console.WriteLine();
            }
        }


        public static void IncrementNumber(int i, int j, ref int[,,] board, ref int count)
        {
            if (board[i, j, 1] == 0) return;

            board[i, j, 0] += 1;

            if (board[i, j, 0] == 10)
            {
                count++;
                board[i, j, 0] = 0;
                board[i, j, 1] = 0;

                if (i > 0)
                {
                    IncrementNumber(i - 1, j, ref board, ref count);
                    if (j > 0)
                    {
                        IncrementNumber(i - 1, j - 1, ref board, ref count);
                    }
                    if (j < board.GetLength(1) - 1)
                    {
                        IncrementNumber(i - 1, j + 1, ref board, ref count);
                    }
                }
                if (i < board.GetLength(0) - 1)
                {
                    IncrementNumber(i + 1, j, ref board, ref count);
                    if (j > 0)
                    {
                        IncrementNumber(i + 1, j - 1, ref board, ref count);
                    }
                    if (j < board.GetLength(1) - 1)
                    {
                        IncrementNumber(i + 1, j + 1, ref board, ref count);
                    }

                }
                if (j > 0)
                {
                    IncrementNumber(i, j - 1, ref board, ref count);
                }
                if (j < board.GetLength(1) - 1)
                {
                    IncrementNumber(i, j + 1, ref board, ref count);
                }
            }
        }
        public static void ResetBoard(ref int[,,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++) {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j, 1] = 1;
                }
            }
        }

        public static void problem2(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            int[,] ground = new int[lines[0].Length + 2, lines.Length + 2];
            int[,] basinmap = new int[lines[0].Length + 2, lines.Length + 2];
            int jmax = ground.GetLength(0);
            int imax = ground.GetLength(1);

          
        }
    }
}
