using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BreezeCRM.Models
{
    public partial class CustomerDemographic
    {
        public CustomerDemographic()
        {
            this.Customers = new List<Customer>();
        }

        [Key]
        public string CustomerTypeID { get; set; }
        public string CustomerDesc { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
