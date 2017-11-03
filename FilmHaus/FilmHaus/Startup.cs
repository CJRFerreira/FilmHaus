using FilmHaus.Models;
using FilmHaus.Models.Base;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(FilmHaus.Startup))]

namespace FilmHaus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
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

                var admin = new User
                {
                    FirstName = "Christian",
                    LastName = "Ferreira",
                    Email = "christian.ferreira@mohawkcollege.ca",
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };
                string adminPassword = "Mohawk_123";

                var userCheck = userManager.Create(admin, adminPassword);
                if (userCheck.Succeeded)
                {
                    var result = userManager.AddToRole(admin.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Moderator"))
            {
                var role = new IdentityRole();
                role.Name = "Moderator";
                roleManager.Create(role);

                var mod = new User
                {
                    FirstName = "Bob",
                    LastName = "Burger",
                    Email = "bob.burger@bobsburgers.com",
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };
                string modPassword = "Mohawk_123";

                var userCheck = userManager.Create(mod, modPassword);
                if (userCheck.Succeeded)
                {
                    userManager.AddToRole(mod.Id, "Moderator");
                }
            }

            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

                var user = new User
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@realemail.co.uk",
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };
                string userPassword = "Mohawk_123";

                var userCheck = userManager.Create(user, userPassword);
                if (userCheck.Succeeded)
                {
                    userManager.AddToRole(user.Id, "User");
                }
            }
        }
    }
}