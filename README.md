# RedRoverCodePuzzle

`RedRoverCodePuzzle` is a small C# console application that runs in a loop, accepts nested, comma-separated text from standard input, and prints it back as an indented outline.

## What it does

The program:

1. Prints a prompt on each iteration.
2. Reads one line from `Console.ReadLine()`.
3. Exits when the user types `exit` in any case, such as `exit` or `EXIT`.
4. Rejects empty input.
5. Rejects input that does not start with `(` and end with `)`.
6. Rejects input where the number of opening and closing parentheses does not match.
7. Walks the string character by character and prints each token on its own line with indentation based on parenthesis depth.

Spaces are ignored. Commas become line breaks. The output uses `- ` markers to show structure. After a valid conversion, the app prints a blank line before the next prompt.

Example input:

```text
(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)
```

Example output shape:

```text
- id
- name
- email
- type
 - id
 - name
 - customFields
  - c1
  - c2
  - c3
- externalId
```

## Project layout

- `RedRoverCodePuzzle/Program.cs` - entry point and formatting logic
- `RedRoverCodePuzzle/RedRoverCodePuzzle.csproj` - .NET Framework project file

## Requirements

- Visual Studio 2019 or later, or the .NET Framework 4.8.1 build tools
- .NET Framework 4.8.1

## Build

Open the solution in Visual Studio and build the `RedRoverCodePuzzle` project.

## Run

Run the console app and provide the input on standard input. Type `exit` to quit:

```text
(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)
```

If the input fails validation, the app prints `Invalid input`. When the loop ends, the app prints `Loop ended.`
