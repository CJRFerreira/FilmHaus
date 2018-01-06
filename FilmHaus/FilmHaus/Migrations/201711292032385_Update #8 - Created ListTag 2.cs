namespace FilmHaus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update8CreatedListTag2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListTags",
                c => new
                    {
                        ListId = c.Guid(nullable: false),
                        DetailId = c.Guid(nullable: false),
                        ListTagId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ListTagId)
                .ForeignKey("dbo.Lists", t => t.ListId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.DetailId)
                .Index(t => t.ListId)
                .Index(t => t.DetailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListTags", "DetailId", "dbo.Tags");
            DropForeignKey("dbo.ListTags", "ListId", "dbo.Lists");
            DropIndex("dbo.ListTags", new[] { "DetailId" });
            DropIndex("dbo.ListTags", new[] { "ListId" });
            DropTable("dbo.ListTags");
        }
    }
}
