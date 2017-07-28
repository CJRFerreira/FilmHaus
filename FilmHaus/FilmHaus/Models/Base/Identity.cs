using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FilmHaus.Localization;
using FilmHaus.Models.Connector;

namespace FilmHaus.Models.Base
{
    // You can add profile data for the user by adding more properties to your User class, please
    // visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "FirstName", ResourceType = typeof(Locale))]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "LastName", ResourceType = typeof(Locale))]
        public string LastName { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Locale))]
        [NotMapped]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        [DataType(DataType.Date)]
        [Display(Name = "CreatedOn", ResourceType = typeof(Locale))]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "LastLogin", ResourceType = typeof(Locale))]
        public DateTime LastLogin { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class FilmHausDbContext : IdentityDbContext<User>
    {
        public FilmHausDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static FilmHausDbContext Create()
        {
            return new FilmHausDbContext();
        }

        public DbSet<Film> Films { get; set; }

        public DbSet<UserFilm> UserFilms { get; set; }

        public DbSet<List> Lists { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Report> Reports { get; set; }
    }
}