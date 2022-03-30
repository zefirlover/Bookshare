import { GetBooksService } from './../../services/get-books.service';
import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
// todo change any
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
