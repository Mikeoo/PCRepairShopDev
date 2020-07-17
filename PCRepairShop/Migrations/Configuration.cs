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
        }

        protected override void Seed(PCRepairShop.DAL.PCRepairContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Customers.AddOrUpdate(x => x.Id,
                new Models.Customer() { FirstName = "Jane", LastName = "Bee" },
                new Models.Customer() { FirstName = "Pieter", LastName = "Pan" },
                new Models.Customer() { FirstName = "Mike", LastName = "Oo" },
                new Models.Customer() { FirstName = "Marcel", LastName = "Parcel" },
                new Models.Customer() { FirstName = "Cookie", LastName = "Monster" },
                new Models.Customer() { FirstName = "Rowan", LastName = "Bierbrouwer" });
            context.SaveChanges();

            context.RepairOrders.AddOrUpdate(x => x.Id,
            new RepairOrder()
            {
                StartDate = new System.DateTime(2021, 07, 07),
                EndDate = new System.DateTime(2022, 07, 12),
                Status = Status.Awaiting,
                Customer = context.Customers.FirstOrDefault(c => c.FirstName == "Rowan")
            },
            new RepairOrder()
            {
                StartDate = new System.DateTime(2019, 07, 07),
                EndDate = new System.DateTime(2020, 07, 10),
                Status = Status.Awaiting,
                Customer = context.Customers.FirstOrDefault(c => c.FirstName == "Jane")
            },
            new RepairOrder()
            {
                StartDate = new System.DateTime(2020, 12, 07),
                EndDate = new System.DateTime(2021, 01, 12),
                Status = Status.AwaitingParts,
                Customer = context.Customers.FirstOrDefault(c => c.FirstName == "Pieter")
            },
            new RepairOrder()
                {
                StartDate = new System.DateTime(2020, 07, 17),
                EndDate = new System.DateTime(2020, 07, 12),
                Status = Status.Processing,
                Customer = context.Customers.FirstOrDefault(c => c.FirstName == "Marcel")
                },
            new RepairOrder()
                {
                StartDate = new System.DateTime(2020, 07, 17),
                EndDate = new System.DateTime(2020, 07, 23),
                Status = Status.Closed,
                Customer = context.Customers.FirstOrDefault(c => c.FirstName == "Cookie")
                }
            );
            context.SaveChanges();

            context.RepairGuys.AddOrUpdate(x => x.Id,
                new Models.RepairGuy() { FirstName = "Bob", LastName = "De Bouwer" },
                new Models.RepairGuy() { FirstName = "Tinker", LastName = "Bell" },
                new Models.RepairGuy() { FirstName = "Prut", LastName = "ser" });
            context.SaveChanges();

            context.PartListItems.AddOrUpdate(x => x.Id,
                new PartListItem()
                {
                    Brand = "Nvidia GTX",
                    Name =  "1660 Super",
                    Price =  new decimal(250),
                },

                new PartListItem()
                {
                    Brand = "Nvidia RTX",
                    Name =  "2080",
                    Price =  new decimal(1199.95),
                },

                new PartListItem()
                {
                    Brand = "AMD Ryzen",
                    Name =  "3800X",
                    Price =  new decimal(325.25),
                },
                new PartListItem()
                {
                    Brand = "Intel",
                    Name =  "i7-2600k",
                    Price =  new decimal(100.50),
                },
                new PartListItem()
                {
                    Brand = "AMD",
                    Name =  "Sapphire pulse",
                    Price =  new decimal(190.56),
                }
                );
            context.SaveChanges();

            context.Parts.AddOrUpdate(x => x.Id,
                new Part()
                {
                    InStock = true,
                    PartListItem = context.PartListItems.FirstOrDefault(c => c.Name == "1660 Super")
                },

                new Part()
                {
                    InStock = true,
                    PartListItem = context.PartListItems.FirstOrDefault(c => c.Name == "2080")
                },

                new Part()
                {
                    InStock = true,
                    PartListItem = context.PartListItems.FirstOrDefault(c => c.Name == "i7-2600k")
                },
                new Part()
                {
                    InStock = true,
                    PartListItem = context.PartListItems.FirstOrDefault(c => c.Name == "Sapphire pulse")
                });

            context.SaveChanges();
        }
    }
}
