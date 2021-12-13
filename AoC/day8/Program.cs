using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC
{
    class Day8
    {
        public static void solve(string[] args)
        {
            problem1(@"C:\Users\jesols\workspace\aoc2021\AoC\day8\input.txt");
            //problem2(@"C:\Users\jesols\workspace\aoc2021\AoC\day8\input.txt");
        }
        public static void problem1(string filename)
        {
            string[] lines = File.ReadAllLines(filename);

            int total_sum = 0;

            foreach (string line in lines)
            {

                string[] segments = line.Split('|');
                string[] input = segments[0].Trim().Split(" ");
                string[] output = segments[1].Trim().Split(" ");


                int[] I = new int[input.Length];
                for (int i = 0; i < input.Length; i++)
                {

                    switch (input[i].Length)
                    {
                        case 2:
                            I[1] = i;
                            break;
                        case 3:
                            I[7] = i;
                            break;
                        case 4:
                            I[4] = i;
                            break;
                        case 7:
                            I[8] = i;
                            break;
                    }
                }
                string fourdiff = FindUnique(input[I[1]], input[I[4]]);
                for (int i = 0; i < input.Length; i++)
                {

                    switch (input[i].Length)
                    {
                        case 5:
                            if (Subset(input[I[1]], input[i]))
                            {
                                I[3] = i;
                            } else if (Subset(fourdiff, input[i])) {
                                I[5] = i;
                            } else
                            {
                                I[2] = i;
                            }
                            break;
                        case 6:
                            if (Subset(input[I[4]], input[i]))
                            {
                                I[9] = i;
                            }
                            else if (Subset(input[I[1]], input[i]))
                            {
                                I[0] = i;
                            }
                            else
                            {
                                I[6] = i;
                            }
                            break;
                    }
                }
                int multiplier = 1000;
                int localsum = 0;
                for (int k = 0; k < output.Length; k++)
                {
                    for(int i = 0; i<10; i++)
                    {
                        if(String.IsNullOrEmpty(FindUnique(input[I[i]], output[k])))
                        {
                            total_sum += i * multiplier;
                            localsum += i * multiplier;
                        } 
                    
                    }
                    multiplier = multiplier / 10;
                }

                foreach (string o in output)
                    Console.Write(o + " ");
                Console.WriteLine(" : " + localsum);
            }
            Console.WriteLine(" : " + total_sum);

        }
        public static string FindUnique(string first, string second)
        {
            string ret = "";
            foreach (char c in first)
            {
                if (!second.Contains(c))
                {
                    ret += c;
                }
            }
            foreach (char c in second)
            {
                if (!first.Contains(c))
                {
                    ret += c;
                }
            }
            return ret;

        }

        public static bool Subset(string first, string second)
        {
            bool result = true;
            foreach(char c in first)
            {
                if (!second.Contains(c))
                {
                        result = false;
                }
            }
            return result;
        }
        
    }
}
