using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalAssignment.BusinessLogic.Interfaces;
using TechnicalAssignment.DAL.Models;

namespace TechnicalAssignment.Controllers
{
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IAccountService _accountService;

        public TransactionsController(ITransactionService TransactionService, IAccountService AccountService)
        {
            _transactionService = TransactionService;
            _accountService = AccountService;
        }

        [Route("{AccountID}")]
        [HttpGet]
        public IActionResult Get(Guid AccountID)
        {
            try
            {
                if (!_accountService.AccountExists(AccountID))
                    return StatusCode(403, "Account doesn't Exists");

                List<Transaction> model = _transactionService.GetAccountTransactions(AccountID);

                return StatusCode(StatusCodes.Status200OK, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
    }
}