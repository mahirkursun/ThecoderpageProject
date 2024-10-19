using Autofac;
using AutoMapper;
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
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<ProblemManager>().As<IProblemService>();
            builder.RegisterType<CommentManager>().As<ICommentService>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<ReportManager>().As<IReportService>();
            builder.RegisterType<LikeManager>().As<ILikeService>();

            builder.Register(context => new  MapperConfiguration(config =>
            {
                config.AddProfile<Mapping>(); 
            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();

                return config.CreateMapper(context.Resolve);
            }).As<IMapper>().InstancePerLifetimeScope();
        }
       
    }
}
