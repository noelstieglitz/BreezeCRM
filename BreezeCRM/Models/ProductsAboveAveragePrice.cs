using System;
using System.Collections.Generic;

namespace BreezeCRM.Models
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
    }
}
