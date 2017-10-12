﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FilmHaus.Localization;

namespace FilmHaus.Models.Base
{
    // You can add profile data for the user by adding more properties to your User class, please
    // visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastLogin { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}