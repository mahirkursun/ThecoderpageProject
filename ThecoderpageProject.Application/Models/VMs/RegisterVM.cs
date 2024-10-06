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
        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim alanı zorunludur.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı alanı zorunludur.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçersiz email formatı.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Şifre en az 6 en fazla 30 karakter olmalıdır.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }

        public UserRole Role { get; set; } = UserRole.User; // Varsayılan rol
    }
}
