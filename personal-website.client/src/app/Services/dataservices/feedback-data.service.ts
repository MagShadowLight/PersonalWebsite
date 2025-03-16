import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { Feedback } from '../../models/IFeedback';

@Injectable({
  providedIn: 'root'
})
export class FeedbackDataService {
  feedbacks$: BehaviorSubject<Feedback[]> = new BehaviorSubject<Feedback[]>([]);
  feedback$: BehaviorSubject<Feedback> = new BehaviorSubject<Feedback>({
    id: 0,
    feedbackName: '',
    email: '',
    feedbackComment: '',
    neededResponse: false,
    isResolved: false
  })
  constructor(private _http: HttpClient) { }

  GetAllFeedback(): void {
    this._http.get<Feedback[]>('/api/Feedbacks').subscribe(data => {
      this.feedbacks$.next(data);
    });
  }

  GetFeedbackById(id: number): void {
    this._http.get<Feedback>(`/api/Feedbacks/${id}`).subscribe(data => {
      this.feedback$.next(data);
    });
  }

  GetFeedbackInfoById(id: number): Observable<Feedback> {
    return this._http.get<Feedback>(`/api/Feedbacks/${id}`).pipe(
      tap(data => this.feedback$.next(data))
    );
  }

  CreateFeedback(feedback: Feedback): Observable<Feedback> {
    return this._http.post<Feedback>('/api/Feedbacks', feedback);
  }

  UpdateFeedback(id: number, feedback: Feedback) {
    return this._http.put<Feedback>(`/api/Feedbacks/${id}`, feedback);
  }

  DeleteFeedback(id: number): Observable<any> {
    return this._http.delete<any>(`/api/Feedbacks/${id}`);
  }
}
