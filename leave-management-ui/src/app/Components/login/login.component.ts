import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { LeaveService } from '../../Services/leave';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
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
        // C# returned Ok(user), so the 'user' variable now holds the employee data!
        localStorage.setItem('loggedInUser', this.associateId); // Save the ID
        this.errorMessage = '';
        this.router.navigate(['/apply']); // Navigate to the dashboard
      },
      error: (err) => {
        
        this.errorMessage = 'Invalid credentials. Please try again.';
        console.error(err);
      }
    });
  }
}