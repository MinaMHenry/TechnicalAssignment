using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalAssignment.BusinessLogic.Interfaces;
using TechnicalAssignment.BusinessLogic.Models;
using TechnicalAssignment.BusinessLogic.ViewModels;

namespace TechnicalAssignment.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [Route("{CustomerID}")]
        [HttpGet]
        public IActionResult Get(int CustomerID)
        {
            try
            {
                if (!_customerService.CustomerExists(CustomerID))
                    return StatusCode(200, "Customer doesn't Exists");

                CustomerInformation  viewmodel = _customerService.GetCustomerInformation(CustomerID);

                return StatusCode(StatusCodes.Status200OK, viewmodel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Post([FromBody]CustomerRequest model)
        {
            try
            {
                int customerID = _customerService.CreateCustomer(model);
                return StatusCode(StatusCodes.Status201Created, $"customer ID {customerID}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
    }
}
