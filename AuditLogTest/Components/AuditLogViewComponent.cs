using AuditLogTest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditLogTest.Components
{
    public class AuditLogViewComponent: ViewComponent
    {
        private readonly IAuditLogRepository _auditLogRepository;
        public AuditLogViewComponent(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        public IViewComponentResult Invoke(int id, string entityType)
        {
            var logs = _auditLogRepository.GetLogsByEntityIdAndType(id, entityType);
            return View(logs);
        }

    }
}
