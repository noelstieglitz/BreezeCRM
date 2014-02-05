using System;
using System.Collections.Generic;

namespace BreezeCRM.Models
{
    public partial class SummaryOfSalesByQuarter
    {
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public int OrderID { get; set; }
        public Nullable<decimal> Subtotal { get; set; }
    }
}
