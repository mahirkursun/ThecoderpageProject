using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;
        private readonly IMapper _mapper;

        public LikeController(ILikeService likeService, IMapper mapper)
        {
            _likeService = likeService;
            _mapper = mapper;
        }

        [HttpGet("{problemId}")]
        public async Task<IActionResult> GetLike(int problemId)
        {
            var like = await _likeService.GetLikeByProblemId(problemId);
            if (like == null)
            {
                return NotFound();
            }
            return Ok(like);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLike([FromBody] CreateLikeDTO createLikeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _likeService.CreateLike(createLikeDTO);
            return CreatedAtAction(nameof(GetLike), new { problemId = createLikeDTO.ProblemId }, createLikeDTO);
        }

        [HttpPut("{problemId}")]
        public async Task<IActionResult> UpdateLike(int problemId, [FromBody] UpdateLikeDTO updateLikeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var like = await _likeService.GetLikeByProblemId(problemId);
            if (like == null)
            {
                return NotFound();
            }
            await _likeService.UpdateLike(updateLikeDTO);
            return NoContent();
        }

        [HttpDelete("{problemId}")]
        public async Task<IActionResult> DeleteLike(int problemId)
        {
            var like = await _likeService.GetLikeByProblemId(problemId);
            if (like == null)
            {
                return NotFound();
            }
            await _likeService.DeleteLike(problemId);
            return NoContent();
        }
    }
}
