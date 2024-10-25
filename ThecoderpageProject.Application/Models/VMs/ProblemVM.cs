using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Application.Models.VMs
{
    public class ProblemVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        public int CategoryId { get; set; }
        public string Name { get; set; }//CategoryName
        public ProblemStatus Status { get; set; }

        

        public List<UserVM> Users { get; set; }
        public List<CategoryVM> Categories { get; set; }
        public List<CommentVM> Comments { get; set; }

        public List<LikeVM> Likes { get; set; } = new List<LikeVM>();

    }
}
