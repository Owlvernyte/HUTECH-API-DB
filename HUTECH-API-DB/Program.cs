using HUTECH_API_DB.Models;
using Microsoft.EntityFrameworkCore;

namespace HUTECH_API_DB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddDbContext<HutechAPI>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HUTECHAPI")));
            builder.Services.AddDbContext<HutechAPI>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("HUTECHPostgresql")));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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