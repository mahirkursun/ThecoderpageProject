using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Application.Models.VMs
{
    public class ReportVM
    {
        public int Id { get; set; }
        public ReportReason ReportReason { get; set; }
        public DateTime ReportedAt { get; set; }

        public string UserId { get; set; }
        
        public int? ProblemId { get; set; }
    }
}
