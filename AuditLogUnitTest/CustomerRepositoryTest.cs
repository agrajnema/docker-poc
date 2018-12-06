using AuditLogTest.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace AuditLogUnitTest
{
    public class CustomerRepositoryTest
    {
        [Fact]
        public void GetAllCustomerTest()
        {
            //Arrange
            var mockRepo = new Mock<ICustomerRepository>();
            mockRepo.Setup(repo => (repo.GetAllCustomers())).Returns(GetAllCustomers());

            //Act
            var result = mockRepo.Object.GetAllCustomers();

            //Assert
            Assert.IsType<List<Customer>>(result);
            Assert.Single(result);
        }

        private List<Customer> GetAllCustomers()
        {
            var customerList = new List<Customer>()
            {
                new Customer() {
                FirstName = "Test",
                LastName = "Test",
                Salary = 5000,
                Id = 1
            } };
            return customerList;
        }
    }
}
