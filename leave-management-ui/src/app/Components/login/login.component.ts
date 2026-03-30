import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { LeaveService } from '../../Services/leave';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html'
})
export class LoginComponent {
  associateId: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(
    private leaveService: LeaveService,
    private router: Router
  ) {}

  onLogin() {
    if (!this.associateId || !this.password) {
      this.errorMessage = 'Please enter both Associate ID and Password.';
      return;
    }

    this.leaveService.login(this.associateId, this.password).subscribe({
      next: (user) => {
        this.errorMessage = '';
        this.leaveService.setLoginState(this.associateId); 
        this.router.navigate(['/apply']); 
      },
      error: (err) => {
        this.errorMessage = 'Invalid credentials. Please try again.';
        console.error(err);
      }
    });
  }
}