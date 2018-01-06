namespace FilmHaus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update13IsActiveforReviews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "IsActive");
        }
    }
}
