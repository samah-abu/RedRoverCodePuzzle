# RedRoverCodePuzzle

`RedRoverCodePuzzle` is a small C# console application that parses a nested field list from standard input and prints the parsed values in two different orders.

## What it does

The program expects input in this general form:

```text
(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)
```

It uses a regular expression to validate and extract the fields, then writes:

1. The values in the original logical order.
2. The same values reordered by `email`, `externalId`, `id`, `name`, and `type`.

If the input does not match the expected pattern, the app prints `Invalid input`.

## Project layout

- `RedRoverCodePuzzle/Program.cs` - entry point and parsing logic
- `RedRoverCodePuzzle/RedRoverCodePuzzle.csproj` - .NET Framework project file

## Requirements

- Visual Studio 2019 or later, or the .NET Framework 4.8.1 build tools
- .NET Framework 4.8.1

## Build

Open the solution in Visual Studio and build the `RedRoverCodePuzzle` project.

From the command line, you can also build it with MSBuild:

```powershell
msbuild RedRoverCodePuzzle.sln /p:Configuration=Debug
```

## Run

Run the console app and provide the input on standard input. For example:

```text
(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)
```

Expected output is two formatted lists of the parsed values.

## Notes

- The current implementation contains two parsing helpers:
  - `UseRegExpressionExactStringPatternToBuildResult`
  - `UseRegExpressionExactOrderPatternToBuildResult`
- `Main` currently uses the exact-order parser.
