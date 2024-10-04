using System;
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
        public int UserId { get; set; }
        public ProblemStatus Status { get; set; }
        public int CategoryId { get; set; }



        // Navigation property

        public virtual ICollection<Comment> Comments { get; set; }


        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
    }
}
