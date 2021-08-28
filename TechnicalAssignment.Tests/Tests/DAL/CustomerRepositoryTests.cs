using System;
using System.Collections.Generic;
using System.Text;
using TechnicalAssignment.DAL.Interfaces;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using TechnicalAssignment.DAL.Models;
using TechnicalAssignment.Tests.Fixtures;

namespace TechnicalAssignment.Tests.Tests.DAL
{
    [Collection("DALFixture Collection")]
    public class CustomerRepositoryTests
    {
        private readonly IUnitOfWork _sut;
        public CustomerRepositoryTests(DALFixture Fixture)
        {
            _sut = Fixture.UnitOfWork;
        }
        [Fact]
        public void GetCustomers()
        {
            var Customers = _sut.CustomerRepository.GetCustomers();
            Assert.NotEmpty(Customers);
        }
        [Fact]
        public void CreatCustomer()
        {
            bool result = _sut.CustomerRepository.CreatCustomer(new Customer()
            {
                CustomerID = 3,
                Name = "Mina",
                Surname = "Maurice"
            });
            Assert.True(result);
            Customer cutomer = _sut.CustomerRepository.GetCustomer(3);
            Assert.Equal(3, cutomer.CustomerID);
        }
        [Fact]
        public void GetCustomer()
        {
            Customer cutomer = _sut.CustomerRepository.GetCustomer(1);
            Assert.NotNull(cutomer);
            Assert.Equal(1, cutomer.CustomerID);
        }
    }
}
