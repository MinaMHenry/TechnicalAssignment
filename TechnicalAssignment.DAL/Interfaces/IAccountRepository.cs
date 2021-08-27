using System;
using System.Collections.Generic;
using System.Text;
using TechnicalAssignment.DAL.Models;

namespace TechnicalAssignment.DAL.Interfaces
{
   public interface IAccountRepository
    {
        List<Account> GetAccounts();
        Account GetAccount(Guid AccountID);
        List<Account> GetCustomerAccounts(int CustomerID);
        bool CreatAccount(Account model);
        bool DeleteAccount(Guid AccountID);
    }
}
