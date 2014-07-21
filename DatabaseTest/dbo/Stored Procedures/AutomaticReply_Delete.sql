CREATE PROCEDURE dbo.AutomaticReply_Delete
	@TriggerMessage varchar(100)
AS
BEGIN
	DELETE from dbo.AutomaticReply WHERE TriggerMessage = @TriggerMessage;
END