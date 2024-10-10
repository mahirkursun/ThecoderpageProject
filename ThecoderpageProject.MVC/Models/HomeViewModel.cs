using ThecoderpageProject.Application.Models.VMs;

namespace ThecoderpageProject.MVC.Models
{
    public class HomeViewModel
    {
        public IEnumerable<CategoryVM> Categories { get; set; }
        public IEnumerable<ProblemVM> Problems { get; set; }
    }
}
