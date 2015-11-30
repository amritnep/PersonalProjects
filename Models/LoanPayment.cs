using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanManagementSystem.Models
{
    public class LoanPayment
    {
        public int ID { get; set; }
        public DateTime DateOfPayment { get; set; }
        public double AmountOfPayment { get; set; }
        public string Remarks { get; set; }

        public LoanContract LoanContract { get; set; }

        public PaymentType PaymentType { get; set; }
    }
}