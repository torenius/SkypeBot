CREATE PROCEDURE dbo.PeriodicMessage_InsertUpdate
	@PeriodicMessageId int = NULL OUTPUT,
	@Title varchar(300),
	@Message varchar(max),
	@ChatName varchar(300),
	@DueTime int,
	@Period int,
	@IsActive bit
AS
BEGIN
	IF @PeriodicMessageId IS NULL
	BEGIN
		INSERT INTO dbo.PeriodicMessage
		(
			Title,
			Message,
			ChatName,
			DueTime,
			Period,
			IsActive
		)
		VALUES
		(
			@Title,
			@Message,
			@ChatName,
			@DueTime,
			@Period,
			@IsActive
		);

		SELECT @PeriodicMessageId = SCOPE_IDENTITY();
	END
	ELSE
	BEGIN
		UPDATE
			dbo.PeriodicMessage
		SET
			Title = @Title,
			Message = @Message,
			ChatName = @ChatName,
			DueTime = @DueTime,
			Period = @Period,
			IsActive = @IsActive
		WHERE
			PeriodicMessageId = @PeriodicMessageId;
	END
END