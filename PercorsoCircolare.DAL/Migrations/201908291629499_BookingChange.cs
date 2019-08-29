namespace PercorsoCircolare.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "RoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "RoomId");
            AddForeignKey("dbo.Bookings", "RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Bookings", new[] { "RoomId" });
            DropColumn("dbo.Bookings", "RoomId");
        }
    }
}
