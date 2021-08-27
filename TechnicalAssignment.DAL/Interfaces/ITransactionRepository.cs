using System;
using System.Collections.Generic;
using System.Text;
using TechnicalAssignment.DAL.Models;

namespace TechnicalAssignment.DAL.Interfaces
{
   public interface ITransactionRepository
    {
        List<Transaction> GetAccountTransactions(Guid AccountID);
        bool CreatTransaction(Transaction model);

    }
}
