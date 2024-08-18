CREATE TABLE [dbo].[Books] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [ISBN]       CHAR (13)     NOT NULL,
    [BookTitle]  VARCHAR (255) NULL,
    [Price]      INT           NULL,
    [AuthorName] VARCHAR (255) NULL,
    [DOP]        DATE          NULL,
    [StaffId]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([ISBN] ASC),
    CHECK (len([ISBN])=(13)),
    CHECK ([Price]<=(300))
);

