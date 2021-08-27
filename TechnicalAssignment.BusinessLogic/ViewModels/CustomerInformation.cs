using System;
using System.Collections.Generic;
using System.Text;
using TechnicalAssignment.DAL.Models;

namespace TechnicalAssignment.BusinessLogic.ViewModels
{
    public class CustomerInformation
    {
        public CustomerInformation ()
        {
            Accounts = new List<AccountInformation>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double TotalBalance { get; set; }
        public List<AccountInformation> Accounts { get; set; }
    }
    public class AccountInformation
    {
        public Guid AccountID { get; set; }
        public double Balance { get; set; }
        public List<Transaction> Transactions { get; set; }
}
}
