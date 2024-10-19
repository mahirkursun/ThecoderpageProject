using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThecoderpageProject.Domain.Entities
{
    public class Like
    {
        public int Id { get; set; }
        public int ProblemId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Problem Problem { get; set; }
        public virtual AppUser User { get; set; }
    }

}
