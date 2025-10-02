using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_website.Server.Test.ModelTest
{
    public class BlogsTest
    {
        [Fact]
        public void When_Blog_Have_Title_Then_It_Should_Succeed()
        {
            // Arrange
            var Blog = new personal_website.Server.Models.Blogs
            {
                Title = ""
            };
            // Act
            var result = Blog.Title;
            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void When_Blog_Have_Body_Then_It_Should_Succeed()
        {
            // Arrange
            var Blog = new personal_website.Server.Models.Blogs
            {
                Body = ""
            };
            // Act
            var body = Blog.Body;
            // Assert
            Assert.NotNull(body);
        }
        [Fact]
        public void When_Blog_Have_CreatedDate_Then_It_Should_Succeed()
        {
            // Arrange
            var Blog = new personal_website.Server.Models.Blogs
            {
                CreatedDate = DateTime.Now
            };
            // Act
            var createdDate = Blog.CreatedDate;
            // Assert
            Assert.Equal(DateTime.Now.Date, createdDate.Date);
        }
        [Fact]
        public void When_Blog_Have_UpdatedDate_Then_It_Should_Succeed()
        {
            // Arrange
            var Blog = new personal_website.Server.Models.Blogs
            {
                UpdatedDate = DateTime.Now
            };
            // Act
            var updatedDate = Blog.UpdatedDate;
            // Assert
            Assert.Equal(DateTime.Now.Date, updatedDate.Date);
        }
        [Fact]
        public void When_Blog_Have_DisplayName_Then_It_Should_Succeed()
        {
            // Arrange
            var Blog = new personal_website.Server.Models.Blogs
            {
                DisplayName = ""
            };
            // Act
            var displayName = Blog.DisplayName;
            // Assert
            Assert.NotNull(displayName);
        }
    }
}
