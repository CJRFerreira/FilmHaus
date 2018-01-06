namespace FilmHaus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilmGenre",
                c => new
                    {
                        MediaId = c.Guid(nullable: false),
                        DetailId = c.Guid(nullable: false),
                        FilmGenreId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FilmGenreId)
                .ForeignKey("dbo.Films", t => t.MediaId)
                .ForeignKey("dbo.Genres", t => t.DetailId)
                .Index(t => t.MediaId)
                .Index(t => t.DetailId);
            
            CreateTable(
                "dbo.FilmPersonTitle",
                c => new
                    {
                        MediaId = c.Guid(nullable: false),
                        PersonId = c.Guid(nullable: false),
                        DetailId = c.Guid(nullable: false),
                        FilmPersonTitleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FilmPersonTitleId)
                .ForeignKey("dbo.Films", t => t.MediaId)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Titles", t => t.DetailId)
                .Index(t => t.MediaId)
                .Index(t => t.PersonId)
                .Index(t => t.DetailId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.ShowPersonTitle",
                c => new
                    {
                        MediaId = c.Guid(nullable: false),
                        PersonId = c.Guid(nullable: false),
                        DetailId = c.Guid(nullable: false),
                        ShowPersonTitleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ShowPersonTitleId)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Shows", t => t.MediaId)
                .ForeignKey("dbo.Titles", t => t.DetailId)
                .Index(t => t.MediaId)
                .Index(t => t.PersonId)
                .Index(t => t.DetailId);
            
            CreateTable(
                "dbo.ListShow",
                c => new
                    {
                        MediaId = c.Guid(nullable: false),
                        ListId = c.Guid(nullable: false),
                        ListShowId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ObsoletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ListShowId)
                .ForeignKey("dbo.List", t => t.ListId, cascadeDelete: true)
                .ForeignKey("dbo.Shows", t => t.MediaId)
                .Index(t => new { t.MediaId, t.ObsoletedOn }, unique: true, name: "IX_ListShow")
                .Index(t => t.ListId);
            
            CreateTable(
                "dbo.List",
                c => new
                    {
                        ListId = c.Guid(nullable: false),
                        Id = c.String(maxLength: 128),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        DateOfCreation = c.DateTime(nullable: false),
                        Shared = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ListId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ListFilm",
                c => new
                    {
                        MediaId = c.Guid(nullable: false),
                        ListId = c.Guid(nullable: false),
                        ListFilmId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ObsoletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ListFilmId)
                .ForeignKey("dbo.Films", t => t.MediaId)
                .ForeignKey("dbo.List", t => t.ListId, cascadeDelete: true)
                .Index(t => new { t.MediaId, t.ObsoletedOn }, unique: true, name: "IX_ListFilm")
                .Index(t => t.ListId);
            
            CreateTable(
                "dbo.ListTag",
                c => new
                    {
                        ListId = c.Guid(nullable: false),
                        DetailId = c.Guid(nullable: false),
                        ListTagId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ListTagId)
                .ForeignKey("dbo.List", t => t.ListId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.DetailId)
                .Index(t => t.ListId)
                .Index(t => t.DetailId);
            
            CreateTable(
                "dbo.FilmTag",
                c => new
                    {
                        MediaId = c.Guid(nullable: false),
                        DetailId = c.Guid(nullable: false),
                        FilmTagId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FilmTagId)
                .ForeignKey("dbo.Films", t => t.MediaId)
                .ForeignKey("dbo.Tags", t => t.DetailId)
                .Index(t => t.MediaId)
                .Index(t => t.DetailId);
            
            CreateTable(
                "dbo.ShowTag",
                c => new
                    {
                        MediaId = c.Guid(nullable: false),
                        DetailId = c.Guid(nullable: false),
                        ShowTagId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ShowTagId)
                .ForeignKey("dbo.Shows", t => t.MediaId)
                .ForeignKey("dbo.Tags", t => t.DetailId)
                .Index(t => t.MediaId)
                .Index(t => t.DetailId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        CreatedOn = c.DateTime(nullable: false),
                        LastLogin = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.Report",
                c => new
                    {
                        ReviewReportedId = c.Guid(nullable: false),
                        ReportId = c.Guid(nullable: false),
                        ReportingUserId = c.String(nullable: false, maxLength: 128),
                        UserReportedId = c.String(nullable: false, maxLength: 128),
                        ReportedOn = c.DateTime(nullable: false),
                        ResolvedOn = c.DateTime(nullable: false),
                        ReportReason = c.Int(nullable: false),
                        ReportStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReportId)
                .ForeignKey("dbo.AspNetUsers", t => t.ReportingUserId)
                .ForeignKey("dbo.Review", t => t.ReviewReportedId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserReportedId)
                .Index(t => t.ReviewReportedId)
                .Index(t => new { t.ReportId, t.ResolvedOn }, unique: true, name: "IX_Report")
                .Index(t => t.ReportingUserId)
                .Index(t => t.UserReportedId);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Guid(nullable: false),
                        Id = c.String(maxLength: 128),
                        Body = c.String(),
                        Shared = c.Boolean(nullable: false),
                        Flagged = c.Boolean(),
                        DateOfCreation = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ReviewFilm",
                c => new
                    {
                        MediaId = c.Guid(nullable: false),
                        ReviewId = c.Guid(nullable: false),
                        ReviewFilmId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ObsoletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ReviewFilmId)
                .ForeignKey("dbo.Films", t => t.MediaId)
                .ForeignKey("dbo.Review", t => t.ReviewId, cascadeDelete: true)
                .Index(t => new { t.MediaId, t.ObsoletedOn }, unique: true, name: "IX_ReviewFilm")
                .Index(t => t.ReviewId);
            
            CreateTable(
                "dbo.ReviewShow",
                c => new
                    {
                        MediaId = c.Guid(nullable: false),
                        ReviewId = c.Guid(nullable: false),
                        ReviewShowId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ObsoletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ReviewShowId)
                .ForeignKey("dbo.Review", t => t.ReviewId, cascadeDelete: true)
                .ForeignKey("dbo.Shows", t => t.MediaId)
                .Index(t => new { t.MediaId, t.ObsoletedOn }, unique: true, name: "IX_ReviewShow")
                .Index(t => t.ReviewId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserFilmRating",
                c => new
                    {
                        Id = c.String(maxLength: 128),
                        MediaId = c.Guid(nullable: false),
                        UserFilmRatingId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ObsoletedOn = c.DateTime(),
                        Rating = c.Int(),
                    })
                .PrimaryKey(t => t.UserFilmRatingId)
                .ForeignKey("dbo.Films", t => t.MediaId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => new { t.Id, t.MediaId, t.ObsoletedOn }, unique: true, name: "IX_UserFilmRating");
            
            CreateTable(
                "dbo.UserFilm",
                c => new
                    {
                        Id = c.String(maxLength: 128),
                        MediaId = c.Guid(nullable: false),
                        UserFilmId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ObsoletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserFilmId)
                .ForeignKey("dbo.Films", t => t.MediaId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => new { t.Id, t.MediaId, t.ObsoletedOn }, unique: true, name: "IX_UserFilm");
            
            CreateTable(
                "dbo.UserShowRating",
                c => new
                    {
                        Id = c.String(maxLength: 128),
                        MediaId = c.Guid(nullable: false),
                        UserShowRatingId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ObsoletedOn = c.DateTime(),
                        Rating = c.Int(),
                    })
                .PrimaryKey(t => t.UserShowRatingId)
                .ForeignKey("dbo.Shows", t => t.MediaId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => new { t.Id, t.MediaId, t.ObsoletedOn }, unique: true, name: "IX_UserShowRating");
            
            CreateTable(
                "dbo.UserShow",
                c => new
                    {
                        Id = c.String(maxLength: 128),
                        MediaId = c.Guid(nullable: false),
                        UserShowId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ObsoletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserShowId)
                .ForeignKey("dbo.Shows", t => t.MediaId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => new { t.Id, t.MediaId, t.ObsoletedOn }, unique: true, name: "IX_UserShow");
            
            CreateTable(
                "dbo.ShowGenre",
                c => new
                    {
                        MediaId = c.Guid(nullable: false),
                        DetailId = c.Guid(nullable: false),
                        ShowGenreId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ShowGenreId)
                .ForeignKey("dbo.Genres", t => t.DetailId)
                .ForeignKey("dbo.Shows", t => t.MediaId)
                .Index(t => t.MediaId)
                .Index(t => t.DetailId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        MediaId = c.Guid(nullable: false),
                        PosterUri = c.String(),
                        MediaName = c.String(nullable: false),
                        DateOfRelease = c.DateTime(nullable: false),
                        Accolades = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ObsoletedOn = c.DateTime(),
                        Runtime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MediaId)
                .Index(t => new { t.MediaId, t.ObsoletedOn }, unique: true, name: "IX_Media");
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        DetailId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ObsoletedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DetailId)
                .Index(t => new { t.DetailId, t.ObsoletedOn }, unique: true, name: "IX_Detail");
            
            CreateTable(
                "dbo.Shows",
                c => new
                    {
                        MediaId = c.Guid(nullable: false),
                        PosterUri = c.String(),
                        MediaName = c.String(nullable: false),
                        DateOfRelease = c.DateTime(nullable: false),
                        Accolades = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ObsoletedOn = c.DateTime(),
                        NumberOfSeasons = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MediaId)
                .Index(t => new { t.MediaId, t.ObsoletedOn }, unique: true, name: "IX_Media");
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        DetailId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ObsoletedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DetailId)
                .Index(t => new { t.DetailId, t.ObsoletedOn }, unique: true, name: "IX_Detail");
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        DetailId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ObsoletedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DetailId)
                .Index(t => new { t.DetailId, t.ObsoletedOn }, unique: true, name: "IX_Detail");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FilmGenre", "DetailId", "dbo.Genres");
            DropForeignKey("dbo.FilmGenre", "MediaId", "dbo.Films");
            DropForeignKey("dbo.FilmPersonTitle", "DetailId", "dbo.Titles");
            DropForeignKey("dbo.FilmPersonTitle", "PersonId", "dbo.Person");
            DropForeignKey("dbo.ShowPersonTitle", "DetailId", "dbo.Titles");
            DropForeignKey("dbo.ShowPersonTitle", "MediaId", "dbo.Shows");
            DropForeignKey("dbo.ShowGenre", "MediaId", "dbo.Shows");
            DropForeignKey("dbo.ShowGenre", "DetailId", "dbo.Genres");
            DropForeignKey("dbo.ListShow", "MediaId", "dbo.Shows");
            DropForeignKey("dbo.ListShow", "ListId", "dbo.List");
            DropForeignKey("dbo.List", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserShow", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserShow", "MediaId", "dbo.Shows");
            DropForeignKey("dbo.UserShowRating", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserShowRating", "MediaId", "dbo.Shows");
            DropForeignKey("dbo.UserFilm", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserFilm", "MediaId", "dbo.Films");
            DropForeignKey("dbo.UserFilmRating", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserFilmRating", "MediaId", "dbo.Films");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Report", "UserReportedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Report", "ReviewReportedId", "dbo.Review");
            DropForeignKey("dbo.Review", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewShow", "MediaId", "dbo.Shows");
            DropForeignKey("dbo.ReviewShow", "ReviewId", "dbo.Review");
            DropForeignKey("dbo.ReviewFilm", "ReviewId", "dbo.Review");
            DropForeignKey("dbo.ReviewFilm", "MediaId", "dbo.Films");
            DropForeignKey("dbo.Report", "ReportingUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ListTag", "DetailId", "dbo.Tags");
            DropForeignKey("dbo.ShowTag", "DetailId", "dbo.Tags");
            DropForeignKey("dbo.ShowTag", "MediaId", "dbo.Shows");
            DropForeignKey("dbo.FilmTag", "DetailId", "dbo.Tags");
            DropForeignKey("dbo.FilmTag", "MediaId", "dbo.Films");
            DropForeignKey("dbo.ListTag", "ListId", "dbo.List");
            DropForeignKey("dbo.ListFilm", "ListId", "dbo.List");
            DropForeignKey("dbo.ListFilm", "MediaId", "dbo.Films");
            DropForeignKey("dbo.ShowPersonTitle", "PersonId", "dbo.Person");
            DropForeignKey("dbo.FilmPersonTitle", "MediaId", "dbo.Films");
            DropIndex("dbo.Titles", "IX_Detail");
            DropIndex("dbo.Tags", "IX_Detail");
            DropIndex("dbo.Shows", "IX_Media");
            DropIndex("dbo.Genres", "IX_Detail");
            DropIndex("dbo.Films", "IX_Media");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ShowGenre", new[] { "DetailId" });
            DropIndex("dbo.ShowGenre", new[] { "MediaId" });
            DropIndex("dbo.UserShow", "IX_UserShow");
            DropIndex("dbo.UserShowRating", "IX_UserShowRating");
            DropIndex("dbo.UserFilm", "IX_UserFilm");
            DropIndex("dbo.UserFilmRating", "IX_UserFilmRating");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.ReviewShow", new[] { "ReviewId" });
            DropIndex("dbo.ReviewShow", "IX_ReviewShow");
            DropIndex("dbo.ReviewFilm", new[] { "ReviewId" });
            DropIndex("dbo.ReviewFilm", "IX_ReviewFilm");
            DropIndex("dbo.Review", new[] { "Id" });
            DropIndex("dbo.Report", new[] { "UserReportedId" });
            DropIndex("dbo.Report", new[] { "ReportingUserId" });
            DropIndex("dbo.Report", "IX_Report");
            DropIndex("dbo.Report", new[] { "ReviewReportedId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ShowTag", new[] { "DetailId" });
            DropIndex("dbo.ShowTag", new[] { "MediaId" });
            DropIndex("dbo.FilmTag", new[] { "DetailId" });
            DropIndex("dbo.FilmTag", new[] { "MediaId" });
            DropIndex("dbo.ListTag", new[] { "DetailId" });
            DropIndex("dbo.ListTag", new[] { "ListId" });
            DropIndex("dbo.ListFilm", new[] { "ListId" });
            DropIndex("dbo.ListFilm", "IX_ListFilm");
            DropIndex("dbo.List", new[] { "Id" });
            DropIndex("dbo.ListShow", new[] { "ListId" });
            DropIndex("dbo.ListShow", "IX_ListShow");
            DropIndex("dbo.ShowPersonTitle", new[] { "DetailId" });
            DropIndex("dbo.ShowPersonTitle", new[] { "PersonId" });
            DropIndex("dbo.ShowPersonTitle", new[] { "MediaId" });
            DropIndex("dbo.FilmPersonTitle", new[] { "DetailId" });
            DropIndex("dbo.FilmPersonTitle", new[] { "PersonId" });
            DropIndex("dbo.FilmPersonTitle", new[] { "MediaId" });
            DropIndex("dbo.FilmGenre", new[] { "DetailId" });
            DropIndex("dbo.FilmGenre", new[] { "MediaId" });
            DropTable("dbo.Titles");
            DropTable("dbo.Tags");
            DropTable("dbo.Shows");
            DropTable("dbo.Genres");
            DropTable("dbo.Films");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ShowGenre");
            DropTable("dbo.UserShow");
            DropTable("dbo.UserShowRating");
            DropTable("dbo.UserFilm");
            DropTable("dbo.UserFilmRating");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.ReviewShow");
            DropTable("dbo.ReviewFilm");
            DropTable("dbo.Review");
            DropTable("dbo.Report");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ShowTag");
            DropTable("dbo.FilmTag");
            DropTable("dbo.ListTag");
            DropTable("dbo.ListFilm");
            DropTable("dbo.List");
            DropTable("dbo.ListShow");
            DropTable("dbo.ShowPersonTitle");
            DropTable("dbo.Person");
            DropTable("dbo.FilmPersonTitle");
            DropTable("dbo.FilmGenre");
        }
    }
}
