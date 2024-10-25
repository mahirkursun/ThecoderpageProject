using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Application.Models.VMs
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "First name field is required.")] 
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name field is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username field is required.")]
        public string UserName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field is required.")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password must be at least 6 and at most 30 characters.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match.")] 
        public string ConfirmPassword { get; set; }

        public UserRole Role { get; set; } = UserRole.User; // Varsayılan rol
    }
}
