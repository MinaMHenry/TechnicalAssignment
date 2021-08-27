using System;
using System.Collections.Generic;
using System.Text;
using TechnicalAssignment.DAL.Models;

namespace TechnicalAssignment.BusinessLogic.Interfaces
{
    public interface ITransactionService
    {
        List<Transaction> GetAccountTransactions(Guid AccountId);

    }
}
