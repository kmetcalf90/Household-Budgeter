using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
       
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public bool Reconciled { get; set; }
        public float ReconciledAmount { get; set; }
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yy, h:mm tt}")]
        public DateTimeOffset Date { get; set; }
        public bool IsIncome { get; set; }
        public bool Void { get; set; }

        public decimal Amount { get; set; }
        
        public virtual ApplicationUser User { get; set; }
        public virtual BankAccount Account { get; set; }
        public virtual Category Category { get; set; }
    }
}