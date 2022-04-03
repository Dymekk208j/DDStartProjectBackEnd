IF COL_LENGTH('[DDStartProject].[dbo].[AspNetUsers]', 'Blocked') IS NULL
BEGIN
 ALTER TABLE [DDStartProject].[dbo].[AspNetUsers] 
    ADD Blocked BIT NOT NULL DEFAULT(0)
END