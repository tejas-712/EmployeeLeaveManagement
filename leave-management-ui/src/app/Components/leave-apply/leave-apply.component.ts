import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { LeaveService } from '../../Services/leave';
import { LeaveRequest } from '../../Models/leave-req';


@Component({
  selector: 'app-leave-apply',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './leave-apply.component.html',
  styleUrls: ['./leave-apply.component.css']
})
export class LeaveApplyComponent implements OnInit {
  associateId: string = '';
  leaveDate: string = '';
  absenceType: string = 'V'; // Default to Vacation
  
  statusMessage: string = '';
  isError: boolean = false;

  constructor(
    private leaveService: LeaveService,
    private router: Router
  ) {}

  ngOnInit() {
    // Auto-fill the Associate ID from local storage
    const storedId = localStorage.getItem('loggedInUser');
    if (storedId) {
      this.associateId = storedId;
    } else {
      // If no one is logged in, kick them back to the login page
      this.router.navigate(['/login']);
    }
  }

  onSubmit() {
    if (!this.leaveDate) {
      this.showMessage('Please select a valid date.', true);
      return;
    }

    const request: LeaveRequest = {
      associateId: this.associateId,
      leaveDate: this.leaveDate,
      absenceType: this.absenceType
    };

    this.leaveService.applyLeave(request).subscribe({
      next: (res) => {
        this.showMessage('Leave request submitted successfully!', false);
        this.leaveDate = ''; // Clear the date picker for the next entry
      },
      error: (err) => {
        console.error(err);
        this.showMessage('Failed to submit leave request. Please try again.', true);
      }
    });
  }

  private showMessage(msg: string, isError: boolean) {
    this.statusMessage = msg;
    this.isError = isError;
    
    // Auto-hide the message after 4 seconds
    setTimeout(() => {
      this.statusMessage = '';
    }, 4000);
  }
}