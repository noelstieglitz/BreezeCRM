using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BreezeCRM.Models.Mapping
{
    public class Current_Product_ListMap : EntityTypeConfiguration<CurrentProductList>
    {
        public Current_Product_ListMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ProductID, t.ProductName });

            // Properties
            this.Property(t => t.ProductID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("Current Product List");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
        }
    }
}
