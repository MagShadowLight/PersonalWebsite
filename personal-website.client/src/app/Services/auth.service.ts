import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, Observable, of, pipe, tap } from 'rxjs';
import { UserDto } from '../models/IUserDto';
import { HttpClient } from '@angular/common/http';
import { LoginDto } from '../models/ILoginDto';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private currentUserBehaviorSubject = new BehaviorSubject<UserDto | null>(null);
  public currentUser$ = this.currentUserBehaviorSubject;

  constructor(private _httpClient: HttpClient) { }

  login(credentials: LoginDto): Observable<UserDto> {
    return this._httpClient.post<UserDto>('/api/Auth/login', credentials).pipe(
      tap((user : any) => {
        //console.log("Logging in")
        this.currentUserBehaviorSubject.next(user);
        console.log(this.currentUserBehaviorSubject.value)
      })
    );
  }

  logout(): Observable<void> {
    return this._httpClient.post<void>('/api/Auth/logout', {}).pipe(
      tap(() => {
        this.currentUserBehaviorSubject.next(null);
      })
    );
  }

  public loadCurrentUser(): Observable<UserDto | null> {
    return this._httpClient.get<UserDto>('/api/Auth/current').pipe(
      tap((user : UserDto) => {
        //console.log("User Loaded")
        //console.log(this.currentUserBehaviorSubject.value)
        this.currentUserBehaviorSubject.next(user);
      }),
      catchError(() => {
        //console.log("Error: User not able to be loaded")
        this.currentUserBehaviorSubject.next(null);
        return of(null);
      })
    );
  }

  get currentUser(): UserDto | null {
    return this.currentUserBehaviorSubject.value;
  }

  isAuthenticated(): boolean {
    //console.log("Authenticating")
    return !!this.currentUserBehaviorSubject.value;
  }
}
