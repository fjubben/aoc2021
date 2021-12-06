using System;
using System.IO;
namespace AoC
{
    class Day3
    {
        public static void Solve(string[] args)
        {
           // problem1(@"C:\Users\jesols\workspace\aoc2021\AoC\day3\input.txt");
            problem2(@"C:\Users\jesols\workspace\aoc2021\AoC\day3\input.txt");
        }

        public static void problem1(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            short n = 12;
            Char[] bits = new Char[n];
            Char[] reverseBits = new Char[n];
            int[] average = new int[n];

            foreach (string line in lines)
            {
                bits = line.ToCharArray();
                for (int i = 0; i < bits.Length; i++)
                    average[i] += (bits[i] == '1' ? 1 : -1);
                Console.WriteLine(line + ": " +  string.Join(" ", average));
            }
            Console.WriteLine(string.Join(" ", average));
            reverseBits = new char[bits.Length];
            for (int i = 0; i < average.Length; i++)
            {
                bits[i] = average[i] > 0 ? '1' : '0';
                reverseBits[i] = average[i] < 0 ? '1' : '0';
            }


            Int32 mask = Convert.ToInt32(string.Join("",bits), 2);
            Int32 rmask = Convert.ToInt32(string.Join("", reverseBits), 2);
            Console.WriteLine(long.Parse(bits) + ": " + mask + '\n' + long.Parse(reverseBits) + ": " + rmask + '\n' + mask * rmask);

        }
        public static void problem2(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            short n = 12;
            Char[] bits = new Char[n];
            Char[] reverseBits = new Char[n];
            Char[] toFollow = new Char[n];
            int[] average = new int[n];

            for (int i = 0; i<n; i++)
            {
                char[] follow = new char[i];
                foreach (string line in lines)
                {
                    bits = line.ToCharArray();
                    Array.Copy(toFollow, 0, follow, 0, i);

                    if (line.StartsWith(string.Join("", follow))){
                        average[i] += (bits[i] == '1' ? 1 : -1);
                    }
                }
                toFollow[i] = average[i] >= 0 ? '1' : '0';
                Console.WriteLine("oxy: " + string.Join("", toFollow) + ", " + ", " + string.Join(" ", average));
            }

            Int32 oxy = Convert.ToInt32(string.Join("", toFollow), 2);
            average = new int[n];
            toFollow = new char[n];
            for (int i = 0; i < n; i++)
            {
                int matches = 0;
                char stored  = '0';
                char[] follow = new char[i];
                foreach (string line in lines)
                {
                    bits = line.ToCharArray();
                    Array.Copy(toFollow, 0, follow, 0, i);

                    if (line.StartsWith(string.Join("", follow)))
                    {
                        matches++;
                        average[i] += (bits[i] == '1' ? 1 : -1);
                        stored = bits[i];
                    }
                }
                if(matches == 1)
                {
                    toFollow[i] = stored;
                } else
                {
                    toFollow[i] = average[i] >= 0 ? '0' : '1';
                }
                Console.WriteLine("co2 " + string.Join("", toFollow) + ", " + string.Join(" ", average));
            }
            Int32 co = Convert.ToInt32(string.Join("", toFollow), 2);
            Console.WriteLine(oxy + ": oxy\n" + co + ": co\n" + oxy * co);
        }
    }
}
