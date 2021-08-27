using System;
using System.Collections.Generic;
using System.Text;
using TechnicalAssignment.BusinessLogic.Models;

namespace TechnicalAssignment.BusinessLogic.Interfaces
{
    public interface IAccountService
    {
        Guid CreateAccount(AccountRequest model);
        bool AccountExists(Guid AccountId);

    }
}
