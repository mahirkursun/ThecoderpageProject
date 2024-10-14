using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Application.Services.AbstractServices;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;

namespace ThecoderpageProject.Application.Services.ConcreteManagers
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentRepository<Comment> _commentRepository;
        private readonly IMapper _mapper;

        public CommentManager(ICommentRepository<Comment> commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateCommentDTO model)
        {
            var comment = _mapper.Map<Comment>(model);
            await _commentRepository.CreateComment(comment);
        }
        public async Task Update(UpdateCommentDTO commentDTO)
        {
            var comment = await _commentRepository.GetCommentById(commentDTO.Id);
            if (comment == null)
            {
                throw new KeyNotFoundException($"Comment with ID {commentDTO.Id} not found.");
            }
            comment.Content = commentDTO.Content;
            comment.CreatedAt = commentDTO.CreatedAt;
            comment.UserId = commentDTO.UserId;
            comment.ProblemId = commentDTO.ProblemId;
            await _commentRepository.UpdateComment(comment);
        }

        public async Task Delete(int id)
        {
            var comment = await _commentRepository.GetCommentById(id);
            if (comment != null)
            {
                await _commentRepository.DeleteComment(comment.Id);
            }
            else
            {
                throw new KeyNotFoundException($"Comment with ID {id} not found.");
            }
        }
        public async Task<UpdateCommentDTO> GetCommentById(int id)
        {
            var comment = await _commentRepository.GetCommentById(id);
            if (comment == null)
            {
                throw new KeyNotFoundException($"Comment with ID {id} not found.");
            }
            return _mapper.Map<UpdateCommentDTO>(comment);
        }

        public async Task<IEnumerable<CommentVM>> GetAll()
        {
            var comments = await _commentRepository.GetComments();
            return _mapper.Map<IEnumerable<CommentVM>>(comments);
        }

        public Task<IEnumerable<CommentVM>> GetCommentsByProblemId(int problemId)
        {
            var comments = _commentRepository.GetComments().Result
           .Where(p => p.ProblemId == problemId);

            return Task.FromResult(_mapper.Map<IEnumerable<CommentVM>>(comments));



        }
    }
}
