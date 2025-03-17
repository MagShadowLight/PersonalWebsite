using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using personal_website.Server.Areas.Identity.Data;
using personal_website.Server.Models;

namespace personal_website.Server.Data
{
    public class personal_websiteServerContext : IdentityDbContext<PersonalUser>
    {
        public personal_websiteServerContext (DbContextOptions<personal_websiteServerContext> options)
            : base(options)
        {
        }

        public static async Task SeedUserAsync(UserManager<PersonalUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var usersData = new List<(PersonalUser User, string Password)>
                {
                    (new PersonalUser
                    {
                        UserName = "meow@adminmeow.com",
                        Email = "meow@adminmeow.com",
                        DisplayName = "Admin User",
                        Location = "Server Room",
                        EmailConfirmed = true
                    }, "Admin123!"),

                    (new PersonalUser
                    {
                        UserName = "meow@meow.com",
                        Email = "meow@meow.com",
                        DisplayName = "Meower User",
                        Location = "US",
                        EmailConfirmed = true
                    }, "Meow123!"),
                    (new PersonalUser
                    {
                        UserName = "test@test.com",
                        Email = "test@test.com",
                        DisplayName = "Test User",
                        Location = "Washington",
                        EmailConfirmed = true
                    }, "Test123!")
                };

                foreach (var (user, password) in usersData)
                {
                    var result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        throw new Exception($"Failed to seed the user {user.Email}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add Seed Data

            // Blogs
            modelBuilder.Entity<Blogs>().HasData(
                    new Blogs
                    {
                        Id = 1,
                        DisplayName = "Cats",
                        Title = "Cats",
                        Body = "I love cats",
                        CreatedDate = new DateTime(),
                        UpdatedDate = new DateTime(),
                        CategoryId = 2,
                        Visibility = Visibility.Visible,
                        Category =
                        {
                            
                        }
                    },
                    new Blogs
                    {
                        Id = 2,
                        DisplayName = "Tacos",
                        Title = "Taco",
                        Body = "I love Taco",
                        CreatedDate = new DateTime(),
                        UpdatedDate = new DateTime(),
                        CategoryId = 7,
                        Visibility = Visibility.Visible,
                        Category =
                        {
                            
                        }
                    }
                );
            // Categories
            modelBuilder.Entity<Categories>().HasData(
                    new Categories
                    {
                        Id = 1,
                        CategoryName = "Pets",
                        ParentCategoryId = null,
                        PostedBlogs = []
                    },
                    new Categories
                    {
                        Id = 2,
                        CategoryName = "Cats",
                        ParentCategoryId = 1,
                        PostedBlogs = []
                    },
                    new Categories
                    {
                        Id = 3,
                        CategoryName = "Dogs",
                        ParentCategoryId = 1,
                        PostedBlogs = []
                    },
                    new Categories
                    {
                        Id = 4,
                        CategoryName = "Technology",
                        ParentCategoryId = null,
                        PostedBlogs = []
                    },
                    new Categories
                    {
                        Id = 5,
                        CategoryName = "Software",
                        ParentCategoryId = 4,
                        PostedBlogs = []
                    },
                    new Categories
                    {
                        Id = 6,
                        CategoryName = "Website",
                        ParentCategoryId = 4,
                        PostedBlogs = []
                    },
                    new Categories
                    {
                        Id = 7,
                        CategoryName = "Foods",
                        ParentCategoryId = null,
                        PostedBlogs = []
                    },
                    new Categories
                    {
                        Id = 8,
                        CategoryName = "Arts",
                        ParentCategoryId = null,
                        PostedBlogs = []
                    },
                    new Categories
                    {
                        Id = 9,
                        CategoryName = "Fitness",
                        ParentCategoryId = null,
                        PostedBlogs = []
                    }
                );
            // Feedbacks
            modelBuilder.Entity<Feedback>().HasData(
                    new Feedback
                    {
                        Id = 1,
                        FeedbackName = "Website",
                        Email = "test@test.com",
                        FeedbackComment = "I love this website",
                        NeededResponse = false,
                        IsResolved = false
                    },
                    new Feedback
                    {
                        Id = 2,
                        FeedbackName = "Security Vulnerability",
                        Email = "meow@meow.com",
                        FeedbackComment = "This website has security vulnerability",
                        NeededResponse = true,
                        IsResolved = true
                    },
                    new Feedback
                    {
                        Id = 3,
                        FeedbackName = "Fake News",
                        Email = "Real@fake.com",
                        FeedbackComment = "This previous post is a lie",
                        NeededResponse = false,
                        IsResolved = true
                    }
                );
            // PortfolioItemImages
            modelBuilder.Entity<PortfolioItemImages>().HasData(
                    new PortfolioItemImages
                    {
                        Id = 1,
                        Name = "Cat",
                        Description = "Pic of cat",
                        Path = "images/cat.png",
                        FileSize = 12006
                    },
                    new PortfolioItemImages
                    {
                        Id = 2,
                        Name = "Taco",
                        Description = "Pic of taco",
                        Path = "images/taco.png",
                        FileSize = 14400
                    },
                    new PortfolioItemImages
                    {
                        Id = 3,
                        Name = "dog",
                        Description = "Pic of dog",
                        Path = "images/dog.png",
                        FileSize = 21457
                    }
                );
            // PortfolioItems
            modelBuilder.Entity<PortfolioItems>().HasData(
                    new PortfolioItems
                    {
                        Id = 1,
                        DisplayName = "Cat",
                        Title = "Cat",
                        Description = "Cat pic",
                        CreationDate = new DateTime(),
                        UpdatedDate = new DateTime(),
                        Version = "1.0.0",
                        Links = "github.com",
                        CategoryId = 2,
                        Category = null,
                        Image = null,
                        ImageID = 1
                    },
                    new PortfolioItems
                    {
                        Id = 2,
                        DisplayName = "Taco",
                        Title = "Taco",
                        Description = "Taco pic",
                        CreationDate = new DateTime(),
                        UpdatedDate = new DateTime(),
                        Version = "0.0.3",
                        Links = "meow.com",
                        CategoryId = 7,
                        Category = null,
                        Image = null,
                        ImageID = 2
                    },
                    new PortfolioItems
                    {
                        Id = 3,
                        DisplayName = "Dog",
                        Title = "Dog",
                        Description = "Dog pic",
                        CreationDate = new DateTime(),
                        UpdatedDate = new DateTime(),
                        Version = "0.1.0",
                        Links = "woof.com",
                        CategoryId = 3,
                        Category = null,
                        Image = null,
                        ImageID = 3
                    }
                );

            modelBuilder.Entity<Categories>()
                .HasMany(b => b.PostedBlogs)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId)
                .IsRequired(false);

            modelBuilder.Entity<Categories>()
                .HasMany(p => p.PostedItems)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired(false);

            modelBuilder.Entity<PortfolioItemImages>()
                .HasOne(i => i.Items)
                .WithOne(i => i.Image)
                .HasForeignKey<PortfolioItems>(i => i.ImageID)
                .IsRequired(false);
                

            modelBuilder.Entity<Blogs>().Navigation(c => c.Category).AutoInclude();
            modelBuilder.Entity<Categories>().Navigation(c => c.PostedBlogs).AutoInclude();
            modelBuilder.Entity<PortfolioItems>().Navigation(c => c.Category).AutoInclude();
            modelBuilder.Entity<Categories>().Navigation(c => c.PostedItems).AutoInclude();
            modelBuilder.Entity<PortfolioItems>().Navigation(c => c.Image).AutoInclude();

            //modelBuilder.Entity<Categories>().Property(b => b.Id)
            //    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            
        }



        public DbSet<personal_website.Server.Models.PortfolioItems> PortfolioItems { get; set; } = default!;
        public DbSet<personal_website.Server.Models.PortfolioItemImages> PortfolioItemImages { get; set; } = default!;
        public DbSet<personal_website.Server.Models.Blogs> Blogs { get; set; } = default!;
        public DbSet<personal_website.Server.Models.Feedback> Feedback { get; set; } = default!;
        public DbSet<personal_website.Server.Models.Categories> Categories { get; set; } = default!;
    }
}
