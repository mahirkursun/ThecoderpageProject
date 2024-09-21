using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThecoderpageProject.Domain.Entities
{
    public class Vote
    {
        public int Id { get; set; }
        public bool IsUpvote { get; set; }
        public DateTime VotedAt { get; set; }
 
        public int UserId { get; set; }
        public User User { get; set; }

        public int ProblemId { get; set; }
        public Problem Problem { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
