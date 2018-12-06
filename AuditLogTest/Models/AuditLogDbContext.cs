using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditLogTest.Models
{
    public class AuditLogDbContext : DbContext
    {
        public AuditLogDbContext(DbContextOptions<AuditLogDbContext> options) : base(options)
        {

        }
   

        public DbSet<Customer> Customers { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<FieldAuditLog> FieldAuditLogs { get; set; }
    }
}
