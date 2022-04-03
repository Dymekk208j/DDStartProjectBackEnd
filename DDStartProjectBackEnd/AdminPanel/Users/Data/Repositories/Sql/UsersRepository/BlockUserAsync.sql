UPDATE 
	[AspNetUsers] 
SET
	[Blocked] = 1,
	[BlockReason] = @reason
WHERE
	[Id] = @id