using System;
using System.Collections.Generic;
using System.Text;
using TechnicalAssignment.DAL.Interfaces;

namespace TechnicalAssignment.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAccountRepository AccountRepository { get; set;}
        public ICustomerRepository CustomerRepository { get; set; }
        public ITransactionRepository TransactionRepository { get; set; }

        public UnitOfWork(ITransactionRepository TransactionRepository, ICustomerRepository CustomerRepository, IAccountRepository AccountRepository)
        {
            this.AccountRepository = AccountRepository;
            this.CustomerRepository = CustomerRepository;
            this.TransactionRepository = TransactionRepository;
        }
    }
}
