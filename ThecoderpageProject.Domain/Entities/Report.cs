using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Domain.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public ReportReason ReportReason { get; set; }
        public DateTime ReportedAt { get; set; }= DateTime.Now;

        public string UserId { get; set; }


        public int? ProblemId { get; set; }
        public int? CommentId { get; set; }

        // Navigation property

        public virtual Problem Problem { get; set; }
        public virtual AppUser User { get; set; }
        public virtual Comment Comment { get; set; }


    }
}
