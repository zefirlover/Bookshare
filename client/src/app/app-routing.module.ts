import { AddBookComponent } from './components/add-book/add-book.component';
import { RegisterComponent } from './components/register/register.component';
import { ErrorComponent } from './components/error/error.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './guards/auth.guard';
import { BooksEditComponent } from './components/books-edit/books-edit.component';
import { BooksComponent } from './components/books/books.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: '',
    component: HomeComponent,
    canActivate: [AuthGuard],
  },
  { path: 'error', component: ErrorComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'authors',
    loadChildren: () =>
      import('./authors/authors.module').then(
        (m) => m.AuthorsModule
      ),
    canActivate: [AuthGuard],
  },
  {
    path: 'libraries',
    loadChildren: () =>
      import('./libraries/libraries.module').then(
        (m) => m.LibrariesModule
      ),
    canActivate: [AuthGuard],
  },
  {
    path: 'books',
    component: BooksComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'books/:id',
    component: BooksEditComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'addBook',
    component: AddBookComponent,
    canActivate: [AuthGuard],
  },
  { path: '**', redirectTo: 'error' },
];

@NgModule({
  imports: [BrowserModule, RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
