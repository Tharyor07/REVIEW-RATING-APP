using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using repository_pattern.Data;
using repository_pattern.Model;
using repository_pattern.Services;

namespace repository_pattern
{
    public class Program
    {
        private readonly static string _env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<ITeacher, TeacherService>();
            builder.Services.AddScoped<IStudent, StudentService>();
            builder.Services.AddScoped<IAuth, AuthService>();
            builder.Services.AddScoped<ITokenGenerator, TokenGeneratorService>();


            string connectivity = builder.Configuration.GetConnectionString("DataConnection");

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.User.AllowedUserNameCharacters =
           "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 7;
                options.Password.RequiredUniqueChars = 1;
            }).AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
            if (_env != "Development")
            {
                builder.Services.AddDbContext<DataContext>(options => options.UseMySql(Environment.GetEnvironmentVariable("DataConnection"), ServerVersion.AutoDetect(Environment.GetEnvironmentVariable("DataConnection"))));
            }
            else
            {
                builder.Services.AddDbContext<DataContext>(options => options.UseMySql(connectivity, ServerVersion.AutoDetect(connectivity)));
            }
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
           
            // Configure the HTTP request pipeline.
            
            app.UseSwagger();
            app.UseSwaggerUI();
            
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowSpecificOrigin");


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}