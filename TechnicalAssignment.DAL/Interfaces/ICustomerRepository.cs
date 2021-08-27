using System;
using System.Collections.Generic;
using System.Text;
using TechnicalAssignment.DAL.Models;

namespace TechnicalAssignment.DAL.Interfaces
{
    public interface ICustomerRepository
    {
        int GenerateCustomerID();
        List<Customer> GetCustomers();
        Customer GetCustomer(int CustomerID);
        bool CreatCustomer(Customer model);
        bool UpdateCustomer(Customer model);
        bool DeleteCustomer(int CustomerID);
    }
}
