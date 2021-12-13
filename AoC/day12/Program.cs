using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AoC
{
    class Day12
    {
        HashSet<Node> endSet;
        public static void Main(string[] args)
        {
            Day12 d = new Day12();

            d.problem1(@"C:\Users\jesols\workspace\aoc2021\AoC\day12\input.txt");
            //problem2(@"C:\Users\jesols\workspace\aoc2021\AoC\day11\input.txt");
        }
        public Day12()
        {
             endSet = new HashSet<Node>();
        }


        public void problem1(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            Dictionary<string, Node> nodes = new Dictionary<string, Node>();
            HashSet<Node> startSet = new HashSet<Node>();
            for (int i = 0; i < lines.Length; i++)
            {
                string a = lines[i].Split('-')[0], b = lines[i].Split('-')[1];
                if (a == "start") 
                {
                    if (!nodes.ContainsKey(b)) nodes.Add(b, new Node(b, !Char.IsUpper(b.ToCharArray()[0])));
                    startSet.Add(nodes[b]);                    
                    continue;
                }
                if (b == "start")
                {
                    if (!nodes.ContainsKey(a)) nodes.Add(a, new Node(a, !Char.IsUpper(a.ToCharArray()[0])));
                    startSet.Add(nodes[a]);
                    continue;
                }
                if (a == "end")
                {
                    if (!nodes.ContainsKey(b)) nodes.Add(b, new Node(b, !Char.IsUpper(b.ToCharArray()[0])));
                    endSet.Add(nodes[b]);
                    continue;
                }

                if (b == "end")
                {
                    if (!nodes.ContainsKey(a)) nodes.Add(a, new Node(a, !Char.IsUpper(b.ToCharArray()[0])));
                    endSet.Add(nodes[a]);
                    continue;
                }

                if (!nodes.ContainsKey(a)) nodes.Add(a, new Node(a, !Char.IsUpper(a.ToCharArray()[0])));
                if (!nodes.ContainsKey(b)) nodes.Add(b, new Node(b, !Char.IsUpper(b.ToCharArray()[0])));

                nodes[a].AddNode(nodes[b]);
                nodes[b].AddNode(nodes[a]);
            }
            int count = 0;
            foreach (Node s in startSet)
            {
                Visit(s, "start", ref count, false);
            }
            Console.WriteLine(count);
        }

        public void Visit(Node n, string past, ref int count, bool consumed) 
        {
            if (n.small) past += " " + n.name;
            if (endSet.Contains(n))
            {
                count++;
            }

            foreach (Node s in n.siblings)
            {
                if (!consumed)
                {
                    if (s.CanVisit(past))
                    {
                        Visit(s, past, ref count, false);
                    }else if (s.CanVisit2(past))
                    {
                        Visit(s, past, ref count, true);
                    }
                }
                else
                {
                    if (s.CanVisit(past))
                    {
                        Visit(s, past, ref count, true);
                    }
                }
            }
        }


        public class Node
        {
            public bool small;
            public String name;
            public HashSet<Node> siblings;

            public Node(String name, bool small, Node connection = null)
            {
                this.name = name;
                siblings = new HashSet<Node>();
                if (connection != null) siblings.Add(connection);
                this.small = small;
            }

            public void AddNode(Node connection)
            {
                siblings.Add(connection);
            }

            public bool CanVisit(string path)
            {
                if (small)
                {

                    return !path.Contains(name);
                }
                return true;
            }
            public bool CanVisit2(string path)
            {
                if (small)
                {
                    return !(path.Split(name).Length > 2);
                }
                return true;
            }
        }
    }
}
