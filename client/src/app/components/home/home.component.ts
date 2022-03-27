import { GetBooksService } from './../../services/get-books.service';
import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/models/book';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  books: any;
  bookError = false;
  private subscription: Subscription | null = null;

  constructor(private getBooksService: GetBooksService) {  }

  ngOnInit(): void {
    this.ReadBooks();
  }

  ReadBooks(): void {
    this.getBooksService.getBooks().subscribe (
      data => {
        this.books = data.result.books;
        console.log('list of books: ', this.books);
      }
    )
  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }

}
