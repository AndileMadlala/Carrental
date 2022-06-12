using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace carrentalservice.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [DisplayName("Car Manufacturer")]
        public string BrandName { get; set; }

        [DisplayName("Car Model")]
        public string CarModel { get; set; }

        [DisplayName("Specifications")]
        public string Specs { get; set; }

        [DisplayName("Fuel Type")]
        public string FuelType { get; set; }

        [DisplayName("Price Per Day")]
        public decimal CostPerDay { get; set; }

        [DisplayName("Deposit")]
        public decimal Desposit { get; set; }
        [DisplayName("Driver Cost")]
        public decimal drivercost { get; set; }
        [DisplayName("Security escort cost")]

        public decimal Securitycost { get; set; }
        
       

        [Display(Name = "Car Image")]
        public byte[] Image { get; set; }

        [Display(Name = "Image Path")]
        public string ImageType { get; set; }
       
    }
}