using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.MVC.Models
{
    public class HomeViewModel
    {

        public IEnumerable<CategoryVM> Categories { get; set; } = new List<CategoryVM>();
        public IEnumerable<ProblemVM> Problems { get; set; } = new List<ProblemVM>();

        public IEnumerable<CommentVM> Comments { get; set; } = new List<CommentVM>();
        public IEnumerable<UserVM> Users { get; set; } = new List<UserVM>();

        public IEnumerable<ReportVM> Reports { get; set; } = new List<ReportVM>();

        public IEnumerable<LikeVM> Likes { get; set; } = new List<LikeVM>();

        //CreateReportDTO çağrıldığında burada bir nesne oluşturulacak
        public ReportReason ReportReason { get; set; }

    }
}
