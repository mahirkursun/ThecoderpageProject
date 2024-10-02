using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Application.Models.VMs
{
    public class VoteVM
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ProblemId { get; set; }
        public VoteType VoteType { get; set; }  
    }
}
