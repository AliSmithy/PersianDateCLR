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

### 2. تنظیم توابع در SQL Server

اسکریپت `setup.sql` را در محیط SQL Server اجرا کنید. این اسکریپت:
- قابلیت CLR را فعال می‌کند.
- توابع کامپایل‌شده (`GregorianToPersian`، `PersianToGregorian`، `PersianYear`، `PersianMonth`، و `PersianDay`) را به‌عنوان توابع SQL Server ثبت می‌کند.

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