namespace FilmHaus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4DropListTag : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ListTag", "ListId", "dbo.Lists");
            DropForeignKey("dbo.ListTag", "DetailId", "dbo.Tags");
            DropIndex("dbo.ListTag", new[] { "ListId" });
            DropIndex("dbo.ListTag", new[] { "DetailId" });
            DropIndex("dbo.ReviewShow", "IX_ReviewShow");
            DropIndex("dbo.ReviewShow", new[] { "ReviewId" });
            DropIndex("dbo.Genres", "IX_Detail");
            DropIndex("dbo.Tags", "IX_Detail");
            DropIndex("dbo.Titles", "IX_Detail");
            AddColumn("dbo.People", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Lists", "CreatedOn", c => c.DateTime(nullable: false));
            CreateIndex("dbo.ReviewShow", new[] { "MediaId", "ReviewId", "ObsoletedOn" }, unique: true, name: "IX_ReviewShow");
            DropColumn("dbo.Lists", "DateOfCreation");
            DropColumn("dbo.Tags", "ObsoletedOn");
            DropColumn("dbo.Genres", "ObsoletedOn");
            DropColumn("dbo.Titles", "ObsoletedOn");
            DropColumn("dbo.AspNetUsers", "LastLogin");
            DropTable("dbo.ListTag");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ListTag",
                c => new
                    {
                        ListId = c.Guid(nullable: false),
                        DetailId = c.Guid(nullable: false),
                        ListTagId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ListTagId);
            
            AddColumn("dbo.AspNetUsers", "LastLogin", c => c.DateTime(nullable: false));
            AddColumn("dbo.Titles", "ObsoletedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Genres", "ObsoletedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tags", "ObsoletedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Lists", "DateOfCreation", c => c.DateTime(nullable: false));
            DropIndex("dbo.ReviewShow", "IX_ReviewShow");
            DropColumn("dbo.Lists", "CreatedOn");
            DropColumn("dbo.People", "CreatedOn");
            CreateIndex("dbo.Titles", new[] { "DetailId", "ObsoletedOn" }, unique: true, name: "IX_Detail");
            CreateIndex("dbo.Tags", new[] { "DetailId", "ObsoletedOn" }, unique: true, name: "IX_Detail");
            CreateIndex("dbo.Genres", new[] { "DetailId", "ObsoletedOn" }, unique: true, name: "IX_Detail");
            CreateIndex("dbo.ReviewShow", "ReviewId");
            CreateIndex("dbo.ReviewShow", new[] { "MediaId", "ObsoletedOn" }, unique: true, name: "IX_ReviewShow");
            CreateIndex("dbo.ListTag", "DetailId");
            CreateIndex("dbo.ListTag", "ListId");
            AddForeignKey("dbo.ListTag", "DetailId", "dbo.Tags", "DetailId");
            AddForeignKey("dbo.ListTag", "ListId", "dbo.Lists", "ListId", cascadeDelete: true);
        }
    }
}
