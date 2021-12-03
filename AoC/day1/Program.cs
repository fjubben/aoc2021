using System;
using System.IO;
namespace AoC
{
    class Day1
    {
        public static void Solve(string[] args)
        {
            Console.WriteLine(problem1(@"C:\Users\SEOLSSONJESP\source\repos\AoC\AoC\day1\input.txt"));
            Console.WriteLine(problem2(@"C:\Users\SEOLSSONJESP\source\repos\AoC\AoC\day1\input.txt"));
        }

        public static int problem1(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            int count = 0;
            for (int i = 1; i < lines.Length; i++)
            {
                if (int.Parse(lines[i]) > int.Parse(lines[i - 1])) count++;
            }
            return count;
        }
        public static int problem2(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            int count = 0;
            for (int i = 1; i < lines.Length - 2; i++)
            {
                if (int.Parse(lines[i-1]) + int.Parse(lines[i]) + int.Parse(lines[i + 1]) < int.Parse(lines[i]) + int.Parse(lines[i + 1]) + int.Parse(lines[i + 2])) count++;
            }
            return count;
        }
    }
}
