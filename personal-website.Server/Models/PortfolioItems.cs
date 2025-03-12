using System.ComponentModel.DataAnnotations.Schema;

namespace personal_website.Server.Models
{
    public class PortfolioItems
    {

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Version { get; set; }
        public string Links { get; set; }
        // Foreign Key Categories
        [ForeignKey(nameof(Categories.Id))]
        public int? CategoryId { get; set; }
        // Related Data Categories
        public virtual Categories? Category { get; set; }
        [ForeignKey(nameof(PortfolioItemImages.Id))]
        public int ImageID { get; set; }
        public PortfolioItemImages Image { get; set; }

    }
}
