import { Author } from './../../models/author';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Book } from 'src/app/models/book';
import { GetBooksService } from 'src/app/services/get-books.service';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent implements OnInit {
  Book: Book | undefined;
  private subscription: Subscription | null = null;

  name: string = '';
  photoPath: string = '';
  libraryId: number = 0;
  authorIdRaw: string = '';
  authorId: number[] = [];

  constructor(
    private getBooksService: GetBooksService,
    private route: ActivatedRoute, 
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  addBook(name: string, photoPath: string, libraryId: number, authorIdRaw: string): void {
    const authorId = authorIdRaw.split(',').map(Number);
    this.getBooksService.createBook(name, photoPath, libraryId, authorId).subscribe(
      response => {
        console.log(response);
        // this.router.navigate(['/books']);
      }
    );
  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }
}
