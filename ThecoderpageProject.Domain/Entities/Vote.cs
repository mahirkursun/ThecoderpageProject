using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Domain.Entities
{
    public class Vote
    {
        public int Id { get; set; }
        public bool IsUpvote { get; set; }
        public VoteType VoteType { get; set; }
        public DateTime VotedAt { get; set; }
 
        public int UserId { get; set; }

        public int ProblemId { get; set; }


        public int CommentId { get; set; }
    
    }
}
