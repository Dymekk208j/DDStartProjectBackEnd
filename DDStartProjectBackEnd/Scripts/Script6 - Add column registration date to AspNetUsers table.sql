IF COL_LENGTH('[DDStartProject].[dbo].[AspNetUsers]', 'RegistrationDateUTC') IS NULL
BEGIN
 ALTER TABLE [DDStartProject].[dbo].[AspNetUsers] 
    ADD RegistrationDateUTC DATETIME NOT NULL DEFAULT GETUTCDATE()
END