using System;
using System.Collections.Generic;
using System.Text;
using TechnicalAssignment.BusinessLogic.Interfaces;
using TechnicalAssignment.DAL.Interfaces;
using TechnicalAssignment.DAL.Models;

namespace TechnicalAssignment.BusinessLogic.Services
{
   public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionService(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        public List<Transaction> GetAccountTransactions(Guid AccountId)
        {
           return _unitOfWork.TransactionRepository.GetAccountTransactions(AccountId);
        }
    }
}
