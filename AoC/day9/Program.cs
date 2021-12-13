using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC
{
    class Day9
    {
        public static void solve(string[] args)
        {
            //problem1(@"C:\Users\jesols\workspace\aoc2021\AoC\day9\input.txt");
            problem2(@"C:\Users\jesols\workspace\aoc2021\AoC\day9\input.txt");
        }
        public static void problem1(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            int[,] ground = new int[lines[0].Length + 2, lines.Length + 2];

            int jmax = ground.GetLength(0);
            int imax = ground.GetLength(1);

            for (int i = 0; i<imax; i++)
                for(int j = 0; j<jmax;j++)
                {
                    if((i == 0 || i == imax-1) || (j == 0 || j == jmax-1))
                    {
                        ground[j, i] = 9;
                    }
                }
            for (int i = 0; i < lines.Length; i++)
                for (int j = 0; j < lines[i].Length; j++)
                {
                    ground[j + 1, i +1 ] = int.Parse(lines[i].Substring(j, 1));
                }


            int count = 0;
            int sum = 0;
            for (int i = 0; i < lines.Length; i++)
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (ground[j + 1, i + 1] < ground[j + 1, i ] && ground[j + 1, i + 1] < ground[j, i + 1] && ground[j + 1, i + 1] < ground[j + 2, i + 1] && ground[j + 1, i + 1] < ground[j + 1, i + 2])
                    {
                        count++;
                        sum += ground[j + 1, i + 1] + 1;
                    }
                }

            for (int i = 0; i < imax; i++)
            {
                for (int j = 0; j < jmax; j++)
                {
                    Console.Write(ground[j, i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(count);
            Console.WriteLine(sum);
        }
        public static void problem2(string filename)
        {

        }

     
    }
}
