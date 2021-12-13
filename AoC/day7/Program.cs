using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
namespace AoC
{
    class Day7
    {
        public static void Solve(string[] args)
        {
            //problem1(@"C:\Users\jesols\workspace\aoc2021\AoC\day7\input.txt");
            problem2(@"C:\Users\jesols\workspace\aoc2021\AoC\day7\input.txt");
        }

        public static void problem1(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            lines = lines[0].Split(',');
            int[] positions = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
                positions[i] = int.Parse(lines[i]);

            int fuelsum;
            int min = 1000000000, index = -1;
            for(int i = 0; i<positions.Length; i++)
            {
                fuelsum = 0;
                for(int j = 0; j<positions.Length; j++)
                {
                    fuelsum += Math.Abs(positions[j] - i);
                }
                if (fuelsum < min)
                {
                    min = fuelsum;
                    index = i;
                }
                Console.Write(i + ":" + fuelsum + " ");
            }
            Console.WriteLine();
            float average = 0;
            foreach (int pos in positions)
                average += pos;
            average = average / positions.Length;
            Console.WriteLine(index + ":" + min + " " + average);

        }
        public static void problem2(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            lines = lines[0].Split(',');
            int[] positions = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
                positions[i] = int.Parse(lines[i]);

            int fuelsum;
            int min = 1000000000, index = -1;
            for (int i = 0; i < positions.Length; i++)
            {
                fuelsum = 0;
                for (int j = 0; j < positions.Length; j++)
                {
                    for (int k = 1; k<= Math.Abs(positions[j] - i); k++)
                        fuelsum += k;
                }
                if (fuelsum < min)
                {
                    min = fuelsum;
                    index = i;
                }
                Console.Write(i + ":" + fuelsum + " ");
            }
            Console.WriteLine();
            float average = 0;
            foreach (int pos in positions)
                average += pos;
            average = average / positions.Length;
            Console.WriteLine(index + ":" + min + " " + average);



        }
    }
}
