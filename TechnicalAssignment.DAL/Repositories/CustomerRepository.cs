using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnicalAssignment.DAL.Interfaces;
using TechnicalAssignment.DAL.Models;

namespace TechnicalAssignment.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> _customers;
        public CustomerRepository()
        {
            _customers = new List<Customer>();
        }

        public int GenerateCustomerID()
        {
            return _customers.Count > 0 ? _customers.Max(e => e.CustomerID) + 1 : 1;
        }
        public List<Customer> GetCustomers()
        {
            return _customers;
        }
        public Customer GetCustomer(int CustomerID)
        {
            return _customers.Where(e => e.CustomerID == CustomerID).SingleOrDefault();
        }

        public bool CreatCustomer(Customer model)
        {
            try
            {
                _customers.Add(model);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateCustomer(Customer model)
        {
            try
            {
                IEnumerable<Customer> Customers = _customers.Where(e => e.CustomerID == model.CustomerID);
                foreach (var customer in Customers)
                {
                    customer.Name = model.Name;
                    customer.Surname = model.Surname;
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteCustomer(int CustomerID)
        {
            Customer customer = _customers.Where(e => e.CustomerID == CustomerID).SingleOrDefault();
            return customer != null ? _customers.Remove(customer) : false;
        }

    }
}
