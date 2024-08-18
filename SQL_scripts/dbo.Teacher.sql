CREATE TABLE [dbo].[Teacher] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NULL,
    [StaffID]   CHAR (4)     NOT NULL,
    [Email]     VARCHAR (50) NULL,
    [DOB]       DATE         NULL,
    [Cellphone] CHAR (10)    NULL,
    [Password]  VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([StaffID] ASC),
    CHECK (len([StaffID]) = (4)),
    CHECK (len([Cellphone]) = (10))
);

