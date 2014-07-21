CREATE PROCEDURE dbo.PeriodicMessage_Delete
	@PeriodicMessageId int
AS
BEGIN
	DELETE FROM dbo.PeriodicMessage WHERE PeriodicMessageId = @PeriodicMessageId;
END