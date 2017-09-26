using FilmHaus.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmHaus.Models.View
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Locale))]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        [DataType(DataType.Url)]
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }

        [DataType(DataType.Url)]
        public string ReturnUrl { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Locale))]
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code", ResourceType = typeof(Locale))]
        public string Code { get; set; }

        [DataType(DataType.Url)]
        public string ReturnUrl { get; set; }

        [Display(Name = "RememberBrowser", ResourceType = typeof(Locale))]
        public bool RememberBrowser { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Locale))]
        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(Locale))]
        public string Email { get; set; }
    }

    public class UserLoginViewModel
    {
        public UserLoginViewModel()
        {
        }

        public UserLoginViewModel(UserLoginViewModel model)
        {
            Email = model.Email;
            Password = model.Password;
            RememberMe = model.RememberMe;
        }

        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Locale))]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Locale))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Locale))]
        public bool RememberMe { get; set; }
    }

    public class UserRegisterViewModel
    {
        public UserRegisterViewModel()
        {
        }

        public UserRegisterViewModel(UserRegisterViewModel model)
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            Email = model.Email;
        }

        [Required]
        [Display(Name = "FirstName", ResourceType = typeof(Locale))]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName", ResourceType = typeof(Locale))]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Locale))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Locale))]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Locale))]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Locale))]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Locale))]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Locale))]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Code", ResourceType = typeof(Locale))]
        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Locale))]
        public string Email { get; set; }
    }
}