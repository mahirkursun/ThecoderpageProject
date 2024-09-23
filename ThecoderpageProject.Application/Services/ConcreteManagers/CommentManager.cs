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

        public async Task<IEnumerable<CommentVM>> GetAll()
        {
            var comments = await _commentRepository.GetComments(); 
            return _mapper.Map<IEnumerable<CommentVM>>(comments);
        }
    }
}
