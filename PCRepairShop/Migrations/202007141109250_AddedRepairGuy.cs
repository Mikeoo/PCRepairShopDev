namespace PCRepairShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRepairGuy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RepairOrder", "Description", c => c.String());
            DropColumn("dbo.RepairOrder", "Counter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RepairOrder", "Counter", c => c.Int(nullable: false));
            DropColumn("dbo.RepairOrder", "Description");
        }
    }
}
