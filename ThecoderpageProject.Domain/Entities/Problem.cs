﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Domain.Entities
{
    public class Problem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign key to AppUser
        public string UserId { get; set; }

        public ProblemStatus Status { get; set; }
        public int CategoryId { get; set; }


        // Navigation properties
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual AppUser User { get; set; } // Referencing AppUser
        public virtual Category Category { get; set; }
    }
}
