CREATE TABLE [dbo].[PeriodicMessage] (
    [PeriodicMessageId] INT           IDENTITY (1, 1) NOT NULL,
    [Title]             VARCHAR (300) NOT NULL,
    [Message]           VARCHAR (MAX) NOT NULL,
    [ChatName]          VARCHAR (300) NOT NULL,
    [DueTime]           INT           CONSTRAINT [DF_PeriodicMessage_DueTime] DEFAULT ((0)) NOT NULL,
    [Period]            INT           CONSTRAINT [DF_PeriodicMessage_Period] DEFAULT ((-1)) NOT NULL,
    [IsActive]          BIT           CONSTRAINT [DF_PeriodicMessage_IsActive] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PeriodicMessage] PRIMARY KEY CLUSTERED ([PeriodicMessageId] ASC)
);

