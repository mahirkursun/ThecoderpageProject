using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Domain.Entities;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Application.Models.DTOs
{
    public class CreateProblemDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Başlık girilmesi zorunludur.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Açıklama girilmesi zorunludur.")]
        [StringLength(500, MinimumLength = 3)]
        public string Description { get; set; }
        public ProblemStatus Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UserId { get; set; }

        [Required(ErrorMessage ="Bir kategori seçilmesi zorunludur.")]
        public int CategoryId { get; set; }

        public List<LikeVM> Likes { get; set; } = new List<LikeVM>();
        public List<CategoryVM> Categories { get; set; }

    }
}