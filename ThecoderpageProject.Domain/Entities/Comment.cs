using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThecoderpageProject.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign key to AppUser
        public string UserId { get; set; }

        // Foreign key to Problem
        public int ProblemId { get; set; }

        // Navigation properties
        public virtual Problem Problem { get; set; }
        public virtual AppUser User { get; set; }


    }
}
