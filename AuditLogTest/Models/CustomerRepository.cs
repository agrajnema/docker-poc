using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditLogTest.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AuditLogDbContext _auditLogDbContext;
        private readonly IAuditLogRepository _auditLogRepository;

        public CustomerRepository(AuditLogDbContext auditLogDbContext, IAuditLogRepository auditLogRepository)
        {
            _auditLogDbContext = auditLogDbContext;
            _auditLogRepository = auditLogRepository;
        }
        public void CreateCustomer(Customer customer)
        {
            _auditLogDbContext.Add(customer);
            _auditLogDbContext.SaveChanges();
            _auditLogRepository.CreateLog(customer.Id, "Customer", Convert.ToInt16(OperationTypeEnum.Create), new Customer(), customer);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return /*Seeder.SeedDatabase(_auditLogDbContext);*/_auditLogDbContext.Customers;
           
        }

        public Customer GetCustomerById(int id)
        {
            return _auditLogDbContext.Customers.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateCustomer(Customer customer)
        {
            var customerToUpdate = _auditLogDbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);
            var customerOldObject = _auditLogDbContext.Entry(customerToUpdate).CurrentValues.ToObject();
            customerToUpdate.FirstName = customer.FirstName;
            customerToUpdate.LastName = customer.LastName;
            customerToUpdate.Salary = customer.Salary;
            _auditLogDbContext.Customers.Update(customerToUpdate);
            _auditLogDbContext.SaveChanges();
            _auditLogRepository.CreateLog(customerToUpdate.Id, "Customer", Convert.ToInt16(OperationTypeEnum.Update), customerOldObject, customer);
        }

    }
}
