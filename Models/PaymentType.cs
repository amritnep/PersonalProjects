using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Models
{
    public class PaymentType
    {
        [Key]
        public string PaymentTypeCode { get; set; }
        public string PaymentTypeDescription { get; set; }
    }
}