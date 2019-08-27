using System.Data.Entity.Core.Common.CommandTrees;

namespace PercorsoCircolare.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resourceIdentityDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "Resource_ResourceId", "dbo.Resources");
            DropPrimaryKey("dbo.Resources");
            DropTable("dbo.Resources");

            CreateTable(
                    "dbo.Resources",
                    c => new
                    {
                        ResourceId = c.Int(nullable: false, identity: false),
                        Username = c.String(nullable: false, maxLength: 8),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ResourceId);

            AddForeignKey("dbo.Bookings", "Resource_ResourceId", "dbo.Resources", "ResourceId");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Resource_ResourceId", "dbo.Resources");
            DropPrimaryKey("dbo.Resources");
            DropTable("dbo.Resources");

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

            AddForeignKey("dbo.Bookings", "Resource_ResourceId", "dbo.Resources", "ResourceId");
        }
    }
}
