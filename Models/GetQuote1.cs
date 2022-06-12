using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace carrentalservice.Models
{
    public class GetQuote1
    {
        [Key]
        public string CarID { get; set; }

        public string Car1 { get; set; }
        public string car2 { get; set; }
    }
}