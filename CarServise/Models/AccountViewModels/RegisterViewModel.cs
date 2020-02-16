using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarServise.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "CompanyName")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "OkpoName")]
        [StringLength(100, ErrorMessage = "The {0} must be at max {1} characters long.")]
        public string OkpoName { get; set; }

        [Required]
        [Display(Name = "PhoneNumber")]
        [StringLength(11, ErrorMessage = "Номер должен содежать одиннадцать цифер", MinimumLength =11)]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Sity")]
        public string Sity { get; set; }

        [Required]
        [Display(Name = "FIO")]
        public string FIO { get; set; }
        //-----------------------

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
