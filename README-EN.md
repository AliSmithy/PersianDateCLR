# PersianDateCLR

PersianDateCLR is a collection of SQL CLR functions written in C# to facilitate date conversion between the Gregorian and Persian calendars. It is designed for Microsoft SQL Server environments, offering custom date conversion and related functionalities. The initial version of these functions was written in 2005 for my own projects. The code is very simple, and I decided to make it public for general use. Any collaboration, suggestions, or ideas to improve the functions would be greatly appreciated.

## Features

- **Gregorian to Persian Conversion**  
  The [`GregorianToPersian`](e:/ali/persianDateCLR/persianDateCLR.cs) function converts a Gregorian date to its Persian equivalent, with an optional separator for formatting.

- **Persian to Gregorian Conversion**  
  The [`PersianToGregorian`](e:/ali/persianDateCLR/persianDateCLR.cs) function converts a Persian date string back to a Gregorian date.

- **Date Component Extraction**  
  Functions like [`PersianYear`](e:/ali/persianDateCLR/persianDateCLR.cs), [`PersianMonth`](e:/ali/persianDateCLR/persianDateCLR.cs), and [`PersianDay`](e:/ali/persianDateCLR/persianDateCLR.cs) extract specific components (year, month, day) from a Gregorian date using Persian calendar logic.

## Prerequisites

- Microsoft SQL Server with CLR integration enabled.
- .NET Framework 3.5 (used for compilation).

## Installation and Setup

### 1. Compile the DLL

Run the `compile.bat` script or use the following command in the Windows Command Prompt to compile the C# source code into a DLL. The output `PersianDateCLR.dll` will be placed in the `bin/` directory.

```bat
mkdir bin
"C:\Windows\Microsoft.NET\Framework\v3.5\csc.exe" /target:library /out:./bin/PersianDateCLR.dll persianDateCLR.cs
```

> **Note:** Update the path to `csc.exe` if it differs in your Windows installation.

### 2. Set Up SQL Server Functions

Run the `setup.sql` script in your SQL Server environment. This script will:
- Enable CLR integration.
- Register the compiled functions (`GregorianToPersian`, `PersianToGregorian`, `PersianYear`, `PersianMonth`, and `PersianDay`) as SQL Server functions.

## Usage

After setup, you can use the functions in SQL queries like any other user-defined functions. For example:

```sql
SELECT dbo.GregorianToPersian('2023-10-15', '/') AS PersianDate;
```

This query returns the Persian date string corresponding to the provided Gregorian date.

## Files

- **persianDateCLR.cs**: Contains the implementation of all CLR functions.
- **compile.bat**: Batch script to compile the C# project.
- **setup.sql**: SQL script to enable CLR integration and register the functions.

## License

This project is licensed under the MIT License. See the `LICENSE` file for more details.