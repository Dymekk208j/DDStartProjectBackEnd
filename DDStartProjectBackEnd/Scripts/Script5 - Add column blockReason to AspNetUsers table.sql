IF COL_LENGTH('[DDStartProject].[dbo].[AspNetUsers]', 'BlockReason') IS NULL
BEGIN
 ALTER TABLE [DDStartProject].[dbo].[AspNetUsers] 
    ADD BlockReason NVARCHAR(260) NULL
END