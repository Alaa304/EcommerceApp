using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using Presistance.Data;
using Presistance.Data.DataSeed;
using Presistance.Repositories;
using Service;
using ServiceAbstraction;

namespace EcommercApp
{
    public class Program
    {
        public  static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            #region Configure Services
            builder.Services.AddDbContext<StoreDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IDataSeeding, DataSeeding>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(X=>X.AddProfile(new MappingProfiles()));
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddTransient<PictureUrlResolver>();
            #endregion

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            #region Data Seeding
            using var scope = app.Services.CreateScope();
            var objectData = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await objectData.DataSeedAsync();
            #endregion

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
          
            app.UseAuthorization();
            app.UseStaticFiles(); // ضروري قبل app.MapControllers()
            app.MapControllers();

            app.Run();
        }
    }
}
