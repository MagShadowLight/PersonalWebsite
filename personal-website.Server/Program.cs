using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using personal_website.Server.Data;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using personal_website.Server.Areas.Identity.Data;

namespace personal_website.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<personal_websiteServerContext>(options =>
                //options.UseSqlServer(builder.Configuration.GetConnectionString("personal_websiteServerContext") ?? throw new InvalidOperationException("Connection string 'personal_websiteServerContext' not found.")));
                options.UseSqlite(builder.Configuration.GetConnectionString("personal_websiteServerContext") ?? throw new InvalidOperationException("Connection string 'personal_websiteServerContext' not found.")));

            builder.Services.AddDefaultIdentity<PersonalUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<personal_websiteServerContext>();

            // Add services to the container.

            // Add CORS Policy
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy
                        // .AllowAnyOrigin()
                        .WithOrigins("https://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();

                    policy.WithOrigins("https://my-website-frontend");
                });
            });

            // Add ignore cycle
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });

            builder.Services.AddControllers();
            //    .AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            //});
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.WebHost.ConfigureKestrel(options =>
            //{
            //    options.ListenAnyIP(7164);
            //});

            var app = builder.Build();

            // Enable CORS middleware
            app.UseCors();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            var imagepath = Path.Combine(AppContext.BaseDirectory, "Images");
            if (!Directory.Exists(imagepath))
                Directory.CreateDirectory(imagepath);
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                        Path.Combine(builder.Environment.ContentRootPath, "Images")),
                RequestPath = "/Images"
            });
            app.UseRouting();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.MapRazorPages();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
