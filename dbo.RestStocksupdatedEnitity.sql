﻿CREATE TABLE [dbo].[RestStocks] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [TimeStamp] NVARCHAR(50) NULL,
    [Symbol]    NVARCHAR (50) NULL,
    [Change]    NVARCHAR (50) NULL,
    [Time]      NVARCHAR (50) NULL,
    [ChgPct]    NVARCHAR (50) NULL,
    [Price]     NVARCHAR (50) NULL,
    [Closing]   NVARCHAR (50) NULL,
    [Method]    NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

