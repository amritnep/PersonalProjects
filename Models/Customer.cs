using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }   
        [Required]     
        public string Address { get; set; }
        public double Balance { get; set; }

        public CustomerRating Rating { get; set; }

        public ICollection<LoanContract> LoanContracts { get; set; }
    }
}