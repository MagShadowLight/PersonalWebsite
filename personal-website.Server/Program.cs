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
        public static async void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<personal_websiteServerContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("personal_websiteServerContext") ?? throw new InvalidOperationException("Connection string 'personal_websiteServerContext' not found.")));

            builder.Services.AddDefaultIdentity<PersonalUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<personal_websiteServerContext>();

            

            // Add services to the container.

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

            var app = builder.Build();

            // Seed User and Role
            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                try
                {
                    var userManager = service.GetRequiredService<UserManager<PersonalUser>>();
                    await PersonalWebsiteSeedDataContext.SeedUserAndRoleAsync(userManager);
                }
                catch (Exception ex)
                {
                    var logger = service.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured while seeding user data");
                }
            }

            //app.UseDefaultFiles();
            //app.UseStaticFiles();
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
