using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Application.Models.VMs
{
    public class LikeVM
    {
        public int Id { get; set; }
        public int ProblemId { get; set; }
        public string UserId { get; set; }
        public int LikeCount { get; set; }
    }
}
