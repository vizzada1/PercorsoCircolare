namespace PercorsoCircolare.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationsChangeBooking1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bookings", "Resource");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "Resource", c => c.Int(nullable: false));
        }
    }
}
