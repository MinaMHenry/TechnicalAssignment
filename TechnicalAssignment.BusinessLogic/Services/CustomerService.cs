using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechnicalAssignment.BusinessLogic.Interfaces;
using TechnicalAssignment.BusinessLogic.Models;
using TechnicalAssignment.BusinessLogic.ViewModels;
using TechnicalAssignment.DAL.Interfaces;
using TechnicalAssignment.DAL.Models;

namespace TechnicalAssignment.BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly object _object = new object();
        public CustomerService(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }
        public int CreateCustomer(CustomerRequest model)
        {
            lock (_object)
            {
                int customerID = _unitOfWork.CustomerRepository.GenerateCustomerID();
                _unitOfWork.CustomerRepository.CreatCustomer(new Customer()
                {
                    CustomerID = customerID,
                    Name = model.Name,
                    Surname = model.Surname
                });
                return customerID;
            }
        }
        public bool CustomerExists(int CustomerId)
        {
            Customer customer = _unitOfWork.CustomerRepository.GetCustomer(CustomerId);
            return customer == null ? false : true;
        }

        public CustomerInformation GetCustomerInformation(int CustomerId)
        {
            CustomerInformation ViewModel = new CustomerInformation();

            Customer customer = _unitOfWork.CustomerRepository.GetCustomer(CustomerId);

            if (customer != null)
            {
                ViewModel.Name = customer.Name;
                ViewModel.Surname = customer.Surname;
                List<Account> accounts = _unitOfWork.AccountRepository.GetCustomerAccounts(customer.CustomerID);
                foreach (var account in accounts)
                {
                    ViewModel.Accounts.Add(new AccountInformation() 

                    {
                        AccountID = account.AccountID,
                        Balance = account.Balance,
                        Transactions = _unitOfWork.TransactionRepository.GetAccountTransactions(account.AccountID)
                    }) ;
                    ViewModel.TotalBalance += account.Balance; 
                }

            }
            return ViewModel;
        }
    }
}
