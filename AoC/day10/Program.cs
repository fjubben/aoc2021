using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC
{
    class Day10
    {
        public static void Solve(string[] args)
        {
            problem1(@"C:\Users\jesols\workspace\aoc2021\AoC\day10\input.txt");
            //problem2(@"C:\Users\jesols\workspace\aoc2021\AoC\day10\input.txt");
        }
        public static void problem1(string filename)
        {
            string[] lines = File.ReadAllLines(filename);

            int sum = 0;
            List<long> fixnumbers = new List<long>();
            foreach(String line in lines)
            {
                Stack<char> par = new Stack<char>();
                //Stack<char> box = new Stack<char>();
                //Stack<char> squig = new Stack<char>();
                //Stack<char> ltgt = new Stack<char>();
                //int par = 0, box = 0, squig = 0, ltgt = 0;
                bool firsterror = false;
                foreach (char c in line.ToCharArray())
                {
                    if (firsterror) break;
                    if(c == '(' || c == '[' || c == '{' || c == '<')
                    {
                        par.Push(c);
                        continue;
                    }

                    if (c == ')')
                    {
                        if(par.Peek() == '(')
                        {
                            par.Pop();
                            continue;
                        }
                        sum += 3;
                        firsterror = true;
                    }
                    if (c == ']')
                    {
                        if (par.Peek() == '[')
                        {
                            par.Pop();
                            continue;
                        }
                        sum += 57;
                        firsterror = true;

                    }
                    if (c == '}')
                    {
                        if (par.Peek() == '{')
                        {
                            par.Pop();
                            continue;
                        }
                        sum += 1197;
                        firsterror = true;

                    }
                    if (c == '>')
                    {
                        if (par.Peek() == '<')
                        {
                            par.Pop();
                            continue;
                        }
                        sum += 25137;
                        firsterror = true;
                    }
                }
                if (!firsterror)
                {
                    long fixsum = 0;
                    while(par.Count > 0)
                    {
                        fixsum *= 5;
                        switch (par.Pop())
                        {
                            case '(':
                                fixsum += 1;
                                break;
                            case '[':
                                fixsum += 2;
                                break;
                            case '{':
                                fixsum += 3;
                                break;
                            case '<':
                                fixsum += 4;
                                break;
                        }
                    }
                    fixnumbers.Add(fixsum);
                }
            }
            foreach ( long nbr in fixnumbers)
            {
                Console.WriteLine(nbr);
            }
            fixnumbers.Sort();
            Console.WriteLine(fixnumbers[fixnumbers.Count / 2]);
            //Console.WriteLine(sum);
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
