if (SELECT count(name) FROM sys.databases WHERE name LIKE 'auditlogdb') = 0
  begin
  create database auditlogdb 
    end;
go


CREATE TABLE AuditLogs (
    Id               int     identity(1,1)       Primary key,
    EntityId         int            NOT NULL,
    EntityType       varchar(50)  NULL,
    OperationTypeId  int            NOT NULL,
    [Timestamp]      datetime   NOT NULL,
    LoggedInUserName VARCHAR(50)  NULL,
    ChangeLogs       VARCHAR(8000)  NULL,
    OperationType    VARCHAR(8000)  NULL
);

go

CREATE TABLE Customers (
    Id int identity(1,1) PRIMARY KEY,
    FirstName VARCHAR(100)  NOT NULL,
    LastName  VARCHAR(100)  NOT NULL,
    Salary    int  NOT NULL
);

go

CREATE TABLE FieldAuditLogs (
    Id        int identity(1,1) PRIMARY KEY,
    AuditLogId int  NULL foreign key references AuditLogs(Id),
    FieldName  VARCHAR(100)  NULL,
    NewValue   VARCHAR(1000)  NULL,
    OldValue   VARCHAR(1000)  NULL
);

go