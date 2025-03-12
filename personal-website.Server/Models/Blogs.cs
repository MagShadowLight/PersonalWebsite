using System.ComponentModel.DataAnnotations.Schema;

namespace personal_website.Server.Models
{
    public class Blogs
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Visibility Visibility { get; set; }
        [ForeignKey(nameof(Categories.Id))]
        public int? CategoryId { get; set; }

        public virtual Categories? Category { get; set; }

    }
}
