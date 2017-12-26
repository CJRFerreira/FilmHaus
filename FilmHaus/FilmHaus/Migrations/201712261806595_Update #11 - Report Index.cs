namespace FilmHaus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update11ReportIndex : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Reports", "IX_Report");
            DropIndex("dbo.Reports", new[] { "ReportingUserId" });
            DropIndex("dbo.Reports", new[] { "UserReportedId" });
            CreateIndex("dbo.Reports", new[] { "ReportId", "ReviewReportedId", "ReportingUserId", "UserReportedId", "ResolvedOn" }, unique: true, name: "IX_Report");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Reports", "IX_Report");
            CreateIndex("dbo.Reports", "UserReportedId");
            CreateIndex("dbo.Reports", "ReportingUserId");
            CreateIndex("dbo.Reports", new[] { "ReportId", "ReviewReportedId", "ResolvedOn" }, unique: true, name: "IX_Report");
        }
    }
}
