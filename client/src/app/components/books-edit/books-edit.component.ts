import { Author } from './../../models/author';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Book } from 'src/app/models/book';
import { GetBooksService } from '../../services/get-books.service';

@Component({
  selector: 'app-books-edit',
  templateUrl: './books-edit.component.html',
  styleUrls: ['./books-edit.component.css']
})
export class BooksEditComponent implements OnInit {
  currentBook: Book | undefined;
  bookError = false;
  private subscription: Subscription | null = null;
  searchText: string = "";
  id: number | undefined;
  authorIdRaw: string = "";

  constructor(
    private getBooksService: GetBooksService, 
    private route: ActivatedRoute, 
    private router: Router
  ) {  }

  ngOnInit(): void {
    this.subscription = this.route.params.subscribe(params => {
      const id = params['id'];
      this.readBooksById(id);
    });
  }

  writeSearchVar(value: string) {
    this.searchText = value;
  }

  readBooksById(id: number): void {
    this.getBooksService.getBooksById(id).subscribe(
      data => {
        this.currentBook = data.result;
        const authorIdRaw = this.currentBook?.authors.map(_ => _.id).join(",");
        console.log(authorIdRaw)
      }
    )
  }

  updateBook(id: number, name: string, photoPath: string, libraryId: number, authorIdRaw: string): void {
    const authorId: number[] = this.authorIdRaw.split(',').map(Number);
    this.getBooksService.updateBook(id, name, photoPath, libraryId, authorId)
  }

  deleteBook(id: number): void {
    this.getBooksService.deleteBook(id).subscribe(
      response => {
        console.log(response);
        this.router.navigate(['/books']);
      }
    )
  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }

}
