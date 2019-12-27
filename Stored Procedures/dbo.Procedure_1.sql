CREATE PROCEDURE [dbo].[UpdatePriceOfProduct]
	@ID int,
	@NewPrice money
AS
	UPDATE Products
	Set UnitPrice = @NewPrice
	Where ProductId = @ID

RETURN 0

