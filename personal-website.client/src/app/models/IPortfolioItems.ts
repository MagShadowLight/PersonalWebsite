import { Category } from "./ICategory";
import { PortfolioItemImages } from "./IPortfolioItemImages";

export interface PortfolioItems {
  id: number;
  displayName: string;
  title: string;
  description: string;
  creationDate: Date;
  updatedDate: Date;
  version: string;
  links: string;
  categoryId: number;
  category: Category;
  imageId: number;
  image: PortfolioItemImages;
}
