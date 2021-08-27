using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalAssignment.DAL.Models
{
    public class Account
    {
        public Guid AccountID { get; set; }
        public double Balance { get; set; }
        public int CustomerID { get; set; }
        public DateTime CreationDate => DateTime.Now;
    }
}
