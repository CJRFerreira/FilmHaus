namespace FilmHaus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewModelChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "ReviewType", c => c.Int(nullable: false));
            AlterColumn("dbo.UserFilmRating", "Rating", c => c.Int(nullable: false));
            AlterColumn("dbo.UserShowRating", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserShowRating", "Rating", c => c.Int());
            AlterColumn("dbo.UserFilmRating", "Rating", c => c.Int());
            DropColumn("dbo.Reviews", "ReviewType");
        }
    }
}
