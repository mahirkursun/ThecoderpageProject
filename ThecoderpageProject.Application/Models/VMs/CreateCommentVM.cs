﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThecoderpageProject.Application.Models.VMs
{
    public class CreateCommentVM
    {
        [Required]
        [StringLength(600, MinimumLength = 3)]
        public string Content { get; set; }

        public int UserId { get; set; }
        public int ProblemId { get; set; }
    }
}
