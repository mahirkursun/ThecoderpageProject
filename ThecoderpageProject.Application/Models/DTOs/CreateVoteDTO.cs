using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Application.Models.DTOs
{
    public class CreateVoteDTO 
    {
        public int Id { get; set; }
        public int ProblemId { get; set; }
        public int UserId { get; set; }

        public VoteType voteType { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
