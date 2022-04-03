﻿SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlockUserReason](
	[Id] int IDENTITY(1,1) NOT NULL,
	[CreationDate] datetime NOT NULL DEFAULT(GETDATE()),
	[CreatedByUserId] nvarchar(450) NOT NULL,
	[LastModificationDate] datetime NULL,
	[ModifiedByUserId] nvarchar(450) NULL,
	[IsDeleted] tinyint NOT NULL DEFAULT(0),
	[Name] [nvarchar](260) NOT NULL UNIQUE,
 CONSTRAINT [PK_BlockUserReason] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 31/03/2021 15:28:24 ******/
CREATE NONCLUSTERED INDEX [IX_BlockUserReason_Id] ON [dbo].[BlockUserReason]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO

ALTER TABLE [dbo].[BlockUserReason]  WITH CHECK ADD CONSTRAINT [FK_BlockUserReason_CreatedByUserId_AspNetUsers_Id] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[BlockUserReason]  WITH CHECK ADD CONSTRAINT [FK_BlockUserReason_ModifiedByUserId_AspNetUsers_Id] FOREIGN KEY([ModifiedByUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
