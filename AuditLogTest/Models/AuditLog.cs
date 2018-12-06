using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuditLogTest.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string EntityType { get; set; }
        public int OperationTypeId { get; set; }
        public string OperationType { get; set; }
        public DateTime Timestamp { get; set; }
        //public int LoggedInUserId { get; set; }
        public string LoggedInUserName { get; set; }
        public List<FieldAuditLog> Changes { get; set; }
        public string ChangeLogs { get; set; }
        public AuditLog()
        {
            Changes = new List<FieldAuditLog>();
        }
    }

    public class FieldAuditLog
    {
        public int Id { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
