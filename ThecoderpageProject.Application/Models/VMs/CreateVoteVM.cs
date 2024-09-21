using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThecoderpageProject.Application.Models.VMs
{
    public class CreateVoteVM
    {
        public string UserId { get; set; }
        public int ProblemId { get; set; }
        //public int CommentId { get; set; } // Belki yorumlara beğeni özelliği eklenir.
        public bool IsUpVote { get; set; }
    }
}
