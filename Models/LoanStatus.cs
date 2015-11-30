using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Models
{
    public class LoanStatus
    {
        [Key]
        public string LoanStatusCode { get; set; }
        public string LoanStatusDescription { get; set; }
    }
}