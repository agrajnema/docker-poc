
CREATE TABLE AuditLogs (
    Id               serial            Primary key,
    EntityId         serial            NOT NULL,
    EntityType       varchar(50)  NULL,
    OperationTypeId  serial            NOT NULL,
    [Timestamp]        TIMESTAMP   NOT NULL,
    LoggedInUserName VARCHAR(50)  NULL,
    ChangeLogs       VARCHAR(8000)  NULL,
    OperationType    VARCHAR(8000)  NULL
);
