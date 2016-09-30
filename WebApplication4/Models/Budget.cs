using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;

namespace WebApplication4.Models
{
    public class Budget
{
    public Budget()
    {
        BudgetItems = new HashSet<BudgetItem>();
    }
    public int Id { get; set; }
    public bool Active { get; set; }
    public int HouseholdId { get; set; }
    public string Name { get; set; }
    public virtual Household Household { get; set; }
    public virtual ICollection<BudgetItem> BudgetItems { get; set; }
}
}