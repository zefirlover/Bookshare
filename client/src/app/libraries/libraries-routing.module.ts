import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LibraryListComponent } from './library-list/library-list.component';

const routes: Routes = [
  { path: '', component: LibraryListComponent },
  { path: 'create', component: LibraryListComponent },
  { path: 'edit/:id', component: LibraryListComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LibrariesRoutingModule { }
