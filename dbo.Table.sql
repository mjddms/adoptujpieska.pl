﻿CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [USERNAME] VARCHAR(50) NULL, 
    [EMAIL] VARCHAR(50) NULL, 
    [PASSWORD] VARCHAR(50) NULL
)
