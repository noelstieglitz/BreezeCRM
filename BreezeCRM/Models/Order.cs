using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreezeCRM.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string OrderNumber { get; set; }
        
        public DateTime DateOrdered { get; set; }

        public decimal Total { get; set; }
        
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}