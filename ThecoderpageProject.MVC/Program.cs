
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ThecoderpageProject.Application.AutoMapper;
using ThecoderpageProject.Application.IoC;
using ThecoderpageProject.Application.Services.AbstractServices;
using ThecoderpageProject.Application.Services.ConcreteManagers;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;
using ThecoderpageProject.Infrastructure.ConcreteRepositories;
using ThecoderpageProject.Infrastructure.Context;

namespace ThecoderpageProject.MVC
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


            
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //Identity Configuration burada yapýlacak.
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            //Autofac için.
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new DependencyResolver());
               
            }); //IoC klasöründeki DependencyResolver sýnýfý burada configurasyon olarak algýlasýn istediðimiz için.

            //ConfigureServices:

            builder.Services.AddScoped<IUserService, UserManager>();
            builder.Services.AddScoped<IProblemService, ProblemManager>();
            builder.Services.AddScoped<ICommentService, CommentManager>();
            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            builder.Services.AddScoped<IReportService, ReportManager>();
            builder.Services.AddScoped<IVoteService, VoteManager>();

            builder.Services.AddScoped<IUserRepository<User>, UserRepository>();
            builder.Services.AddScoped<IProblemRepository<Problem>, ProblemRepository>();
            builder.Services.AddScoped<ICommentRepository<Comment>, CommentRepository>();
            builder.Services.AddScoped<ICategoryRepository<Category>, CategoryRepository>();
            builder.Services.AddScoped<IReportRepository<Report>, ReportRepository>();
            builder.Services.AddScoped<IVoteRepository<Vote>, VoteRepository>();
          



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); //Ekledik.
            app.UseAuthorization();


            app.MapControllerRoute(
               name: "areas",
               pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


            ////default area en altta
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
