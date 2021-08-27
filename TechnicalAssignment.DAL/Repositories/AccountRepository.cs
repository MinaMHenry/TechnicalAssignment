using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnicalAssignment.DAL.Interfaces;
using TechnicalAssignment.DAL.Models;

namespace TechnicalAssignment.DAL.Repositories
{
    public class AccountRepository : IAccountRepository 
    {
        private List<Account> _accounts;
        public AccountRepository()
        {
            _accounts = new List<Account>();
        }

        public List<Account> GetAccounts()
        {
            return _accounts;
        }
        public Account GetAccount(Guid AccountID)
        {
            return _accounts.Where(e => e.AccountID == AccountID).SingleOrDefault();
        }
        public List<Account> GetCustomerAccounts(int CustomerID)
        {
            return _accounts.Where(e => e.CustomerID == CustomerID).ToList();
        }
        public bool CreatAccount(Account model)
        {
            try
            {
                _accounts.Add(model);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteAccount(Guid AccountID)
        {
            Account Account = _accounts.Where(e => e.AccountID == AccountID).SingleOrDefault();
            return Account != null ? _accounts.Remove(Account) : false;
        }
    }
}
