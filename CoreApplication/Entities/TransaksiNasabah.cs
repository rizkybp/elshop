using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApplication.Entities
{
    public class TransaksiNasabah : BaseEntity
    {
        public int Id { get; set; }

        public int? NasabahId { get; set; }
        public virtual Nasabah Nasabah { get; set; }

        public DateTime? TransactionDate { get; set; }

        
        public string Description { get; set; }

       
        public string DebitCreditStatus { get; set; }

      
        public double? Amount { get; set; }
    }
}
