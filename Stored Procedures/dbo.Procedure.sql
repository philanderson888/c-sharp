CREATE PROCEDURE [dbo].[Procedure]
	@ID int,
	@NewPrice money
AS
	UPDATE Products
	Set UnitPrice = @NewPrice
	Where ProductId = @ID

RETURN 0
