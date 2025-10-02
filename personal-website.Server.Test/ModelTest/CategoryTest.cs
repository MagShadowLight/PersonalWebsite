using personal_website.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_website.Server.Test.ModelTest
{
    public class CategoryTest
    {
        [Fact]
        public void When_Category_Have_Name_Then_It_Should_Succeed()
        {
            // Arrange
            var category = new personal_website.Server.Models.Categories
            {
                CategoryName = "Test Category",
            };

            // Act
            var result = category.CategoryName;

            // Assert
            Assert.NotNull(result);
        }
    }
}
