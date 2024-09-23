using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Application.AutoMapper;
using ThecoderpageProject.Application.Services.AbstractServices;
using ThecoderpageProject.Application.Services.ConcreteManagers;

namespace ThecoderpageProject.Application.IoC
{
    public static class DependencyResolver
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Mapping));

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IProblemService, ProblemManager>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IVoteService, VoteManager>();



        }
    }
}
