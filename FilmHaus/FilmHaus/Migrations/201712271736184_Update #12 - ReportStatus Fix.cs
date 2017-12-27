namespace FilmHaus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update12ReportStatusFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reports", "ReportStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reports", "ReportStatus", c => c.Int());
        }
    }
}
