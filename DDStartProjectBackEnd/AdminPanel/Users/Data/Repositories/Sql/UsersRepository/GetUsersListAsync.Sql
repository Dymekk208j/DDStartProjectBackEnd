SELECT 
	[AspNetUsers].[Id],
	[UserName],
	[Email],
	[EmailConfirmed],
	[PhoneNumber],
	[Firstname],
	[Lastname],
	[GenderId],
	[Blocked],
	[RegistrationDateUTC],
	[Role].[Name] as [Role]
FROM 
	[AspNetUsers]
LEFT JOIN AspNetUserRoles AS [UserRole] ON [UserRole].[UserId] = [Id]
LEFT JOIN AspNetRoles AS [Role] ON [Role].Id = [UserRole].[RoleId]