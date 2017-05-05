using FilmHaus.Models.Base;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilmHaus.Startup))]

namespace FilmHaus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            FilmHausDbContext context = new FilmHausDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<User>(new UserStore<User>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Moderator"))
            {
                var role = new IdentityRole();
                role.Name = "Moderator";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }
        }
    }
}