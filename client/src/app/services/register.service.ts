import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

interface RegisterResult {
  isSucceeded: boolean;
  errors: Array<string>;
}

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  private readonly apiUrl = `${environment.apiUrl}api/account`;

  constructor(private router: Router, private http: HttpClient) { }

  register(email: string, password: string, confirmPassword: string): Observable<RegisterResult> {
    let returnResult = this.http.post<RegisterResult>(`${this.apiUrl}/register`, { email, password, confirmPassword });
    console.log(returnResult)
    return returnResult;
  }
}
