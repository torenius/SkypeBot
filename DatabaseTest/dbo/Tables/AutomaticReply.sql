CREATE TABLE [dbo].[AutomaticReply] (
    [TriggerMessage] VARCHAR (100)  NOT NULL,
    [ReplyMessage]   VARCHAR (1000) NOT NULL,
    CONSTRAINT [PK_AutomaticReply] PRIMARY KEY CLUSTERED ([TriggerMessage] ASC)
);

