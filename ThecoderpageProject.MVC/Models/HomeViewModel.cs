using ThecoderpageProject.Application.Models.VMs;

namespace ThecoderpageProject.MVC.Models
{
    public class HomeViewModel
    {

        public IEnumerable<CategoryVM> Categories { get; set; } = new List<CategoryVM>();
        public IEnumerable<ProblemVM> Problems { get; set; } = new List<ProblemVM>();

        public IEnumerable<CommentVM> Comments { get; set; } = new List<CommentVM>();
        public IEnumerable<UserVM> Users { get; set; } = new List<UserVM>();



    }
}
