using System;
using System.Collections.Generic;
using System.IO;
namespace AoC
{
    class Day4
    {
        public static void Solve(string[] args)
        {
            problem1(@"C:\Users\jesols\workspace\aoc2021\AoC\day4\input.txt");
            problem2(@"C:\Users\jesols\workspace\aoc2021\AoC\day4\input.txt");
        }

        public static void problem1(string filename)
        {
            String[] lines = File.ReadAllLines(filename);
            String[] bingo_sequence = lines[0].Split(',');
            const int n = 5;
            int[,] bingoBoard = new int[n, n];
            IDictionary<string, (int, int)> bingoindex;
            int minSolve = 1000;
            int minindex = -1;
            IDictionary<string, (int, int)> victoryMap = new Dictionary<string, (int, int)> ();

            for (int i = 2; i < lines.Length; i = i + 6)
            {
                bingoindex = new Dictionary<string, (int, int)>();
                for (int j = 0; j<n; j++)
                {
                    String[] row = lines[i + j].Trim().Replace("  ", " ").Split(' ');
                    for (int k = 0; k < n; k++)
                    {
                        bingoindex.Add(row[k], (j, k));
                        bingoBoard[j, k] = 1;
                    }
                }
                var output = run_sequence(bingo_sequence, bingoindex, bingoBoard);
                if (output.Item1 < minSolve)
                {
                    minSolve = output.Item1;
                    minindex = i;
                    victoryMap = output.Item2;
                }
            }
            Console.WriteLine(minindex + " " + minSolve);
            int sum = 0;
            foreach ( string s in victoryMap.Keys)
                sum += int.Parse(s);
            Console.WriteLine(bingo_sequence[minSolve-1] + " " + sum);
            Console.WriteLine(int.Parse(bingo_sequence[minSolve - 1]) * sum);
        }
        public static void problem2(string filename)
        {
            String[] lines = File.ReadAllLines(filename);
            String[] bingo_sequence = lines[0].Split(',');
            const int n = 5;
            int[,] bingoBoard = new int[n, n];
            IDictionary<string, (int, int)> bingoindex;
            int maxSolve = -1;
            int minindex = -1;
            IDictionary<string, (int, int)> victoryMap = new Dictionary<string, (int, int)>();

            for (int i = 2; i < lines.Length; i = i + 6)
            {
                bingoindex = new Dictionary<string, (int, int)>();
                for (int j = 0; j < n; j++)
                {
                    String[] row = lines[i + j].Trim().Replace("  ", " ").Split(' ');
                    for (int k = 0; k < n; k++)
                    {
                        bingoindex.Add(row[k], (j, k));
                        bingoBoard[j, k] = 1;
                    }
                }
                var output = run_sequence(bingo_sequence, bingoindex, bingoBoard);
                if (output.Item1 > maxSolve)
                {
                    maxSolve = output.Item1;
                    minindex = i;
                    victoryMap = output.Item2;
                }
            }
            Console.WriteLine(minindex + " " + maxSolve);
            int sum = 0;
            foreach (string s in victoryMap.Keys)
                sum += int.Parse(s);
            Console.WriteLine(bingo_sequence[maxSolve - 1] + " " + sum);
            Console.WriteLine(int.Parse(bingo_sequence[maxSolve - 1]) * sum);
        }
        public static (int, IDictionary<string, (int, int)>) run_sequence(string[] seq, IDictionary<string, (int, int)> bingomap, int[,] board)
        {
            int count = 0;
            foreach (string s in seq)
            {
                count++;
                if (bingomap.ContainsKey(s))
                {
                    var ind = bingomap[s];
                    bingomap.Remove(s);
                    board[ind.Item1, ind.Item2] = -1;
                    if (check_board(board)) return (count, bingomap);
                }
            }
            return (-1, bingomap);
        }
        public static bool check_board(int[,] board)
        {
            for (int i=0; i<board.GetLength(0); i++)
            {
                int rowsum = 0, colsum = 0;
                for (int j=0; j<board.GetLength(1); j++)
                {
                    rowsum += board[i, j];
                    colsum += board[j, i];

                }
                if (rowsum == -5 || colsum == -5) return true;
            }
            return false;
        }
    }
}
