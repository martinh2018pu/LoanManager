using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoanManager.Models
{
    public class Loan : BaseModel
    {
        [Required, Range(0, 10000)]
        public int Amount { get; set; }

        [Required]
        public string EGN { get; set; }

        public DateTime ReceivedOn { get; set; }
    }
}