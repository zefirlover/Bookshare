import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { GetBooksService } from 'src/app/services/get-books.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  books: any;
  bookError = false;
  private subscription: Subscription | null = null;
  searchText: string = "";

  constructor(private getBooksService: GetBooksService) {  }

  ngOnInit(): void {
    this.ReadBooks();
  }

  writeSearchVar(value: string) {
    this.searchText = value;
  }

  ReadBooks(): void {
    this.getBooksService.getBooks().subscribe (
      data => {
        this.books = data.result.books;
      }
    )
  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }
}
