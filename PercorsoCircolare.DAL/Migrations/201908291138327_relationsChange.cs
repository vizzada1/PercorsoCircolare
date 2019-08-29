namespace PercorsoCircolare.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationsChange : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Rooms", name: "Building_BuildingId", newName: "BuildingId");
            RenameIndex(table: "dbo.Rooms", name: "IX_Building_BuildingId", newName: "IX_BuildingId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Rooms", name: "IX_BuildingId", newName: "IX_Building_BuildingId");
            RenameColumn(table: "dbo.Rooms", name: "BuildingId", newName: "Building_BuildingId");
        }
    }
}
