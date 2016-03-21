using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DCCScore.MVC.Models
{
    
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Lembrar senha?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {

        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }
        
        [Display(Name = "Curso")]
        public ICollection<string> Curso { get; set; }

        [Required]
        public int IdCurso { get; set; }

        [Required]
        public bool Matriculado { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }
    }
}
