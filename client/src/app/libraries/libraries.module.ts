import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LibrariesRoutingModule } from './libraries-routing.module';
import { LibraryListComponent } from './library-list/library-list.component';


@NgModule({
  declarations: [
    LibraryListComponent
  ],
  imports: [
    CommonModule,
    LibrariesRoutingModule
  ]
})
export class LibrariesModule { }
