namespace FilmHaus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Report", new[] { "ReviewReportedId" });
            DropIndex("dbo.Report", "IX_Report");
            AddColumn("dbo.Review", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Review", "Flagged", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Report", new[] { "ReportId", "ReviewReportedId", "ResolvedOn" }, unique: true, name: "IX_Report");
            DropColumn("dbo.Review", "DateOfCreation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Review", "DateOfCreation", c => c.DateTime(nullable: false));
            DropIndex("dbo.Report", "IX_Report");
            AlterColumn("dbo.Review", "Flagged", c => c.Boolean());
            DropColumn("dbo.Review", "CreatedOn");
            CreateIndex("dbo.Report", new[] { "ReportId", "ResolvedOn" }, unique: true, name: "IX_Report");
            CreateIndex("dbo.Report", "ReviewReportedId");
        }
    }
}
