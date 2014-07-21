CREATE PROCEDURE dbo.PeriodicMessage_GetAllMessages
AS
BEGIN
	SELECT
		PM.PeriodicMessageId,
		PM.Title,
		PM.Message,
		PM.ChatName,
		PM.DueTime,
		PM.Period,
		PM.IsActive
	FROM
		dbo.PeriodicMessage PM;
END
