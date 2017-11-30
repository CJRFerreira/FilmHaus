namespace FilmHaus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update9RequiredReportReasonIndexChanges : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Reports", "IX_Report");
            DropIndex("dbo.ReviewFilms", "IX_ReviewFilm");
            DropIndex("dbo.ReviewFilms", new[] { "ReviewId" });
            AlterColumn("dbo.Reports", "ResolvedOn", c => c.DateTime());
            AlterColumn("dbo.Reports", "ReportStatus", c => c.Int());
            CreateIndex("dbo.Reports", new[] { "ReportId", "ReviewReportedId", "ResolvedOn" }, unique: true, name: "IX_Report");
            CreateIndex("dbo.ReviewFilms", new[] { "MediaId", "ReviewId", "ObsoletedOn" }, unique: true, name: "IX_ReviewFilm");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ReviewFilms", "IX_ReviewFilm");
            DropIndex("dbo.Reports", "IX_Report");
            AlterColumn("dbo.Reports", "ReportStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Reports", "ResolvedOn", c => c.DateTime(nullable: false));
            CreateIndex("dbo.ReviewFilms", "ReviewId");
            CreateIndex("dbo.ReviewFilms", new[] { "MediaId", "ObsoletedOn" }, unique: true, name: "IX_ReviewFilm");
            CreateIndex("dbo.Reports", new[] { "ReportId", "ReviewReportedId", "ResolvedOn" }, unique: true, name: "IX_Report");
        }
    }
}
