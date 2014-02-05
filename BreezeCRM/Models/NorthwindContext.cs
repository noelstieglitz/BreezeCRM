using System.Data.Entity;
using BreezeCRM.Models.Mapping;

namespace BreezeCRM.Models
{
    public partial class NorthwindContext : DbContext
    {
        static NorthwindContext()
        {

            Database.SetInitializer<NorthwindContext>(null);
        }

        public NorthwindContext()
            : base("Name=NorthwindContext")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Territory> Territories { get; set; }
        public DbSet<AlphabeticalListOfProduct> AlphabeticalListOfProduct { get; set; }
        public DbSet<CategorySalesFor997> CategorySalesFor997 { get; set; }
        public DbSet<CurrentProductList> CurrentProductList { get; set; }
        public DbSet<CustomerASuppliersByCity> CustomerASuppliersByCity { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<OrderDetailsExtended> OrderDetailsExtended { get; set; }
        public DbSet<OrderSubtotal> OrderSubtotal { get; set; }
        public DbSet<OrdersQry> OrdersQry { get; set; }
        public DbSet<ProductSalesFor1997> ProductSalesFor1997 { get; set; }
        public DbSet<ProductsAboveAveragePrice> ProductsAboveAveragePrice { get; set; }
        public DbSet<ProductsByCategory> ProductsByCategory { get; set; }
        public DbSet<SalesByCategory> SalesByCategory { get; set; }
        public DbSet<SalesTotalsByAmount> SalesTotalsByAmount { get; set; }
        public DbSet<SummaryOfSalesByQuarter> SummaryOfSalesByQuarter { get; set; }
        public DbSet<SummaryOfSalesByYear> SummaryOfSalesByYear { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CustomerDemographicMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new Order_DetailMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new RegionMap());
            modelBuilder.Configurations.Add(new ShipperMap());
            modelBuilder.Configurations.Add(new SupplierMap());
            modelBuilder.Configurations.Add(new TerritoryMap());
            modelBuilder.Configurations.Add(new Alphabetical_list_of_productMap());
            modelBuilder.Configurations.Add(new Category_Sales_for_1997Map());
            modelBuilder.Configurations.Add(new Current_Product_ListMap());
            modelBuilder.Configurations.Add(new Customer_and_Suppliers_by_CityMap());
            modelBuilder.Configurations.Add(new InvoiceMap());
            modelBuilder.Configurations.Add(new Order_Details_ExtendedMap());
            modelBuilder.Configurations.Add(new Order_SubtotalMap());
            modelBuilder.Configurations.Add(new Orders_QryMap());
            modelBuilder.Configurations.Add(new Product_Sales_for_1997Map());
            modelBuilder.Configurations.Add(new Products_Above_Average_PriceMap());
            modelBuilder.Configurations.Add(new Products_by_CategoryMap());
            modelBuilder.Configurations.Add(new Sales_by_CategoryMap());
            modelBuilder.Configurations.Add(new Sales_Totals_by_AmountMap());
            modelBuilder.Configurations.Add(new Summary_of_Sales_by_QuarterMap());
            modelBuilder.Configurations.Add(new Summary_of_Sales_by_YearMap());
        }
    }
}
