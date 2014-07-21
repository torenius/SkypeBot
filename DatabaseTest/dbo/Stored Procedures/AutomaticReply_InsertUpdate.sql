CREATE PROCEDURE dbo.AutomaticReply_InsertUpdate
	@TriggerMessage varchar(100),
	@ReplyMessage varchar(1000)
AS
BEGIN
	MERGE
		dbo.AutomaticReply AR
	USING
	(
		SELECT
			@TriggerMessage AS [TriggerMessage],
			@ReplyMessage AS [ReplyMessage]
	) X
	ON
		X.TriggerMessage = AR.TriggerMessage
	WHEN NOT MATCHED THEN
		INSERT
		(
			TriggerMessage,
			ReplyMessage
		)
		VALUES
		(
			X.TriggerMessage,
			X.ReplyMessage
		)
	WHEN MATCHED THEN
		UPDATE SET
			ReplyMessage = X.ReplyMessage;
END