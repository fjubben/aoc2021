using System;
using System.IO;
namespace AoC
{
    class Day2
    {
        public static void Solve(string[] args)
        {
            Console.WriteLine(problem1(@"C:\Users\jesols\workspace\aoc2021\AoC\day2\input.txt"));
            Console.WriteLine(problem2(@"C:\Users\jesols\workspace\aoc2021\AoC\day2\input.txt"));
        }

        public static int problem1(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            int horiz = 0;
            int depth = 0;
            foreach (string line in lines)
            {
                string commando = line.Split(" ")[0];
                int amount  = int.Parse(line.Split(" ")[1]);


                switch (commando)
                {
                    case "forward":
                        horiz += amount;
                        break;
                    case "up":
                        depth -= amount;
                        break;
                    case "down":
                        depth += amount;
                        break;
                }
            }
            return horiz*depth;
        }
        public static int problem2(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            int horiz = 0;
            int aim = 0;
            int depth = 0;
            foreach (string line in lines)
            {
                string commando = line.Split(" ")[0];
                int amount = int.Parse(line.Split(" ")[1]);
                switch (commando)
                {
                    case "forward":
                        horiz += amount;
                        depth += aim * amount;
                        break;
                    case "up":
                        aim -= amount;
                        break;
                    case "down":
                        aim += amount;
                        break;
                }
            }
            return horiz * depth;
        }
    }
}
