import { TestBed } from '@angular/core/testing';

import { GetBooksService } from './get-books.service';

describe('GetBooksService', () => {
  let service: GetBooksService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetBooksService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
