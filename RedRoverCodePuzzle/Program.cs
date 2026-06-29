using System;
using System.Collections.Generic;
using System.Linq;

namespace RedRoverCodePuzzle
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nType your string to convert. Type 'exit' to quit.");
                Console.Write("> ");

                string input = Console.ReadLine();

                // Check for exit condition (case-insensitive)
                if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    break; // Exits the while loop
                }

                if (string.IsNullOrEmpty(input) || !input.StartsWith("(") || !input.EndsWith(")"))
                {
                    Console.WriteLine("Invalid input");
                    //return;
                }

                var numOfOpenParen = input.Count(c => c == '(');
                var numOfCloseParen = input.Count(c => c == ')');
                if (numOfOpenParen != numOfCloseParen)
                {
                    Console.WriteLine("Invalid input");
                    //return;
                }

                //ConvertStringToOutput1(input);

                var rootNode = ProcessRootNode(input);
                
                Console.WriteLine("\nOutput 1");
                PrintTreeOutput1(rootNode, 0);
                
                Console.WriteLine("\nOutput 2");
                PrintTreeOutput2(rootNode, 0);
            }

            Console.WriteLine("Loop ended.");
        }

        private static void ConvertStringToOutput1(string input)
        {
            if (string.IsNullOrEmpty(input) || !input.StartsWith("(") || !input.EndsWith(")"))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            var numOfOpenParen = input.Count(c => c == '(');
            var numOfCloseParen = input.Count(c => c == ')');
            if (numOfOpenParen != numOfCloseParen)
            {
                Console.WriteLine("Invalid input");
                return;
            }

            var depth = -1;
            foreach (var c in input)
            {
                if (c == '(')
                {
                    depth++;
                    Console.Write("\n" + new string(' ', depth) + "- ");
                }
                else if (c == ')')
                {
                    depth--;
                }
                else if (c == ',')
                {
                    Console.Write("\n" + new string(' ', depth) + "- ");
                }
                else if (c != ' ')
                {
                    Console.Write(c);
                }
            }

            Console.Write("\n\n");
        }

        public class Node
        {
            public string Name { get; set; }
            public List<Node> Children { get; set; }
        }

        private static Node ProcessRootNode(string input)
        {
            var root = new Node() { Name = "root" };

            int index = 1;
            root.Children = ProcessChildren(input, ref index);
            return root;
        }

        private static List<Node> ProcessChildren(string input, ref int index)
        {
            if (index == input.Length) return new List<Node>();

            string name = "";
            var list = new List<Node>();
            while (index < input.Length)
            {
                var c = input[index];
                if (c == '(')
                {
                    var node = new Node() { Name = name };
                    list.Add(node);
                    name = "";
                    index++;
                    node.Children = ProcessChildren(input, ref index);
                }
                else if (c == ')')
                {
                    var node = new Node() { Name = name };
                    list.Add(node);
                    name = "";
                    index++;
                    return list;
                }

                // end of a field
                else if (c == ',')
                {
                    var node = new Node() { Name = name };
                    list.Add(node);
                    name = "";
                }
                else if (c != ' ')
                {
                    name += c;
                }

                index++;

            }

            return list;
        }

        private static void PrintTreeOutput1(Node node, int depth)
        {
            if (node.Name != "root")
                Console.WriteLine(new string(' ', depth) + "- " + node.Name);
            
            if (node.Children != null && node.Children.Count > 0)
            {
                depth++;
                foreach (var childNode in node.Children)
                {
                    PrintTreeOutput1(childNode, depth);
                }
            }
        }
        
        private static void PrintTreeOutput2(Node node, int depth)
        {
            if (node.Name != "root")
                Console.WriteLine(new string(' ', depth) + "- " + node.Name);
            
            if (node.Children != null && node.Children.Count > 0)
            {
                depth++;
                // print not nested nodes first
                var simpleNodes =
                    node.Children.Where(c => c.Children == null || c.Children.Count == 0);
                foreach (var childNode in simpleNodes)
                {
                    PrintTreeOutput2(childNode, depth);
                }
                var nestedNodes =
                    node.Children.Where(c => c.Children != null && c.Children.Count > 0);
                foreach (var childNode in nestedNodes)
                {
                    PrintTreeOutput2(childNode, depth);
                }
            }
        }
    }
}
    
    
        