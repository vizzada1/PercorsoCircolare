namespace PercorsoCircolare.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PercorsoCircolareSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        Resource_ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Resources", t => t.Resource_ResourceId, cascadeDelete: true)
                .Index(t => t.Resource_ResourceId);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        ResourceId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 8),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ResourceId);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        BuildingId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BuildingId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AvailableSeats = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Building_BuildingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.Buildings", t => t.Building_BuildingId, cascadeDelete: true)
                .Index(t => t.Building_BuildingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "Building_BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Bookings", "Resource_ResourceId", "dbo.Resources");
            DropIndex("dbo.Rooms", new[] { "Building_BuildingId" });
            DropIndex("dbo.Bookings", new[] { "Resource_ResourceId" });
            DropTable("dbo.Rooms");
            DropTable("dbo.Buildings");
            DropTable("dbo.Resources");
            DropTable("dbo.Bookings");
        }
    }
}
