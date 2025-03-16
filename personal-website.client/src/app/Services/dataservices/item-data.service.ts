import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PortfolioItems } from '../../models/IPortfolioItems';
import { BehaviorSubject, Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ItemDataService {
  portfolioItems$: BehaviorSubject<PortfolioItems[]> = new BehaviorSubject<PortfolioItems[]>([]);
  portfolioItem$: BehaviorSubject<PortfolioItems> = new BehaviorSubject<PortfolioItems>({
    id: 0,
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

  constructor(private _http: HttpClient) { }

  getAllPortfolioItems(): void {
    this._http.get<PortfolioItems[]>('/api/PortfolioItems').subscribe(data => {
      this.portfolioItems$.next(data);
    });
  }

  getPortfolioItemById(id: number) {
    this._http.get<PortfolioItems>(`/api/PortfolioItems/${id}`).subscribe(data => {
      this.portfolioItem$.next(data);
    });
  }

  getItemInfoById(id: number): Observable<PortfolioItems> {
    return this._http.get<PortfolioItems>(`/api/PortfolioItems/${id}`).pipe(
      tap(data => this.portfolioItem$.next(data))
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
}
