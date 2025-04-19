-- Created by: Ali Hadidian
-- Persian Date CLR functions for Microsoft SQL Server
-- 1st edition: 2005
---------------Enabling CLR Integration------------------------
sp_configure 'show advanced options', 1;
GO
sp_configure 'clr enabled', 1;
GO
sp_configure 'clr strict security', 0;
GO
RECONFIGURE;
GO
----------------------Setup functions--------------------------
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
GO
