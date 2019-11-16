using LoanManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanManager.DataAccess
{
    public class LoansRepository : BaseRepository<Loan>
    {
        public LoansRepository() : base()
        {
        }
    }
}