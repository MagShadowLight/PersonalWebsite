using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace personal_website.Server.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        [ForeignKey("ParentCategoryId")]
        public int? ParentCategoryId{ get; set; }

        public virtual IEnumerable<Blogs>? PostedBlogs { get; set; }
        public virtual IEnumerable<PortfolioItems>? PostedItems { get; set; }


    }
}
