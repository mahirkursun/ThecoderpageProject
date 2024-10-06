using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Application.Models.DTOs
{
    public class CreateReportDTO
    {
        public int Id { get; set; }
        [Required]
        public ReportReason ReportReason { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string UserId { get; set; }
        public int? ProblemId { get; set; }
        public int? CommentId { get; set; }
    }
}
