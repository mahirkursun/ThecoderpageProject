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
    public class LikeManager : ILikeService
    {
        private readonly ILikeRepository<Like> _likeRepository;
        private readonly IMapper _mapper;

        public LikeManager(ILikeRepository<Like> likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }
        public Task CreateLike(CreateLikeDTO model)
        {
            var like = _mapper.Map<Like>(model);
            return _likeRepository.AddLike(like);

        }

        public Task DeleteLike(int problemId)
        {
            var like = _likeRepository.GetLikesByProblemId(problemId);
            return _likeRepository.RemoveLike(like.Id);

        }

        public async Task<IEnumerable<LikeVM>> GetAllLikes()
        {
            var likes =await _likeRepository.GetAllLikes();
            return _mapper.Map<IEnumerable<LikeVM>>(likes);
        }

        public async Task<IEnumerable<LikeVM>> GetLikeByProblemId(int problemId)
        {
            var likes =await _likeRepository.GetLikesByProblemId(problemId);
            return _mapper.Map<IEnumerable<LikeVM>>(likes);
        }

        public Task UpdateLike(UpdateLikeDTO model)
        {
            var like = _mapper.Map<Like>(model);
            return _likeRepository.UpdateLike(like);
        }

    }
}
