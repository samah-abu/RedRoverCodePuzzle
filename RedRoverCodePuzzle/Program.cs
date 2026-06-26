using System;
using System.Collections.Generic;
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

            // use this pattern if we are requiring the input to be exactly the same string
            // var nullableResult = UseRegExpressionExactStringPatternToBuildResult(input);


            // use if we are expecting the input to respect the order
            var nullableResult = UseRegExpressionExactOrderPatternToBuildResult(input);

            if (nullableResult == null)
            {
                Console.WriteLine("Invalid input");
                return;
            }

            var result = nullableResult.Value;
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


        public static Result? UseRegExpressionExactStringPatternToBuildResult(string input)
        {
            string extactStringPattern =
                @"\(id, name, email, type\(id, name, customFields\(c1, c2, c3\)\), externalId\)";
            var exactMatch = Regex.Match(input, extactStringPattern);

            if (!exactMatch.Success)
            {
                return null;
            }

            var result = new Result()
            {
                id = "id",
                name = "name",
                email = "email",
                type = new TypeField()
                {
                    id = "id",
                    name = "name",
                    customeFields = new List<string>()
                    {
                        "c1",
                        "c2",
                        "c3",
                    }

                },
                externalId = "externalId",
            };

            return result;

        }

        public static Result? UseRegExpressionExactOrderPatternToBuildResult(string input)
        {
            string extactOrderPattern =
                @"\((id), (name), (email), type\((id), (name), customFields\((c1), (c2), (c3)\)\), (externalId)\)";
            var extactOrderMatch = Regex.Match(input, extactOrderPattern);
            if (!extactOrderMatch.Success)
            {
                return null;
            }

            var result = new Result()
            {
                id = extactOrderMatch.Groups[1].Value,
                name = extactOrderMatch.Groups[2].Value,
                email = extactOrderMatch.Groups[3].Value,
                type = new TypeField()
                {
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

            return result;
        }

    }
}
    
    
        