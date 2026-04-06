import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { LeaveService } from '../../core/Services/leaveservice';

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
    public leaveService: LeaveService,
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
        // this.router.navigate(['/apply']); 
        // Save their ID and Name to local storage so the Dashboard knows who they are
        localStorage.setItem('loggedInUser', user.associateId); 
        localStorage.setItem('employeeName', user.name); 

        // Redirect straight to the Dashboard!
      this.router.navigate(['/dashboard']);
      },
      error: (err) => {
        this.errorMessage = 'Invalid credentials. Please try again.';
        console.error(err);
      }
    });
  }
}