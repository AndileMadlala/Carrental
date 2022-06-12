using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace carrentalservice.Models
{
    public class CarQuote
    {
        [Key]
        public int QuoteId { get; set; }

        [DisplayName("Pick Up Date")]
        [DataType(DataType.Date)]
        public DateTime PickUp { get; set; }

        [DisplayName("Drop Off Date")]
        [DataType(DataType.Date)]
        public DateTime DropOff { get; set; }

        [DisplayName("Pick Up Time")]
        [DataType(DataType.Time)]
        public DateTime PickTime { get; set; }

        [DisplayName("Drop Off Time")]
        [DataType(DataType.Time)]
        public DateTime DropTime { get; set; }
        
        [DisplayName("Date Car booked on")]
        [DataType(DataType.Date)]
        public DateTime Currentdate { get; set; }
        [DisplayName("Total Price")]
        public decimal TotalPrice { get; set; }

        [DisplayName("Basic Price")]
        public decimal BasicPrice { get; set; }
        public decimal Basicsecuritycost { get; set; }
        public decimal Basicdrivercost { get; set; }
        public decimal Securitycost2 { get; set; }
       
        public string Drivercostrad { get; set; }
        public string securityrad { get; set; }
        public decimal drivercost2 { get; set; }
        [DisplayName("Brandname")]
        public string bname { get; set; }
        [DisplayName("Car model")]
        public string Carmod { get; set; }
       


        [DisplayName("Number of Days")]
        public int NumOfDays { get; set; }
        

        public int CarId { get; set; }

        ApplicationDbContext db = new ApplicationDbContext();

        public int NumberOfDays()
        {
            NumOfDays = (DropOff - PickUp).Days;
            return NumOfDays;
        }

        public decimal getBasic(int id)
        {
            var basic = (from c in db.Cars
                         where c.CarId == id
                         select c.Desposit).FirstOrDefault();

            BasicPrice = Convert.ToDecimal(basic);
            return BasicPrice;
        }
        public string getBrandname(int id)
        {
            var brand = (from c in db.Cars
                         where c.CarId == id
                         select c.BrandName).FirstOrDefault();

           bname  = brand;
            return bname ;
        }

        public string getCarmodel(int id)
        {
            var carmod = (from c in db.Cars
                         where c.CarId == id
                         select c.CarModel).FirstOrDefault();

            Carmod = carmod;
            return Carmod;
        }

        public decimal getdrivercost(int id)
       {
           var basic2 = (from c in db.Cars
                        where c.CarId == id
                        select c.drivercost).FirstOrDefault();

           Basicdrivercost = Convert.ToDecimal(basic2);
           return Basicdrivercost;
       }
       public decimal getSecuritycost(int id)
       {
           var basic3 = (from c in db.Cars
                         where c.CarId == id
                         select c.Securitycost).FirstOrDefault();

           Basicsecuritycost = Convert.ToDecimal(basic3);
           return Basicsecuritycost;
       }

       public decimal CalcDrivercost()
       {

           if (Drivercostrad == "Yes")

           {
               drivercost2 = Basicdrivercost;
           }

           else if (Drivercostrad == "No")
           {
               drivercost2 = 0;
           }

   
           return (drivercost2);
       }
       public decimal CalcSecuritycost()
       {

           if (securityrad == "Yes")

           {
               Securitycost2 = Basicsecuritycost;
           }

           else if (Drivercostrad == "No")
           {
               Securitycost2 = 0;
           }

            return Securitycost2;
       }
        


        public decimal getTotalPrice(int id)
        {
            var costPerDay = (from c in db.Cars
                              where c.CarId == id
                              select c.CostPerDay).FirstOrDefault();

            TotalPrice = Convert.ToDecimal(costPerDay * NumOfDays) + Convert.ToDecimal(BasicPrice) + Convert.ToDecimal(CalcSecuritycost())+ Convert.ToDecimal(CalcDrivercost());
            return TotalPrice;
        }

    }
}