using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_CRUD.Models
{
    public class Location
{
        public int LocationID { get; set; }
        public string Name { get; set; }
        public double CostRate { get; set; }
        public decimal Availability { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
