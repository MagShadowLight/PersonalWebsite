import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { Blogs } from './models/IBlogs';
import { Category } from './models/ICategory';
import { PortfolioItems } from './models/IPortfolioItems';
import { PortfolioItemImages } from './models/IPortfolioItemImages';
import { Feedback } from './models/IFeedback';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  blogs$: BehaviorSubject<Blogs[]> = new BehaviorSubject<Blogs[]>([]);
  blog$: BehaviorSubject<Blogs> = new BehaviorSubject<Blogs>({
    id: 0,
    displayName: '',
    title: '',
    body: '',
    createdDate: new Date,
    updatedDate: new Date,
    visibility: 0,
    categoryId: 0,
    category: {
        id: 0,
        categoryName: '',
        parentCategoryId: null,
        postedBlog: [],
        postedItem: []
    }
  });
  portfolioItems$: BehaviorSubject<PortfolioItems[]> = new BehaviorSubject<PortfolioItems[]>([]);
  portfolioItem$: BehaviorSubject<PortfolioItems> = new BehaviorSubject<PortfolioItems>({
    id:  0,
    displayName: '',
    title: '',
    description: '',
    creationDate: new Date,
    updatedDate: new Date,
    version: '',
    links: '',
    categoryId: 0,
    category: {
        id: 0,
        categoryName: '',
        parentCategoryId: null,
        postedBlog: [],
        postedItem: []
    },
    imageID: 0,
    image: {
        id: 0,
        name: '',
        description: '',
        path: '',
        fileSize: 0,
        portfolioId: 0
    }
  })
  categories$: BehaviorSubject<Category[]> = new BehaviorSubject<Category[]>([]);
  category$: BehaviorSubject<Category> = new BehaviorSubject<Category>({
    id: 0,
    categoryName: '',
    parentCategoryId: null,
    postedBlog: [],
    postedItem: []
  })

  Images$: BehaviorSubject<PortfolioItemImages[]> = new BehaviorSubject<PortfolioItemImages[]>([]);
  Image$: BehaviorSubject<PortfolioItemImages> = new BehaviorSubject<PortfolioItemImages>({
    id: 0,
    name: '',
    description: '',
    path: '',
    fileSize: 0,
    portfolioId: 0
  })
  feedbacks$: BehaviorSubject<Feedback[]> = new BehaviorSubject<Feedback[]>([]);
  feedback$: BehaviorSubject<Feedback> = new BehaviorSubject<Feedback>({
    id: 0,
    feedbackName: '',
    email: '',
    feedbackComment: '',
    neededResponse: false,
    isResolved: false
  })

  constructor(private _http: HttpClient) {
    //this.blog = [
    //  {
    //      Id: 1,
    //      title: 'Cats',
    //      body: 'I love cats',
    //      createdDate: new Date(),
    //      updatedDate: new Date(),
    //      Visibility: 0,
    //      categoryId: 2,
    //      category: {
    //          categoryId: 2,
    //          categoryName: 'Cats',
    //          parentCategoryId: 1
    //      },
    //      displayName: 'Cats'
    //  },
    //  {
    //      Id: 2,
    //      title: 'Taco',
    //      body: 'I love Taco',
    //      createdDate: new Date(),
    //      updatedDate: new Date(),
    //      Visibility: 0,
    //      categoryId: 7,
    //      category: {
    //          categoryId: 7,
    //          categoryName: 'Foods',
    //          parentCategoryId: null
    //      },
    //      displayName: 'Tacos'
    //  }
    //]

    
  }

  getAllBlogs() {
    this._http.get<Blogs[]>('/api/blogs').subscribe((data : any) => {
      this.blogs$.next(data);
    });
  }

  getBlogsbyId(id: number) {
    this._http.get<Blogs>(`/api/blogs/${id}`).subscribe((data : any) => {
      this.blog$.next(data);
    });
  }

  getBlogInfoById(id: number): Observable<Blogs> {
    return this._http.get<Blogs>(`/api/blogs/${id}`).pipe(
      tap((data : any) => this.blog$.next(data))
    );
  }

  createBlog(blog: Blogs): Observable<Blogs> {
    return this._http.post<Blogs>('/api/blogs/', blog);
  }

  updateBlog(id: number, blog: Blogs): Observable<Blogs> {
    return this._http.put<Blogs>(`/api/blogs/${id}`, blog);
  }

  deleteBlog(id: number): Observable<any> {
    return this._http.delete<any>('/api/blogs/' + id);
  }

  getAllPortfolioItems(): void {
    this._http.get<PortfolioItems[]>('/api/PortfolioItems').subscribe((data : any) => {
      this.portfolioItems$.next(data);
    });
  }

  getPortfolioItemById(id: number) {
    this._http.get<PortfolioItems>(`/api/PortfolioItems/${id}`).subscribe((data : any) => {
      this.portfolioItem$.next(data);
    });
  }

  getItemInfoById(id: number): Observable<PortfolioItems> {
    return this._http.get<PortfolioItems>(`/api/PortfolioItems/${id}`).pipe(
      tap((data : any) => this.portfolioItem$.next(data))
    );
  }

  createItem(item: PortfolioItems): Observable<PortfolioItems> {
    return this._http.post<PortfolioItems>('/api/PortfolioItems/', item);
  }

  updateItem(id: number, item: PortfolioItems): Observable<PortfolioItems> {
    return this._http.put<PortfolioItems>(`/api/PortfolioItems/${id}`, item);
  }

  deleteItem(id: number): Observable<any> {
    return this._http.delete<any>('/api/PortfolioItems/' + id);
  }

  getAllCategories(): void {
    this._http.get<Category[]>('/api/Categories').subscribe((data : any) => {
      this.categories$.next(data);
    })
  }

  getCategoryById(id: number) {
    this._http.get<Category>(`/api/Categories/${id}`).subscribe((data : any) => {
      this.category$.next(data);
    })
  }

  getCategoryInfoById(id: number): Observable<Category> {
    return this._http.get<Category>(`/api/Categories/${id}`).pipe(
      tap((data : any) => this.category$.next(data))
    );
  }

  CreateCategory(category: Category): Observable<Category> {
    return this._http.post<Category>('/api/Categories/', category);
  }

  UpdateCategory(id: number, category: Category): Observable<Category> {
    return this._http.put<Category>(`/api/Categories/${id}`, category);
  }

  DeleteCategory(id: number): Observable<any> {
    return this._http.delete<any>(`/api/Categories/${id}`);
  }

  GetAllFeedback(): void {
    this._http.get<Feedback[]>('/api/Feedbacks').subscribe((data : any) => {
      this.feedbacks$.next(data);
    });
  }

  GetFeedbackById(id: number): void {
    this._http.get<Feedback>(`/api/Feedbacks/${id}`).subscribe((data : any) => {
      this.feedback$.next(data);
    });
  }

  GetFeedbackInfoById(id: number): Observable<Feedback> {
    return this._http.get<Feedback>(`/api/Feedbacks/${id}`).pipe(
      tap((data : any) => this.feedback$.next(data))
    );
  }

  CreateFeedback(feedback: Feedback): Observable<Feedback> {
    return this._http.post<Feedback>('/api/Feedbacks', feedback);
  }

  UpdateFeedback(id: number, feedback: Feedback) {
    return this._http.put<Feedback>(`/api/Feedbacks/${id}`, feedback);
  }

  DeleteFeedback(id: number) : Observable<any> {
    return this._http.delete<any>(`/api/Feedbacks/${id}`);
  }
}
