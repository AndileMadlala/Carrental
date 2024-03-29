﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace carrentalservice.Models
{
    public class Payment
    {
        [Key]
        [Display(Name = "Payment ID")]
        public int PID { get; set; }
        [Display(Name = "Credit Card Holder")]
        [Required]
        public string CreditCarholder { get; set; }
        [Required]
        [Display(Name = "Expiry Date")]
        public string expDate { get; set; }
        [Required]
        [Display(Name = "Credit Card Number")]
        public string CreditcardNo { get; set; }
        [Required]
        [Display(Name = "CVV Number")]
        public string CVV { get; set; }
        //[Required]
        //public string Status { get; set; }
        //[Display(Name = "Delivery Cost")]
        //[DataType(DataType.Currency)]
        //public double deliveryCost { get; set; }
        //[DataType(DataType.Currency)]
        //public double Total { get; set; }

        
    }
}