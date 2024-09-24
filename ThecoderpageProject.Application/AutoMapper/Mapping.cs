using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;
using ThecoderpageProject.Domain.Entities;
using ThecoderpageProject.Domain.Enums;

namespace ThecoderpageProject.Application.AutoMapper
{
    public class Mapping : Profile
    {
        // Buraya tüm mapping işlemleri yazılacak

        public Mapping()
        {
            CreateMap<User, CreateUserDTO>();
            CreateMap<CreateUserDTO, User>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => Enum.Parse<UserRole>(src.Role.ToString()))); // Enum dönüşümü
            CreateMap<User,  UpdateUserDTO>();
            CreateMap<User, UserVM>();

            CreateMap<Category, CreateCategoryDTO>();
            CreateMap<Category, UpdateCategoryDTO>();
            CreateMap<Category, CategoryVM>();

            CreateMap<Comment, CreateCommentDTO>();
            CreateMap<Comment, CommentVM>();

            CreateMap<Problem, CreateProblemDTO>();
            CreateMap<Problem, ProblemVM>();

            CreateMap<Report, CreateReportDTO>();
            CreateMap<Report, ReportVM>();

            CreateMap<Vote, CreateVoteDTO>();
            CreateMap<Vote, VoteVM>();
        }

    }
}
