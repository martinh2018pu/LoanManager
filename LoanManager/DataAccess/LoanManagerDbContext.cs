using LoanManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoanManager.DataAccess
{
    public class LoanManagerDbContext : DbContext
    {
        public DbSet<Loan> Loans { get; set; }

        public LoanManagerDbContext() : base("LoanManager")
        {
        }
    }
}