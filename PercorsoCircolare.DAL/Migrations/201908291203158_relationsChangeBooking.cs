namespace PercorsoCircolare.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationsChangeBooking : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Bookings", name: "Resource_ResourceId", newName: "ResourceId");
            RenameIndex(table: "dbo.Bookings", name: "IX_Resource_ResourceId", newName: "IX_ResourceId");
            AddColumn("dbo.Bookings", "Resource", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "Resource");
            RenameIndex(table: "dbo.Bookings", name: "IX_ResourceId", newName: "IX_Resource_ResourceId");
            RenameColumn(table: "dbo.Bookings", name: "ResourceId", newName: "Resource_ResourceId");
        }
    }
}
