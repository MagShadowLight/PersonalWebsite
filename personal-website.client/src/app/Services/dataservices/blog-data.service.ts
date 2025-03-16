import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { Blogs } from '../../models/IBlogs';

@Injectable({
  providedIn: 'root'
})
export class BlogDataService {
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
  constructor(private _http: HttpClient) { }

  getAllBlogs(): void {
    this._http.get<Blogs[]>('/api/blogs').subscribe(data => {
      this.blogs$.next(data);
    });
  }

  getBlogsbyId(id: number) {
    this._http.get<Blogs>(`/api/blogs/${id}`).subscribe(data => {
      this.blog$.next(data);
    });
  }

  getBlogInfoById(id: number): Observable<Blogs> {
    return this._http.get<Blogs>(`/api/blogs/${id}`).pipe(
      tap(data => this.blog$.next(data))
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
}
