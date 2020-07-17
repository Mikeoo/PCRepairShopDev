namespace PCRepairShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class completedseeddata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PartListItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Part",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InStock = c.Boolean(nullable: false),
                        PartListItem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PartListItem", t => t.PartListItem_Id)
                .Index(t => t.PartListItem_Id);
            
            CreateTable(
                "dbo.RepairGuy",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RepairOrder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Description = c.String(),
                        Customer_Id = c.Int(),
                        RepairGuy_Id = c.Int(),
                        UsedPart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Customer_Id)
                .ForeignKey("dbo.RepairGuy", t => t.RepairGuy_Id)
                .ForeignKey("dbo.Part", t => t.UsedPart_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.RepairGuy_Id)
                .Index(t => t.UsedPart_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RepairOrder", "UsedPart_Id", "dbo.Part");
            DropForeignKey("dbo.RepairOrder", "RepairGuy_Id", "dbo.RepairGuy");
            DropForeignKey("dbo.RepairOrder", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.Part", "PartListItem_Id", "dbo.PartListItem");
            DropIndex("dbo.RepairOrder", new[] { "UsedPart_Id" });
            DropIndex("dbo.RepairOrder", new[] { "RepairGuy_Id" });
            DropIndex("dbo.RepairOrder", new[] { "Customer_Id" });
            DropIndex("dbo.Part", new[] { "PartListItem_Id" });
            DropTable("dbo.RepairOrder");
            DropTable("dbo.RepairGuy");
            DropTable("dbo.Part");
            DropTable("dbo.PartListItem");
            DropTable("dbo.Customer");
        }
    }
}
