import { Blogs } from "./IBlogs";
import { PortfolioItems } from "./IPortfolioItems";

export interface Category {
  id: number;
  categoryName: string;
  parentCategoryId: number | null;
  postedBlog: Blogs[];
  postedItem: PortfolioItems[];
}
