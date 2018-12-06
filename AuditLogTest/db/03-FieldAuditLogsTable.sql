CREATE TABLE FieldAuditLogs (
    Id        SERIAL PRIMARY KEY,
    AuditLogId SERIAL  NULL,
    FieldName  VARCHAR(100)  NULL,
    NewValue   VARCHAR(1000)  NULL,
    OldValue   VARCHAR(1000)  NULL
);
