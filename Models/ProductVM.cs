using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagementSPAWithEntityFramework.Models
{
    public class ProductVM
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
    }
}