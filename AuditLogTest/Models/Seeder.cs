using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditLogTest.Models
{
    public static class Seeder
    {
        public static void SeedDatabase(AuditLogDbContext context)
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    FirstName = "Test1",
                    LastName = "Test1",
                    Salary = 10000
                },
                new Customer
                {
                    FirstName = "Test2",
                    LastName = "Test2",
                    Salary = 20000
                }
            };

            context.Database.Migrate();

            //return customers;
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }




        }
    }
}
