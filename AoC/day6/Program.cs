using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
namespace AoC
{
    class Day6
    {
        public static void Solve(string[] args)
        {
           // problem1(@"C:\Users\jesols\workspace\aoc2021\AoC\day6\input.txt");
            problem2(@"C:\Users\jesols\workspace\aoc2021\AoC\day6\input.txt");
        }

        public static void problem1(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            lines = lines[0].Split(',');
            List<int> states = new List<int>();

            for (int i = 0; i < lines.Length; i++)
                states.Add(int.Parse(lines[i]));

            int n = 80;
            Console.Write("initial day: ");
            foreach (int k in states)
                Console.Write(k + ",");
            Console.WriteLine();
            for (int i = 1; i<=n; i++)
            {
                IterateState(ref states);
                //Console.Write("after day " + i + ": ");
                //foreach (int k in states)
                //    Console.Write(k + ",");
                //Console.WriteLine();
            }
            Console.WriteLine(states.Count);

           
        }
        public static void IterateState(ref List<int> states)
        {
            int added = 0;
            for (int i= 0; i<states.Count; i++)
            {
                states[i] -= 1;
                if (states[i] == -1)
                {
                    states[i] = 6;
                    states.Add(9);
                }
            }
        }

        public static void problem2(string filename)
        {
            String[] lines = File.ReadAllLines(filename);
            lines = lines[0].Split(',');

            long days = 257;
            long[,] fishdays = new long[days, 2];
            for (long i = 0; i < days; i++) fishdays[i % days, 1] = 0;
            fishdays[0, 0] = lines.Length;

            for (long i = 0; i < lines.Length; i++)
            {
                long spawn = long.Parse(lines[i]);
                for (long j = spawn; j < days; j += 7)
                {
                    fishdays[j, 1] += 1;
                }
            }

            for (long iter = 0; iter < days; iter++)
            {
                if (iter == days - 1) break;
                fishdays[iter + 1, 0] = fishdays[iter, 0];
                fishdays[iter + 1, 0] += fishdays[iter, 1];
                for (long k = iter+9; k<days; k += 7)
                {
                    fishdays[k, 1] += fishdays[iter, 1];
                }
            }


            Console.Write(fishdays[255, 0] + " + " + fishdays[255,1] +  " = " + fishdays[256,0]);

            //Console.WriteLine();
            //for (int i = 0; i < fishdays.GetLength(0); i++)
            //{
            //    Console.Write(fishdays[i, 0] + "\t");
            //}



        }
    }
}
