using System.Data.Entity;

namespace BreezeCRM.Models
{
    public class CrmContext : DbContext
    {
        public CrmContext() : base("CrmContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}