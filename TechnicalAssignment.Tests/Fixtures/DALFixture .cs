using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TechnicalAssignment.DAL.Interfaces;
using TechnicalAssignment.DAL.Repositories;

namespace TechnicalAssignment.Tests.Fixtures
{
    public class DALFixture
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        public DALFixture()
        {
            SetupServices();
            DataSetup();
        }

        private void SetupServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IAccountRepository, AccountRepository>();
            serviceCollection.AddSingleton<ICustomerRepository, CustomerRepository>();
            serviceCollection.AddSingleton<ITransactionRepository, TransactionRepository>();
            serviceCollection.AddSingleton<IUnitOfWork, UnitOfWork>();

            var ServiceProvider = serviceCollection.BuildServiceProvider();

            UnitOfWork = ServiceProvider.GetService<IUnitOfWork>();
        }
        private void DataSetup()
        {
            UnitOfWork.CustomerRepository.CreatCustomer(new DAL.Models.Customer
            {
                CustomerID = 1,
                Name = "Mina",
                Surname = "Maurice"
            });
            UnitOfWork.CustomerRepository.CreatCustomer(new DAL.Models.Customer
            {
                CustomerID = 2,
                Name = "John",
                Surname = "Fekry"
            });
        }
    }
}
