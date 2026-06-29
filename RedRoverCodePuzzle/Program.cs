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
                Console.WriteLine("Type your string to convert. Type 'exit' to quit.");
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
                
                ConvertStringToOutput1(input);
                
                //var node = ConvertStringToTree(input);
                
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
                else if(c != ' ' )
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
        
        private static Node ConvertStringToTree(string input)
        {
            // Stack holds references to the list hierarchy
            var stack = new Stack<List<Node>>();
            var currentNodeName = "";
            
            var root = new Node() {Name = "root"};
            var currentParent = root;
            var currentList = new List<Node>();
            root.Children = currentList;
            stack.Push(currentList);
            input = input.Remove(0,1);
            
            foreach (var c in input)
            {
                // we already have the root node
                if (c == '(')
                {
                    if (!string.IsNullOrEmpty(currentNodeName))
                    {
                        var node = new Node() { Name = currentNodeName };
                        currentList.Add(node);
                        currentNodeName = "";
                        currentParent = node;
                        // Create a new child list level
                        currentList = new List<Node>();
                        currentParent.Children = currentList;
                        stack.Push(currentList);
                    }
                }
                else if (c == ')')
                {
                    //add the last node 
                    if (!string.IsNullOrEmpty(currentNodeName))
                    {
                        var node = new Node() { Name = currentNodeName };
                        currentList.Add(node);
                        currentNodeName = "";
                    }
                    // Return back to the parent list context
                    if (stack.Count > 0)
                    {
                        currentList = stack.Pop();
                    }
                }
                // end of a field
                else if (c == ',')
                {
                    if (!string.IsNullOrEmpty(currentNodeName))
                    {
                        var node = new Node() { Name = currentNodeName };
                        currentList.Add(node);
                        currentNodeName = "";
                    }
                }
                else if(c != ' ' )
                {
                    currentNodeName += c;
                }
            }
            
            return root;
        }

            
    }
}
    
    
        