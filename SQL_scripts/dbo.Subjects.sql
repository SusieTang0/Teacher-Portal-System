CREATE TABLE [dbo].[Subjects] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [SubjectCode]    CHAR (6)      NOT NULL,
    [SubjectName]    VARCHAR (255) NULL,
    [StartDate]      DATE          NULL,
    [NumberOfCredit] INT           NOT NULL,
    [StaffId]        INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([SubjectCode] ASC),
    CHECK ([NumberOfCredit]>(0) AND [NumberOfCredit]<=(4))
);

