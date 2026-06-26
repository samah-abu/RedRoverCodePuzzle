using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RedRoverCodePuzzle
{
    internal class Program
    {
        public struct TypeField
        {
            public string id;
            public string name;
            public List<string> customeFields;
        }

        public struct Result
        {
            public string id;
            public string name;
            public string email;
            public TypeField type;
            public string externalId;
        }

        public static void Main(string[] args)
        {

            //var input = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";

            var input = Console.ReadLine();
            
            // string inputPattern =
            //     @"^((id),(name),(email),type\((id),(name),customFields\((c1), (c2), (c3)\)\),(externalId))$";
            
            // use this pattern if we are requiring the input to be exactly the same string 
            // string extactStringPattern = @"\(id, name, email, type\(id, name, customFields\(c1, c2, c3\)\), externalId\)";
            // var exactMatch = Regex.Match(input, extactStringPattern);
            
            // use if we are expecting the input to respect the order
            string extactOrderPattern = @"\((id), (name), (email), type\((id), (name), customFields\((c1), (c2), (c3)\)\), (externalId)\)";
            var extactOrderMatch = Regex.Match(input, extactOrderPattern);
            if (extactOrderMatch.Success) 
            {
                var result = new Result()
                {
                    id = extactOrderMatch.Groups[1].Value,
                    name = extactOrderMatch.Groups[2].Value,
                    email = extactOrderMatch.Groups[3].Value,
                    type = new TypeField() {
                        id = extactOrderMatch.Groups[4].Value,
                        name = extactOrderMatch.Groups[5].Value,
                        customeFields = new List<string>()
                        {
                            extactOrderMatch.Groups[6].Value,
                            extactOrderMatch.Groups[7].Value,
                            extactOrderMatch.Groups[8].Value,
                        }
                        
                    }, 
                    externalId = extactOrderMatch.Groups[9].Value
                };
                
                // output 1
                Console.WriteLine("- " + result.id);
                Console.WriteLine("- " + result.name);
                Console.WriteLine("- " + result.email);
                Console.WriteLine("- " + "type");
                Console.WriteLine(" - " + result.type.id);
                Console.WriteLine(" - " + result.type.name);
                Console.WriteLine(" - " + "customFields");
                foreach (var c in result.type.customeFields)
                {
                    Console.WriteLine("  - " + c);
                }
                Console.WriteLine("- " + result.externalId);

                Console.WriteLine();
                Console.WriteLine();

                // output 2
                Console.WriteLine("- " + result.email);
                Console.WriteLine("- " + result.externalId);
                Console.WriteLine("- " + result.id);
                Console.WriteLine("- " + result.name);
                Console.WriteLine("- " + "type");
                Console.WriteLine(" - " + "customFields");
                foreach (var c in result.type.customeFields)
                {
                    Console.WriteLine("  - " + c);
                }
                Console.WriteLine(" - " + result.type.id);
                Console.WriteLine(" - " + result.type.name);
                
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
            
        }
    }
}
        