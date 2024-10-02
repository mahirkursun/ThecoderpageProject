using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Entities;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Application.Models.DTOs
{
    public class CreateProblemDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 3)]
        public string Description { get; set; }
        public ProblemStatus Status { get; set; }
  

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public int CategoryId { get; set; }

    }
}
