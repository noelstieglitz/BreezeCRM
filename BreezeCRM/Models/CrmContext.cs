using System.Data.Entity;

namespace BreezeCRM.Models
{
    public class CrmContext : DbContext
    {
        public CrmContext() : base("CrmContext")
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}