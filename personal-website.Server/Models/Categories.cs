using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace personal_website.Server.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        [ForeignKey("ParentCategory")]
        public int? ParentCategoryId{ get; set; }

        public virtual ICollection<Blogs>? PostedBlogs { get; set; }
        public virtual ICollection<PortfolioItems>? PostedItems { get; set; }


    }
}
