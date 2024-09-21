using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThecoderpageProject.Application.Models.VMs
{
    public class CreateProblemVM
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3)]
        public string Description { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
