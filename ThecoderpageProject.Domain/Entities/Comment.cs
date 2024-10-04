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


        public int UserId { get; set; }
        public int ProblemId { get; set; }

        // Navigation property

        public virtual Problem Problem { get; set; }
        public virtual User User { get; set; }


    }
}
