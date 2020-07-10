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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}