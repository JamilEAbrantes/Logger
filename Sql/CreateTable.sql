SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventLog](
	[Id] [uniqueidentifier] NOT NULL,
	[EventId] [varchar](50) NULL,
	[LogLevel] [varchar](50) NULL,
	[Message] [varchar](1000) NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_EventLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO