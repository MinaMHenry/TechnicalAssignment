using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalAssignment.BusinessLogic.Models;
using TechnicalAssignment.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;

namespace TechnicalAssignment.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;
        public AccountController(IAccountService accountService, ICustomerService customerService)
        {
            _accountService = accountService;
            _customerService = customerService;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Post([FromBody]AccountRequest model)
        {
            try
            {
                if (!_customerService.CustomerExists(model.CustomerID))
                    return StatusCode(200,"Customer doesn't Exists");

                Guid accountId = _accountService.CreateAccount(model);

                return StatusCode(StatusCodes.Status201Created,$"Account ID {accountId}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

    }
}
