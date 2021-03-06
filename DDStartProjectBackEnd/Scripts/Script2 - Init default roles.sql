IF NOT EXISTS(
 SELECT *
 FROM 
  [DDStartProject].[dbo].[AspNetRoles] 
 WHERE [Name] = 'DDSoftwareAdministrator'
 )
  BEGIN
	  INSERT INTO [DDStartProject].[dbo].[AspNetRoles] ([Id],[Name])
	  VALUES('9EF622BE-00C7-4B1F-B1C7-D2D32B694B0C', 'DDSoftwareAdministrator')
  END
GO
IF NOT EXISTS(
 SELECT *
 FROM 
  [DDStartProject].[dbo].[AspNetRoles] 
 WHERE [Name] = 'Administrator'
 )
  BEGIN
	  INSERT INTO [DDStartProject].[dbo].[AspNetRoles] ([Id], [Name])
	  VALUES(N'FB3CE05E-E382-42D9-9DA6-EC7CE4C6DD57',N'Administrator')
  END
GO
IF NOT EXISTS(
 SELECT *
 FROM 
  [DDStartProject].[dbo].[AspNetRoles] 
 WHERE [Name] = 'Moderator'
 )
  BEGIN
	  INSERT INTO [DDStartProject].[dbo].[AspNetRoles] ([Id], [Name])
	  VALUES(N'EE2BFAA8-C72F-4713-8AB4-D41F53D2F14F', N'Moderator')
  END
GO
IF NOT EXISTS(
 SELECT *
 FROM 
  [DDStartProject].[dbo].[AspNetRoles] 
 WHERE [Name] = 'User'
 )
  BEGIN
	  INSERT INTO [DDStartProject].[dbo].[AspNetRoles] ([Id], [Name])
	  VALUES(N'AA1549B5-9C60-4F21-B4D4-133B7FB3E47E', 'User')
  END