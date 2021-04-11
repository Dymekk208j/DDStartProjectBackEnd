--DECLARE @startRow AS INT
--DECLARE @endRow AS INT
--SET @startRow=0
--SET @endRow=20

SELECT 
	[Id],
	[UserName],
	[Email],
	[EmailConfirmed],
	[PhoneNumber],
	[Firstname],
	[Lastname],
	[Gender]
FROM 
	[AspNetUsers]
ORDER BY [Id] 
OFFSET @startRow ROWS
FETCH NEXT @endRow-@startRow ROWS ONLY


--	SELECT FruitName,Price FROM SampleFruits
--ORDER BY Price 
--OFFSET (@PageNumber-1)*@RowsOfPage ROWS
--FETCH NEXT @RowsOfPage ROWS ONLY
