using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;

namespace ThecoderpageProject.MVC.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;

        }

        string uri = "https://localhost:7244";

        // Admin/Comment/Index
        public async Task<IActionResult> Index()
        {
            var comments = await _commentService.GetAll();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{uri}/api/Comment"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    comments = JsonConvert.DeserializeObject<List<CommentVM>>(apiResponse);
                }
            }
            return View(comments);
        }

        public IActionResult Create()
        {

            return View();
        }


        


        
    }
}
