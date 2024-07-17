using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using azureproductapp.contexts;
using azureproductapp.Interfaces;
using azureproductapp.Models;
using azureproductapp.Repositories;
using azureproductapp.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace azureproductapp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var vaultUrl = "https://dvsujanvault.vault.azure.net/";

            var client = new SecretClient(vaultUri: new Uri(vaultUrl), credential: new DefaultAzureCredential());

            KeyVaultSecret secret = await  client.GetSecretAsync("sql-connection-string");

            string connectionString = secret.Value;

            builder.Services.AddDbContext<ProductContext>(options =>
            {
                options.UseSqlServer(connectionString);

            }); 

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IRepo<int , Product>, ProductRepository>(); 
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddControllers();
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
