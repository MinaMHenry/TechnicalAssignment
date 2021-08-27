using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalAssignment.DAL.Interfaces
{
   public interface IUnitOfWork
    {
         IAccountRepository AccountRepository { get;  }
         ICustomerRepository CustomerRepository { get; }
         ITransactionRepository TransactionRepository { get;}
    }
}
