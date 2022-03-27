import { Library } from './../models/library';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { tap, Observable, BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Book } from '../models/book';


interface GetBooksResult {
  isSucceeded: boolean;
  // todo change any to object
  result: GetBooksInResult;
  errors: Array<string>;
}

interface GetBooksInResult {
  books: Book;
}

@Injectable({
  providedIn: 'root'
})
export class GetBooksService {
  private readonly apiUrl = `${environment.apiUrl}api/books`;
  private _book = new BehaviorSubject<Book | null>(null);

  constructor(private router: Router, private http: HttpClient) { 
  }

  getBooks(): Observable<GetBooksResult> {
    let a = this.http.get<GetBooksResult>(this.apiUrl).pipe(
      tap(x => {
        this._book.next({
          name: x.result.books.name,
          authors: x.result.books.authors,
          library: x.result.books.library
        })
      })
    );
    console.log('get: ', a);
    console.log('_book: ', this._book);
    return a;
  }
}
