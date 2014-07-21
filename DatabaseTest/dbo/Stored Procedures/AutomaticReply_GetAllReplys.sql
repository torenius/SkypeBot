CREATE PROCEDURE dbo.AutomaticReply_GetAllReplys
AS
BEGIN
	SELECT
		AR.TriggerMessage,
		AR.ReplyMessage
	FROM
		dbo.AutomaticReply AR;
END