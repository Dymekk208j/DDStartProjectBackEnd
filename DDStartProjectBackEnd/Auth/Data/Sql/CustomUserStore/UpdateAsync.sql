UPDATE 
	[AspNetUsers]
SET
	[PasswordHash] = @PasswordHash,
	[SecurityStamp] = @SecurityStamp,
	[ConcurrencyStamp] = @ConcurrencyStamp,
	[TwoFactorEnabled] = @TwoFactorEnabled,
	[LockoutEnd] = @LockoutEnd,
	[LockoutEnabled] = @LockoutEnabled,
	[AccessFailedCount] = @AccessFailedCount,
	[Firstname] = @Firstname,
	[Lastname] = @Lastname,
	[Gender] = @Gender 
WHERE
	[Id] = @Id