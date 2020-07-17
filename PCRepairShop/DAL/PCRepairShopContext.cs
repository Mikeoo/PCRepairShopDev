using PCRepairShop.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PCRepairShop.DAL
{
    public class PCRepairContext : DbContext
    {

        public PCRepairContext() : base("PCRepairShop")
        {
        }

        public DbSet<RepairOrder> RepairOrders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartListItem> PartListItems { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<PCRepairShop.Models.RepairGuy> RepairGuys { get; set; }
    }
}