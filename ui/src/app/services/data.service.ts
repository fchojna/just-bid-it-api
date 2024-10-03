import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { tap, mapTo, catchError } from 'rxjs/operators';
import { Auction } from '../models/auction';
import { UserCredentials } from '../models/user-creds';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  apiUrl = 'http://localhost:5000/api';

  constructor(private http: HttpClient) { }

  // ___________________________________________________________________________
  // ACCOUNTS

  login(userCred: UserCredentials): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/account/login`, userCred).pipe(
      tap(token => console.log('token: \n' + token)),
      mapTo(true),
      catchError((error) => {
        console.log('error: \n' + error.error);
        return of(false);
      })
    );
  }

  // ___________________________________________________________________________
  // AUCTIONS

  // Get: All
  getAuctionsAll(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/auction/all`);
  }

  // Get: Single {id}
  getAuctionById(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/auction/${id}`);
  }
}
