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
        public string Reason { get; set; }
        public ReportReason ReportReason { get; set; }
        public DateTime ReportedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ProblemId { get; set; }
        public Problem Problem { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }


    }
}
