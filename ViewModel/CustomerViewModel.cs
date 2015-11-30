﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoanManagementSystem.ViewModel
{
    public class CustomerViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Editable(false)]
        public double Balance { get; set; }
    }
}