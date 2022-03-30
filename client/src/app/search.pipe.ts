import { Pipe, PipeTransform } from '@angular/core';
import { Book } from './models/book';

@Pipe({
  name: 'searchFilter'
})
export class SearchPipe implements PipeTransform {

  transform(books: Book[], searchText: string): Book[] {
    if (!books) {
      return [];
    }
    if (!searchText) {
      return books;
    }
    searchText = searchText.toLocaleLowerCase();

    return books.filter(book => {
      return book.name.toLocaleLowerCase().includes(searchText);
    })
  }

}
