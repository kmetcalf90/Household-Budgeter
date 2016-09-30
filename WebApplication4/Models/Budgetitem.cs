using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class BudgetItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Frequency { get; set; }
        public int CategoryId { get; set; }
        public int BudgetId { get; set; }
        public float Amount { get; set; }
        public bool Active { get; set; }
        public virtual Budget Budget { get; set; }
        public virtual Category Category { get; set; }
    }
}