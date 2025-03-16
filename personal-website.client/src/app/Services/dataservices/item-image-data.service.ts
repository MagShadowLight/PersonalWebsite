import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { PortfolioItemImages } from '../../models/IPortfolioItemImages';

@Injectable({
  providedIn: 'root'
})
export class ItemImageDataService {
  Images$: BehaviorSubject<PortfolioItemImages[]> = new BehaviorSubject<PortfolioItemImages[]>([]);
  Image$: BehaviorSubject<PortfolioItemImages> = new BehaviorSubject<PortfolioItemImages>({
    id: 0,
    name: '',
    description: '',
    path: '',
    fileSize: 0,
    portfolioId: 0
  })
  constructor(private _http: HttpClient) { }
}
