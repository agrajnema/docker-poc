IF  NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'AuditLogTestDb')
 begin
   create database AuditLogTestDb
end;