﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Application.Models.VMs
{
    public class UpdateProblemVM
    {
        
        public string Title { get; set; }
        public string Description { get; set; }

        public ProblemStatus Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public int CategoryId { get; set; }

        public List<LikeVM> Likes { get; set; } = new List<LikeVM>();
    }
}
