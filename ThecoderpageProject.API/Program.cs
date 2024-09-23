
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ThecoderpageProject.Application.IoC;
using ThecoderpageProject.Domain.AbstractRepositories;
using ThecoderpageProject.Domain.Entities;
using ThecoderpageProject.Infrastructure.ConcreteRepositories;
using ThecoderpageProject.Infrastructure.Context;

namespace ThecoderpageProject.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            //Identity Configuration burada yapýlacak.
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            //Autofac için.
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new DependencyResolver());
            }); //IoC klasöründeki DependencyResolver sýnýfý burada configurasyon olarak algýlasýn istediðimiz için.


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
