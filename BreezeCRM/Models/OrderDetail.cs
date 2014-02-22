using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreezeCRM.Models
{
    public partial class OrderDetail
    {
        [Column(Order=0),Key]
        public int OrderID { get; set; }
        [Column(Order = 1), Key]
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
