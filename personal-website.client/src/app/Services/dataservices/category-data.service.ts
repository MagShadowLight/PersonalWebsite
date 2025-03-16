import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { Category } from '../../models/ICategory';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CategoryDataService {
  categories$: BehaviorSubject<Category[]> = new BehaviorSubject<Category[]>([]);
  category$: BehaviorSubject<Category> = new BehaviorSubject<Category>({
    id: 0,
    categoryName: '',
    parentCategoryId: null,
    postedBlog: [],
    postedItem: []
  })
  constructor(private _http: HttpClient) { }

  getAllCategories(): void {
    this._http.get<Category[]>('/api/Categories').subscribe(data => {
      this.categories$.next(data);
    })
  }

  getCategoryById(id: number) {
    this._http.get<Category>(`/api/Categories/${id}`).subscribe(data => {
      this.category$.next(data);
    })
  }

  getCategoryInfoById(id: number): Observable<Category> {
    return this._http.get<Category>(`/api/Categories/${id}`).pipe(
      tap(data => this.category$.next(data))
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
}
