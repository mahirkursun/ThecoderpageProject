using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThecoderpageProject.Application.Models.DTOs
{
    public class CreateCommentDTO
    {
        [Required]
        [StringLength(600, MinimumLength = 3)]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int ProblemId { get; set; }
        public int UserId { get; set; }
    }
}
