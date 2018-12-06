using KellermanSoftware.CompareNetObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditLogTest.Models
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly AuditLogDbContext _auditLogDbContext;
        public AuditLogRepository(AuditLogDbContext auditLogDbContext)
        {
            _auditLogDbContext = auditLogDbContext;
        }

        public void CreateLog(int entityId, string entityType, int operationTypeId, Object oldRecord, Object newRecord)
        {
            AuditLog auditLog = new AuditLog();
            auditLog.EntityId = entityId;
            auditLog.EntityType = entityType;
            auditLog.OperationTypeId = operationTypeId;
            auditLog.LoggedInUserName = "Agraj";
            auditLog.Timestamp = DateTime.Now;
            var changes = CompareObjects(oldRecord, newRecord);
            auditLog.Changes = changes;
            auditLog.ChangeLogs = JsonConvert.SerializeObject(changes);
            _auditLogDbContext.AuditLogs.Add(auditLog);
            _auditLogDbContext.SaveChanges();
        }

        public List<AuditLog> GetLogsByEntityIdAndType(int id, string entityType)
        {
            var auditLogsToReturn = new List<AuditLog>();
            var auditLogs = _auditLogDbContext.AuditLogs
                .Where(al => al.EntityId == id && al.EntityType == entityType).OrderByDescending(a => a.Timestamp);
            foreach (var record in auditLogs)
            {
                var auditLog = new AuditLog();
                auditLog.Timestamp = record.Timestamp;
                auditLog.LoggedInUserName = record.LoggedInUserName;
                auditLog.OperationType = Convert.ToString((OperationTypeEnum)record.OperationTypeId);
                auditLog.ChangeLogs = record.ChangeLogs;
                var changesList = JsonConvert.DeserializeObject<List<FieldAuditLog>>(record.ChangeLogs);
                auditLog.Changes.AddRange(changesList);
                auditLog.EntityId = record.EntityId;
                auditLog.EntityType = record.EntityType;
                auditLogsToReturn.Add(auditLog);
            }
            return auditLogsToReturn;
        }

        public List<FieldAuditLog> CompareObjects(Object oldRecord, Object newRecord)
        {
            CompareLogic compObjects = new CompareLogic();
            compObjects.Config.MaxDifferences = 99;

            ComparisonResult comparisonResult = compObjects.Compare(oldRecord, newRecord);
            List<FieldAuditLog> fieldAuditLogList = new List<FieldAuditLog>();
            foreach (var changeLog in comparisonResult.Differences)
            {
                FieldAuditLog fieldAuditLog = new FieldAuditLog();
                fieldAuditLog.FieldName = changeLog.PropertyName;
                fieldAuditLog.OldValue = changeLog.Object1Value;
                fieldAuditLog.NewValue = changeLog.Object2Value;
                fieldAuditLogList.Add(fieldAuditLog);
            }
            return fieldAuditLogList;
        }
    }
}
