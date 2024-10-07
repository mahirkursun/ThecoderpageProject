using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Application.Models.VMs
{
    public class CreateProblemVM
    {
        
        public string Title { get; set; }
        public string Description { get; set; }

        public ProblemStatus Status { get; set; }
        public string UserId { get; set; }
        public int CategoryId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public VoteType? UserVoteType { get; set; }
    }
}
