namespace FilmHaus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update6RemovedMediaIndex : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Films", "IX_Media");
            DropIndex("dbo.Shows", "IX_Media");
            DropColumn("dbo.Films", "ObsoletedOn");
            DropColumn("dbo.Shows", "ObsoletedOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shows", "ObsoletedOn", c => c.DateTime());
            AddColumn("dbo.Films", "ObsoletedOn", c => c.DateTime());
            CreateIndex("dbo.Shows", new[] { "MediaId", "ObsoletedOn" }, unique: true, name: "IX_Media");
            CreateIndex("dbo.Films", new[] { "MediaId", "ObsoletedOn" }, unique: true, name: "IX_Media");
        }
    }
}
