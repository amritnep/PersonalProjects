using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.DAL
{
    public class LoanInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LoanContext>
    {
        protected override void Seed(LoanContext context)
        {
            //Initialize Customer rating
            var ratings = new List<CustomerRating>
            {
                new CustomerRating { ID=5, CustomerRatingDescription = "Highest Rating" },
                new CustomerRating { ID=1, CustomerRatingDescription = "Lowest Rating" }
            };
            ratings.ForEach(c => context.CustomerRatings.Add(c));
            context.SaveChanges();

            //Initialize Loan status table
            var loanStatuses = new List<LoanStatus>
            {
                new LoanStatus { LoanStatusCode="Active", LoanStatusDescription="Loan has started."},
                new LoanStatus { LoanStatusCode="Closed", LoanStatusDescription="Loan has been paid off."}
            };
            loanStatuses.ForEach(l => context.LoanStatuses.Add(l));
            context.SaveChanges();

            //Initialize Payment type table
            var paymentTypes = new List<PaymentType>
            {
                new PaymentType { PaymentTypeCode="Cash", PaymentTypeDescription="Loan paid in cash."},
                new PaymentType { PaymentTypeCode="Cheque", PaymentTypeDescription="Loan paid in cheque."}
            };
            paymentTypes.ForEach(p => context.PaymentTypes.Add(p));
            context.SaveChanges();

            //Initialize Customer table
            var customers = new List<Customer>
            {
                new Customer {Name="Ganesh Sah", Address="5951 Riverside Drive", Balance=5000},
                new Customer {Name="Kiran Sah", Address="5951 Riverside Drive", Balance=2000}
            };
            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();            

            //Initialize Loan Contract table
            var loanContracts = new List<LoanContract>
            {
                new LoanContract { ID=1, Customer=customers[0], DateContractEnds=System.DateTime.Now, DateContractStarts=System.DateTime.Now, InterestRate=12, LoanAmount=1000, LoanStatus=loanStatuses[0], TermsAndCoditions="Test" }                
            };
            loanContracts.ForEach(l => context.LoanContracts.Add(l));
            context.SaveChanges();

            var loanPayments = new List<LoanPayment>
            {
                new LoanPayment {ID=1, AmountOfPayment=100, DateOfPayment=System.DateTime.Now, LoanContract=loanContracts[0], PaymentType=paymentTypes[0], Remarks="Received." }
            };
            loanPayments.ForEach(l => context.LoanPayments.Add(l));
            context.SaveChanges();
        }
    }
}