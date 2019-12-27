USE [Northwind]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[Procedure]
		@ID = 12,
		@NewPrice = 12

SELECT	@return_value as 'Return Value'

GO
