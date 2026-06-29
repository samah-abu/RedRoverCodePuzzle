# RedRoverCodePuzzle

`RedRoverCodePuzzle` is a C# console application that reads a parenthesized, comma-separated string from standard input and converts it into a tree of node names.

## Project

- Console app
- Target framework: .NET Framework 4.8.1
- Entry point: `RedRoverCodePuzzle/Program.cs`

## Input format

The parser expects input in this shape:

```text
(a,b,c)
```

Nested groups are also supported by the current parser shape:

```text
(a,b,(c,d),e)
```

Spaces are ignored.

## Runtime behavior

On each loop iteration the app:

1. Prompts for a string.
2. Exits when the user types `exit` in any casing.
3. Rejects input that is empty, does not start with `(`, or does not end with `)`.
4. Rejects input when the number of opening and closing parentheses does not match.
5. Builds a `Node` tree and prints it.

If input fails validation, the app prints `Invalid input`.

## Build

Open `RedRoverCodePuzzle.sln` in Visual Studio and build the solution.

## Run

Run the console app and enter a string at the prompt. Type `exit` to quit.

Example:

```text
(id,name,email,type(id,name,customFields(c1,c2,c3)),externalId)
```

