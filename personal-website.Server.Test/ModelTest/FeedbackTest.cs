using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_website.Server.Test.ModelTest
{
    public class FeedbackTest
    {
        [Fact]
        public void When_Feedback_Have_Name_Then_It_Should_Succeed()
        {
            // Arrange
            var feedback = new personal_website.Server.Models.Feedback
            {
                FeedbackName = "John Doe"
            };
            // Act
            var name = feedback.FeedbackName;
            // Assert
            Assert.NotNull(name);
        }
        [Fact]
        public void When_Feedback_Have_Comment_Then_It_Should_Succeed()
        {
            // Arrange
            var feedback = new personal_website.Server.Models.Feedback
            {
                FeedbackComment = ""
            };
            // Act
            var comment = feedback.FeedbackComment;
            // Assert
            Assert.NotNull(comment);
        }
        [Fact]
        public void When_Feedback_Have_Email_Then_It_Should_Succeed()
        {
            // Arrange
            var feedback = new personal_website.Server.Models.Feedback
            {
                Email = "meow@meow.com"
            };
            // Act
            var email = feedback.Email;
            // Assert
            Assert.NotNull(email);
        }
        [Fact]
        public void When_FeedbackEmail_Contains_AtSymbol_Then_It_Should_Succeed()
        {
            // Arrange
            var feedback = new personal_website.Server.Models.Feedback
            {
                Email = "meow@meow.com"
            };
            // Act
            var email = feedback.Email;
            // Assert
            Assert.Contains("@", email);
        }
        [Fact]
        public void When_Feedback_Does_Not_Solved_Then_It_Should_Succeed()
        {
            // Arrange
            var feedback = new personal_website.Server.Models.Feedback
            {
                IsResolved = false
            };
            // Act
            var isResolved = feedback.IsResolved;
            // Assert
            Assert.False(isResolved);
        }
    }
}
