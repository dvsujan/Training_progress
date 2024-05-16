
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PizzaShopApi.contexts;
using PizzaShopApi.Interfaces;
using PizzaShopApi.Models;
using PizzaShopApi.Repositories;
using PizzaShopApi.services;
using System.Text;

namespace PizzaShopApi
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
            
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                   {
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey:JWT"]))
                   };
               });

            #region DBContext
            builder.Services.AddDbContext<PizzaShopContext>(options =>
            {
                options.UseSqlServer("Data Source=794GBX3\\INSTANCE_1;Integrated Security=true;Initial Catalog=PizzaShop;TrustServerCertificate=True");
            });
            #endregion

            #region Repositories
            builder.Services.AddScoped<IRepo<int, Pizza>, PizzaRepository>();
            builder.Services.AddScoped<IRepo<int, User>, UserRepository>();
            #endregion

            #region Services
            builder.Services.AddScoped<IPizzaService, PizzaBl>();
            builder.Services.AddScoped<IUserService, UserBl>();
            builder.Services.AddScoped<ITokenService, TokenService>(); 
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication(); 
            app.UseAuthorization();
            
            app.MapControllers();

            app.Run();
        }
    }
}
