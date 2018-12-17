SELECT TOP (1000)	[Id], [EventId], [LogLevel], [Message], [CreatedTime] FROM [Dev].[dbo].[EventLog]
WHERE				[EventId] = 0
ORDER BY			[CreatedTime] DESC