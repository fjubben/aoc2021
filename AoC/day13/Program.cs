using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC
{
    class Day13
    {
        public static void Solve(string[] args)
        {
            problem1(@"C:\Users\jesols\workspace\aoc2021\AoC\day13\input.txt");
            //problem2(@"C:\Users\jesols\workspace\aoc2021\AoC\day11\input.txt");
        }
        public static void problem1(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            string[,] board = new string[500, 500];
            for (int i = 0; i < 500 * 500; i++) board[i / 500, i % 500] = " ";
            List<int> fx = new List<int>(), fy = new List<int>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("fold along y="))
                {
                    fy.Add(int.Parse(lines[i].Split('=')[1]));
                }
                if (lines[i].StartsWith("fold along x="))
                {
                    fx.Add(int.Parse(lines[i].Split('=')[1]));
                }
            }
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("fold")) continue;
                if (String.IsNullOrWhiteSpace(lines[i])) continue;

                int x = int.Parse(lines[i].Split(',')[0]);
                int y = int.Parse(lines[i].Split(',')[1]);
                foreach (int xfold in fx)
                {
                    if (x > xfold) x = Math.Abs(2 * xfold - x);
                }
                foreach (int yfold in fy)
                {
                    if (y > yfold) y = Math.Abs(2 * yfold - y);
                }

                board[y, x] = "#";
            }
            PrintBoard(board);
        }
        public static void PrintBoard(string[,] board)
        {
            int count = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(count);
        }
    }
}
