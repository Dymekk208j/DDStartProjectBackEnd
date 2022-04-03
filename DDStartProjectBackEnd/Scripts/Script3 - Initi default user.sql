IF NOT EXISTS(
 SELECT *
 FROM 
  [DDStartProject].[dbo].[AspNetUsers] 
 WHERE [UserName] = 'Dymek'
 )
  BEGIN
	 INSERT [dbo].[AspNetUsers] 
		 ([Id], 
		 [UserName], 
		 [NormalizedUserName], 
		 [Email], 
		 [NormalizedEmail], 
		 [EmailConfirmed], 
		 [PasswordHash], 
		 [SecurityStamp], 
		 [ConcurrencyStamp], 
		 [PhoneNumber], 
		 [PhoneNumberConfirmed], 
		 [TwoFactorEnabled], 
		 [LockoutEnd], 
		 [LockoutEnabled], 
		 [AccessFailedCount], 
		 [Firstname], 
		 [Lastname], 
		 [GenderId]) 
	 VALUES 
		(N'7d8a42ae-a459-4758-9b89-10f06a4b4cfb', 
		N'Dymek', 
		N'DYMEK', 
		N'Damian.Dziura@DDSoftware.pl', 
		N'DAMIAN.DZIURA@DDSOFTWARE.PL', -- Domyślne hasło: Damian13!
		1, 
		N'AQAAAAEAACcQAAAAEBkgwl+F4zXHvsUaNlTA8iv/RYNayEavcQgi32SKjoKxbRUovAhhJlrvE/JjRLkvpQ==', 
		N'9ae46ea2-5d80-4f99-9c58-8e7d5fefb4ca', 
		N'1514274e-5b35-475b-ab5a-f08213f6f238', 
		NULL, 
		0, 
		0, 
		NULL, 
		0, 
		0, 
		N'Damian', 
		N'Dziura', 
		1)
	 END
GO

INSERT INTO [DDStartProject].[dbo].[AspNetUserRoles] (UserId, RoleId) 
VALUES (N'7d8a42ae-a459-4758-9b89-10f06a4b4cfb', N'9EF622BE-00C7-4B1F-B1C7-D2D32B694B0C')

GO