﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Application.Models.DTOs
{
    public class UpdateProblemDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ProblemStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
        public int CategoryId { get; set; }

        public VoteType? UserVoteTypeVoteType { get; set; }

        public IEnumerable<CommentVM> Comments { get; set; } = new List<CommentVM>();
        public IEnumerable<UserVM> Users { get; set; } = new List<UserVM>();

        public IEnumerable<ReportVM> Reports { get; set; } = new List<ReportVM>();
        public ReportReason ReportReason { get; set; }

    }
}
