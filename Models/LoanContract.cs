using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanManagementSystem.Models
{
    public class LoanContract
    {
        public int ID { get; set; }     
        public DateTime DateContractStarts { get; set; }
        public DateTime DateContractEnds { get; set; }
        public double InterestRate { get; set; }
        public double LoanAmount { get; set; }
        public string TermsAndCoditions { get; set; }

        public Customer Customer { get; set; }       

        public LoanStatus LoanStatus { get; set; }

        public ICollection<LoanPayment> LoanPayments { get; set; }


    }
}