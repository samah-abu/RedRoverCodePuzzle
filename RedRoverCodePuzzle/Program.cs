using System;
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

                ConvertStringToOutput1(input);
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
            
    }
}
    
    
        