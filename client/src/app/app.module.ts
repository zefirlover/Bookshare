import { CoreModule } from './core.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './components/header/header.component';
import { SearchBarComponent } from './components/search-bar/search-bar.component';
import { FormsModule } from '@angular/forms';
import { FooterComponent } from './components/footer/footer.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { ErrorComponent } from './components/error/error.component';
import { RegisterComponent } from './components/register/register.component';
import { AuthorsModule } from './authors/authors.module';
import { LibrariesModule } from './libraries/libraries.module';
import { SearchPipe } from './search.pipe';
import { BooksEditComponent } from './components/books-edit/books-edit.component';
import { BooksComponent } from './components/books/books.component';
import { AddBookComponent } from './components/add-book/add-book.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SearchBarComponent,
    FooterComponent,
    HomeComponent,
    LoginComponent,
    ErrorComponent,
    RegisterComponent,
    SearchPipe,
    BooksEditComponent,
    BooksComponent,
    AddBookComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    AuthorsModule,
    LibrariesModule
    /*
        JwtModule.forRoot({
          config:{
            tokenGetter:() => {
              return localStorage.getItem('access_token');
            },
            allowedDomains: ['localhost:5000'],
            disallowedRoutes:[]
          }
        })*/
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
