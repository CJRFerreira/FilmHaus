namespace FilmHaus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update10ReviewExpansion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "ReportReason", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "ReportReason");
        }
    }
}
