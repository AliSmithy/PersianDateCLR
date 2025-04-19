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

### 1. Compile DLL File

To compile the C# source code into a DLL file, either use the `compile.bat` script or run the following command in the Windows Command Prompt. The output file `PersianDateCLR.dll` will be located in the `bin/` folder.

```bat
mkdir bin
"C:\Windows\Microsoft.NET\Framework\v3.5\csc.exe" /target:library /out:./bin/PersianDateCLR.dll persianDateCLR.cs
```

> Note: If the path to `csc.exe` is different in your Windows installation, please update it accordingly.

### 2. Configure SQL Server for CLR Execution

Run the following code on your target database:

```sql
sp_configure 'show advanced options', 1;
GO
sp_configure 'clr enabled', 1;
GO
sp_configure 'clr strict security', 0;
GO
RECONFIGURE;
GO
```

The above code enables CLR functionality.

### 3. Install Assembly in SQL Server

Open SQL Server Management Studio and select your desired database. Then, navigate to the `Programmability` branch, right-click on `Assemblies`, and choose `New Assembly`. In the dialog, select the previously compiled `PersianDateCLR.dll` file and confirm.

### 4. Configure Functions in SQL Server

Execute the following script on your target database:

```sql
CREATE FUNCTION [dbo].[GregorianToPersian](@GregorianDate datetime, @Separator nvarchar(max))
RETURNS nvarchar(max) WITH EXECUTE AS CALLER AS EXTERNAL NAME [PersianDateCLR].[PersianDateCLR].[GregorianToPersian]
GO
CREATE FUNCTION [dbo].[PersianToGregorian](@date nvarchar(max))
RETURNS datetime WITH EXECUTE AS CALLER AS EXTERNAL NAME [PersianDateCLR].[PersianDateCLR].[PersianToGregorian]
GO
CREATE FUNCTION [dbo].[PersianYear](@GregorianDate datetime)
RETURNS int WITH EXECUTE AS CALLER AS EXTERNAL NAME [PersianDateCLR].[PersianDateCLR].[PersianYear]
GO
CREATE FUNCTION [dbo].[PersianMonth](@GregorianDate datetime)
RETURNS int WITH EXECUTE AS CALLER AS EXTERNAL NAME [PersianDateCLR].[PersianDateCLR].[PersianMonth]
GO
CREATE FUNCTION [dbo].[PersianDay](@GregorianiDate datetime)
```

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