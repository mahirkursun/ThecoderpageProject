using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

       
        public UserRole Role { get; set; }

        // Navigation properties
        public virtual ICollection<Problem> Problems { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }

}