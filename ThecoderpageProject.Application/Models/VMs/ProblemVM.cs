using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Application.Models.VMs
{
    public class ProblemVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }

        public int CategoryId { get; set; }
        public ProblemStatus Status { get; set; }

        // Kullanıcıya ait **UpVote** ve **DownVote** sayıları
        public VoteType? UserVoteType { get; set; }
    }
}
