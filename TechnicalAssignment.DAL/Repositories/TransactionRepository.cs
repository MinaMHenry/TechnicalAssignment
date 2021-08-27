using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnicalAssignment.DAL.Interfaces;
using TechnicalAssignment.DAL.Models;

namespace TechnicalAssignment.DAL.Repositories
{
   public class TransactionRepository : ITransactionRepository
    {
        private List<Transaction> _transactions;
        public TransactionRepository()
        {
            _transactions = new List<Transaction>();
        }
        public List<Transaction> GetAccountTransactions(Guid AccountID)
        {
            return _transactions.Where(e => e.AccountID == AccountID).ToList();
        }

        public bool CreatTransaction(Transaction model)
        {
            try
            {
                _transactions.Add(model);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
