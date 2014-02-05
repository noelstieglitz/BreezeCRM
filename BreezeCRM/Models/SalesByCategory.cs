using System;
using System.Collections.Generic;

namespace BreezeCRM.Models
{
    public partial class SalesByCategory
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> ProductSales { get; set; }
    }
}
