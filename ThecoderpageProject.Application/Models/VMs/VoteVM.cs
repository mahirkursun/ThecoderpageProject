using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThecoderpageProject.Application.Models.VMs
{
    public class VoteVM
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ProblemId { get; set; }
        public bool IsUpVote { get; set; }
        public bool IsDownVote { get; set; }
    }
}
