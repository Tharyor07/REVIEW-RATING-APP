

using Microsoft.EntityFrameworkCore;
using repository_pattern.Data;
using repository_pattern.Services;

namespace repository_pattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<ITeacher, TeacherService>();
            builder.Services.AddScoped<IStudent, StudentService>();

            string connectivity = builder.Configuration.GetConnectionString("DataConnection");
            builder.Services.AddDbContext<DataContext>(options => options.UseMySql(connectivity,ServerVersion.AutoDetect(connectivity)));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
