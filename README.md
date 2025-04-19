<div dir="rtl" style="text-align: right;">

## توابع تاریخ PersianDateCLR

مجموعه‌ای از توابع SQL CLR است که به زبان C# نوشته شده‌اند تا تبدیل تاریخ بین تقویم میلادی و تقویم شمسی را تسهیل کنند. این ابزار برای محیط‌های Microsoft SQL Server طراحی شده است و قابلیت‌های تبدیل تاریخ و توابع مرتبط را ارائه می‌دهد. ویرایش ابتدایی این توابع را در سال 2005 برای پروژه های خودم نوشته بودم. کدها بسیار ساده هستند و تصمیم گرفتم که برای استفاده عمومی آنها را بصورت پابلیک منتشر کنم. هر گونه همکاری و پیشنهاد یا ایده برای برای بهتر شدن توابع خوشحال کننده خواهد بود.

## ویژگی‌ها

- **تبدیل تاریخ میلادی به شمسی**  
  تابع [`GregorianToPersian`](e:/ali/persianDateCLR/persianDateCLR.cs) تاریخ میلادی را به معادل شمسی آن تبدیل می‌کند و امکان تعیین جداکننده برای فرمت خروجی را فراهم می‌سازد.

- **تبدیل تاریخ شمسی به میلادی**  
  تابع [`PersianToGregorian`](e:/ali/persianDateCLR/persianDateCLR.cs) یک رشته تاریخ شمسی را به تاریخ میلادی تبدیل می‌کند.

- **استخراج اجزای تاریخ**  
  توابعی مانند [`PersianYear`](e:/ali/persianDateCLR/persianDateCLR.cs)، [`PersianMonth`](e:/ali/persianDateCLR/persianDateCLR.cs)، و [`PersianDay`](e:/ali/persianDateCLR/persianDateCLR.cs) اجزای خاصی از تاریخ (سال، ماه، روز) را با استفاده از منطق تقویم شمسی استخراج می‌کنند.

## پیش‌نیازها

- Microsoft SQL Server با قابلیت فعال‌سازی CLR.
- .NET Framework 3.5 (برای کامپایل کد).

## نصب و راه‌اندازی

### 1. کامپایل فایل DLL

برای کامپایل کد منبع C# به یک فایل DLL، از اسکریپت `compile.bat` استفاده کنید یا دستور زیر را در Command Prompt ویندوز اجرا کنید. فایل خروجی `PersianDateCLR.dll` در پوشه `bin/` قرار خواهد گرفت.

```bat
mkdir bin
"C:\Windows\Microsoft.NET\Framework\v3.5\csc.exe" /target:library /out:./bin/PersianDateCLR.dll persianDateCLR.cs
```

> **توجه:** در صورت متفاوت بودن مسیر `csc.exe` در نصب ویندوز شما، آن را به‌روزرسانی کنید.

### 2. تنظیمات SQL Server برای اجرای CLR
کد زیر را برای دیتابیس مورد نظرتان اجرا کنید:
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
کد بالا قابلیت CLR را فعال می‌کند

### 3. نصب اسمبلی در SQL Server
برنامه SQL Server Management Studio را باز کنید و دیتابیس مورد نظرتان را انتخاب کنید. سپس  Programmability را باز کنید و روی Assemblies راست کلیک کنید و گزینه New Assembly را انتخاب کنید. در آنجا فایل PersianDateCLR.dll که پیشتر کامپایل کرده بودید را انتخاب و تایید کنید.

### 4. تنظیم توابع در SQL Server
اسکریپت زیر را در دیتابیس مورد نظرتان اجرا کنید:
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
RETURNS int WITH EXECUTE AS CALLER AS EXTERNAL NAME [PersianDateCLR].[PersianDateCLR].[PersianDay]
```

## استفاده

پس از راه‌اندازی، می‌توانید از توابع در کوئری‌های SQL مانند سایر توابع تعریف‌شده توسط کاربر استفاده کنید. به‌عنوان مثال:

```sql
SELECT dbo.GregorianToPersian('2023-10-15', '/') AS PersianDate;
```

این کوئری رشته تاریخ شمسی معادل تاریخ میلادی ارائه‌شده را برمی‌گرداند.

## فایل‌ها

- **persianDateCLR.cs**: شامل پیاده‌سازی تمام توابع CLR.
- **compile.bat**: اسکریپت دسته‌ای برای کامپایل پروژه C#.
- **setup.sql**: اسکریپت SQL برای فعال‌سازی CLR و ثبت توابع.

## مجوز

این پروژه تحت مجوز MIT منتشر شده است. برای جزئیات بیشتر به فایل `LICENSE` مراجعه کنید.
</div>