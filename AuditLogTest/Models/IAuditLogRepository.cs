using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditLogTest.Models
{
    public interface IAuditLogRepository
    {
        void CreateLog(int entityId, string entityType, int operationTypeId, Object oldRecord, Object newRecord);
        List<AuditLog> GetLogsByEntityIdAndType(int id, string entityType);
    }
}
