import { BlogsScreenshot } from "./IBlogScreenshot";
import { Category } from "./ICategory";

export interface Blogs {
  id: number;
  displayName: string;
  title: string;
  body: string;
  createdDate: Date;
  updatedDate: Date;
  visibility: number;
  categoryId: number;
  category: Category;
  blogsScreenshotId: number;
  blogsScreenshot: BlogsScreenshot;
}
