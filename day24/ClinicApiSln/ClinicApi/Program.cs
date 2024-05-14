
using ClinicApi.contexts;
using ClinicApi.Interfaces;
using ClinicApi.Models;
using ClinicApi.Repositories;
using ClinicApi.Services;
using Microsoft.EntityFrameworkCore;

namespace ClinicApi
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
            
            builder.Services.AddDbContext<ClinicAppContext>(options =>
            {
                options.UseSqlServer("Data Source=794GBX3\\INSTANCE_1;Integrated Security=true;Initial Catalog=ClinicApp;TrustServerCertificate=True");
            });

            builder.Services.AddScoped<IRepo<int, Doctor>, DoctorRepository>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            
            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            
            app.MapControllers();

            app.Run();
        }
    }
}
