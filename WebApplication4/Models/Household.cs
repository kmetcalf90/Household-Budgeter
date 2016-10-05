using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication4.Models;

namespace WebApplication4.Models
{
    public class Household
    { 
    public Household()
    {
        Accounts = new HashSet<BankAccount>();
        Budgets = new HashSet<Budget>();
            Users = new HashSet<ApplicationUser>();
            this.BudgetItems = new HashSet<BudgetItem>();
            Categories = new HashSet<Category>();
    }

 

    public int Id { get; set; }
    [Display(Name = "Name")]
    public string Name { get; set; }
    [Display(Name = "Owner")]
   
   
   
    public virtual ICollection<BankAccount> Accounts { get; set; }
    public virtual ICollection<Budget> Budgets { get; set; }
    public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<BudgetItem> BudgetItems { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
}
}