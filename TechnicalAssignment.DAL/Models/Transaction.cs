using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TechnicalAssignment.DAL.Models
{
    public class Transaction
    {
        public Guid ReferenceNo => Guid.NewGuid();
        public DateTime Date => DateTime.Now;
        public String Description { get; set; }
        public Double? Debit { get; set; }
        public Double? Credit { get; set; }
        public Double Balance { get; set; }
        [JsonIgnore]
        public Guid AccountID { get; set; }

    }
}
