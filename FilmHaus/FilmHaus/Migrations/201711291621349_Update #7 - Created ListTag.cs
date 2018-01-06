namespace FilmHaus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update7CreatedListTag : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.FilmGenre", newName: "FilmGenres");
            RenameTable(name: "dbo.FilmPersonTitle", newName: "FilmPersonTitles");
            RenameTable(name: "dbo.ShowPersonTitle", newName: "ShowPersonTitles");
            RenameTable(name: "dbo.ListShow", newName: "ListShows");
            RenameTable(name: "dbo.ListFilm", newName: "ListFilms");
            RenameTable(name: "dbo.Report", newName: "Reports");
            RenameTable(name: "dbo.ReviewFilm", newName: "ReviewFilms");
            RenameTable(name: "dbo.ReviewShow", newName: "ReviewShows");
            RenameTable(name: "dbo.UserFilmRating", newName: "UserFilmRatings");
            RenameTable(name: "dbo.UserFilm", newName: "UserFilms");
            RenameTable(name: "dbo.UserShowRating", newName: "UserShowRatings");
            RenameTable(name: "dbo.UserShow", newName: "UserShows");
            RenameTable(name: "dbo.ShowGenre", newName: "ShowGenres");
            RenameTable(name: "dbo.ShowTag", newName: "ShowTags");
            RenameTable(name: "dbo.FilmTag", newName: "FilmTags");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.FilmTags", newName: "FilmTag");
            RenameTable(name: "dbo.ShowTags", newName: "ShowTag");
            RenameTable(name: "dbo.ShowGenres", newName: "ShowGenre");
            RenameTable(name: "dbo.UserShows", newName: "UserShow");
            RenameTable(name: "dbo.UserShowRatings", newName: "UserShowRating");
            RenameTable(name: "dbo.UserFilms", newName: "UserFilm");
            RenameTable(name: "dbo.UserFilmRatings", newName: "UserFilmRating");
            RenameTable(name: "dbo.ReviewShows", newName: "ReviewShow");
            RenameTable(name: "dbo.ReviewFilms", newName: "ReviewFilm");
            RenameTable(name: "dbo.Reports", newName: "Report");
            RenameTable(name: "dbo.ListFilms", newName: "ListFilm");
            RenameTable(name: "dbo.ListShows", newName: "ListShow");
            RenameTable(name: "dbo.ShowPersonTitles", newName: "ShowPersonTitle");
            RenameTable(name: "dbo.FilmPersonTitles", newName: "FilmPersonTitle");
            RenameTable(name: "dbo.FilmGenres", newName: "FilmGenre");
        }
    }
}
