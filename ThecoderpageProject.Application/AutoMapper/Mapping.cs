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
            
            CreateMap<CreateUserDTO, User>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => Enum.Parse<UserRole>(src.Role.ToString()))); // Enum dönüşümü
            CreateMap<User,  UpdateUserDTO>();
            CreateMap<User, UserVM>();

            
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<Category, UpdateCategoryDTO>();
            CreateMap<Category, CategoryVM>();

            CreateMap<CreateCommentDTO, Comment>();
            CreateMap<Comment, UpdateCommentDTO>();
            CreateMap<Comment, CommentVM>();

           
            CreateMap<CreateProblemDTO, Problem>();
            CreateMap<Problem, UpdateProblemDTO>();
            CreateMap<Problem, ProblemVM>();

            CreateMap<CreateReportDTO, Report>();
            CreateMap<Report, UpdateReportDTO>();
            CreateMap<Report, ReportVM>();


            CreateMap<CreateVoteDTO, Vote>();
            CreateMap<Vote, VoteVM>();
        }

    }
}
