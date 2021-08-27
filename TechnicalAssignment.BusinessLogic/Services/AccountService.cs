using System;
using System.Collections.Generic;
using System.Text;
using TechnicalAssignment.BusinessLogic.Interfaces;
using TechnicalAssignment.BusinessLogic.Models;
using TechnicalAssignment.DAL.Interfaces;
using TechnicalAssignment.DAL.Models;

namespace TechnicalAssignment.BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }
        public Guid CreateAccount(AccountRequest model)
        {
                Guid accountID = Guid.NewGuid();
                _unitOfWork.AccountRepository.CreatAccount(new Account
                {
                    AccountID = accountID,
                    Balance = model.InitialCredit,
                    CustomerID = model.CustomerID
                });

                if (model.InitialCredit != 0)
                {
                    _unitOfWork.TransactionRepository.CreatTransaction(new Transaction()
                    {
                        AccountID = accountID,
                        Balance = model.InitialCredit,
                        Credit = model.InitialCredit,
                        Description = $"Open New Account with Amount {model.InitialCredit}",
                    });

                }
                return accountID;
        }
        public bool AccountExists(Guid AccountId)
        {
            Account account = _unitOfWork.AccountRepository.GetAccount(AccountId);
            return account == null ? false : true;
        }

    }
}
