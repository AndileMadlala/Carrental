using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace carrentalservice.Models
{
    public class driver
    {
        [Key]

        public int DriverID { get; set; }
        [DisplayName("Driver Name")]
        public string Drivername { get; set; }
        [DisplayName("Cost per Kilometre")]
        public double costPerKilo { get; set; }

        [Display(Name = "Driver Image")]
        public byte[] Image2 { get; set; }

        [Display(Name = "Image Path")]
        public string ImageType2 { get; set; }
    }
}