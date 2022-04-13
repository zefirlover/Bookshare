import { Library } from './../models/library';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { tap, Observable, BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Book } from '../models/book';


interface GetBooksResult {
  isSucceeded: boolean;
  result: GetBooksInResult;
  errors: string[];
}

interface DeleteBookResult {
  isSucceeded: boolean;
  errors: string[];
}

interface GetBooksInResult {
  books: Book;
}

interface GetBookByIdResult {
  isSucceeded: boolean;
  result: Book;
  errors: string[];
}

interface PostBook {
  name: string;
  photoPath?: string;
  authorId: number[];
  libraryId: number;
}

@Injectable({
  providedIn: 'root'
})
export class GetBooksService {
  private readonly apiUrl = `${environment.apiUrl}api/books`;
  private _book = new BehaviorSubject<Book | null>(null);
  private _errors = new BehaviorSubject<DeleteBookResult | null>(null);

  constructor(private router: Router, private http: HttpClient) { 
  }

  getBooks(): Observable<GetBooksResult> {
    return this.http.get<GetBooksResult>(this.apiUrl).pipe(
      tap(x => {
        this._book.next({
          id: x.result.books.id,
          name: x.result.books.name,
          authors: x.result.books.authors,
          library: x.result.books.library
        })
      })
    );
  };

  getBooksById(id: number): Observable<GetBookByIdResult> {
    return this.http.get<GetBookByIdResult>(`${this.apiUrl}/${id}`).pipe(
      tap(x => {
        this._book.next({
          id: x.result.id,
          name: x.result.name,
          authors: x.result.authors,
          library: x.result.library
        });
      })
    );
  }

  createBook(name: string, photoPath: string, libraryId: number, authorId: number[]): Observable<DeleteBookResult> {
    console.log(name)
    return this.http.post<DeleteBookResult>('http://localhost:5000/api/books', { name, photoPath, libraryId, authorId }).pipe(
      tap(x => {
        this._errors.next({
          isSucceeded: x.isSucceeded,
          errors: x.errors
        });
      })
    );
  };

  updateBook(id: number, name: string, photoPath: string, libraryId: number, authorsId: number[]): Observable<GetBooksResult> {
    return this.http.put<GetBooksResult>(`${this.apiUrl}/${id}`, { name, photoPath, libraryId, authorsId });
  };

  deleteBook(id: number): Observable<DeleteBookResult> {
    return this.http.delete<DeleteBookResult>(`${this.apiUrl}/${id}`);
  };
}
