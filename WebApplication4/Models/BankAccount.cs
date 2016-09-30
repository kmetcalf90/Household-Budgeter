using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Util;

namespace WebApplication4.Models
{
    public class BankAccount
    {
        public BankAccount()
        {
        Transactions = new HashSet<Transaction>();
        }

    public int Id { get; set; }
    public string Name { get; set; }
    public int HouseholdId { get; set; }
   
    public float Balance { get; set; }
    public bool Active { get; set; }
    public float ReconciledBalance { get; set; }
    public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Household Household { get; set; }
}
}