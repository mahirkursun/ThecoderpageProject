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
            
            CreateMap<CreateUserDTO, AppUser>().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<AppUser,  UpdateUserDTO>();
            CreateMap<AppUser, UserVM>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));


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
