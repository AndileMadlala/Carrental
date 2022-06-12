using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using carrentalservice.Models;

namespace carrentalservice.Views.drivers
{
    public class driverQuote
    {
        [Key]
        public int DriveID { get; set; }
       
        public string droploc { get; set; }
        public string pickuploc { get; set;}
        public int DriverID { get; set; }
        
        ApplicationDbContext db = new ApplicationDbContext();

    }
}