using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditLogTest.Models
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        Customer GetCustomerById(int id);
        void UpdateCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomers();
    }
}
