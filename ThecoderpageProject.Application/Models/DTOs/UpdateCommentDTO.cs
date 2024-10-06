using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Application.Models.DTOs
{
    public class UpdateCommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public string UserId { get; set; }
        public int ProblemId { get; set; }
        public DateTime CreatedAt { get; set; }



    }
}
