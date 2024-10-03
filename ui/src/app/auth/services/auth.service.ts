import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { tap, mapTo, catchError } from 'rxjs/operators';
import { Tokens } from 'src/app/models/tokens';
import { UserCredentials } from '../../models/user-creds';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly API_URL = 'http://localhost:5000/api';
  private readonly JWT_TOKEN = 'JWT_TOKEN';
  private readonly USERNAME = 'USERNAME';
  private loggedUser!: string;

  constructor(private http: HttpClient) {}

  login(user: UserCredentials): Observable<any> {
    const headers = { 'Content-Type': 'application/json' };
    return this.http.post<any>('http://localhost:5000/api/account/login', user, { headers });
  }

  // login(user: UserCredentials): Observable<boolean> {
  //   return this.http.post<Tokens>('http://localhost:5000/api/account/login', user).pipe(
  //     tap((tokens) => this.doLoginUser(user.username, tokens)),
  //     mapTo(true),
  //     catchError((error) => {
  //       console.log(error.error);
  //       return of(false);
  //     })
  //   );
  // }

  logout(): Observable<boolean> {
    return this.http
      .post<any>(`${this.API_URL}/logout`, '123')
      .pipe(
        tap(() => this.doLogoutUser()),
        mapTo(true),
        catchError((error) => {
          console.log(error.error);
          return of(false);
        })
      );
  }

  isLoggedIn(): boolean {
    return !!this.getJwtToken();
  }

  private doLoginUser(username: string, tokens: Tokens): void {
    this.loggedUser = username;
    this.storeTokens(username, tokens);
  }

  private doLogoutUser(): void {
    this.loggedUser = '';
    this.removeTokens();
  }

  storeTokens(username: string, tokens: Tokens): void {
    localStorage.setItem(this.JWT_TOKEN, tokens.jwt);
    localStorage.setItem(this.USERNAME, username);
  }

  getJwtToken(): string|null {
    return localStorage.getItem(this.JWT_TOKEN);
  }

  removeTokens(): void {
    localStorage.removeItem(this.JWT_TOKEN);
    localStorage.removeItem(this.USERNAME);
  }
}
