using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;

namespace WebApplication4.Helpers
{
    public static class TransactionHelper
    {
        private static ApplicationDbContext dbContext = new ApplicationDbContext();

        public static bool CategoryIsDeposit(int categoryId)
        {
            return dbContext.Categories.Find(categoryId).IsDeposit;
        }

    }
}