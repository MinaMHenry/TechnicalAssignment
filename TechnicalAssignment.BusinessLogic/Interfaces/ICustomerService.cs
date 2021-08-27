using System;
using System.Collections.Generic;
using System.Text;
using TechnicalAssignment.BusinessLogic.Models;
using TechnicalAssignment.BusinessLogic.ViewModels;

namespace TechnicalAssignment.BusinessLogic.Interfaces
{
    public interface ICustomerService
    {
        int CreateCustomer(CustomerRequest model);
        bool CustomerExists(int CustomerId);
        CustomerInformation GetCustomerInformation(int CustomerId);

    }
}
