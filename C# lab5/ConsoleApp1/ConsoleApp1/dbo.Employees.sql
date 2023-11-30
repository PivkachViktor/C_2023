CREATE TABLE [dbo].[Employees] (
    [EmployeeID]      INT            NOT NULL,
    [LastName]        NVARCHAR (50)  NULL,
    [RoomNumber]      INT            NULL,
    [Department]      NVARCHAR (50)  NULL,
    [ComputerDetails] NVARCHAR (100) NULL,
    [Salary] INT NULL, 
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
);

