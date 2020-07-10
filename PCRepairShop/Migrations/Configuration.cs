namespace PCRepairShop.Migrations
{
    using PCRepairShop.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PCRepairShop.DAL.PCRepairContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PCRepairShop.DAL.PCRepairContext";
        }

        protected override void Seed(PCRepairShop.DAL.PCRepairContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
           
            context.RepairOrders.AddOrUpdate(x => x.Id,
                new Models.RepairOrder()
                {
                    StartDate = new System.DateTime(2020, 07, 07),
                    EndDate = new System.DateTime(2020, 07, 12),
                    Status = Status.Awaiting,

                },
                new Models.RepairOrder()
                {
                    StartDate = new System.DateTime(2020, 07, 07),
                    EndDate = new System.DateTime(2020, 07, 10),
                    Status = Status.Closed,

                }
                );
        }
    }
}
