import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css']
})

export class SearchBarComponent implements OnInit {

  searchText: string = '';
  isButtonVisible: boolean = false;
  @Output() buttonClicked = new EventEmitter();
  searchcriteria = new EventEmitter<String>();

  constructor(private router: Router) { }

  ngOnInit(): void { }

  onSubmit() {
    this.buttonClicked.emit(this.searchText);
    this.isButtonVisible = true;
  }

  onClear() {
    this.searchText = '';
    this.isButtonVisible = false;
    this.buttonClicked.emit(this.searchText);
  }

}
