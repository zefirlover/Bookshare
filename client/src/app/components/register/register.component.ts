import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  busy = false;
  email = '';
  password = '';
  confirmPassword = '';
  registerError = false;
  private subscription: Subscription | null = null;
  
  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }

  register() {
    if (!this.email || !this.password || !this.confirmPassword) {
      return;
    }
    this.busy = true;
    this.authService
      .register(this.email, this.password, this.confirmPassword)
      .subscribe(
        () => {
          this.busy = false;
        },
        (error) => {
          this.registerError = true;
          this.busy = false;
        }
      );
  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }
}
