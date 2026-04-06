import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { LeaveRequest } from '../../shared/Models/leave-req';
// 1. IMPORT YOUR NEW COMPONENT
import { UpcomingHolidaysComponent } from '../upcoming-holidays/upcoming-holidays.component'; // Adjust path based on your folder structure
import { LeaveService } from '../../core/Services/leaveservice';

@Component({
  selector: 'app-leave-apply',
  standalone: true,
  // 2. ADD IT TO THE IMPORTS ARRAY
  imports: [CommonModule, FormsModule,],
  templateUrl: './leave-apply.component.html',
  styleUrls: ['./leave-apply.component.css'] 
})
export class LeaveApplyComponent implements OnInit {
  associateId: string = '';
  leaveDate: string = '';
  absenceType: string = 'V'; 
  
  statusMessage: string = '';
  isError: boolean = false;

   @Output() close = new EventEmitter<void>();

  leaveBalances = {
    sickLeave: 3.00,
    casualLeave: 6.00,
    earnedLeave: 6.00
  };

  constructor(
    private leaveService: LeaveService,
    private router: Router
  ) {}

  onClose() {
    this.close.emit();
  }

  ngOnInit() {
    const storedId = localStorage.getItem('loggedInUser');
    if (storedId) {
      this.associateId = storedId;
    } else {
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
        this.leaveDate = ''; 
        setTimeout(() => {
          this.onClose();
        }, 2000);
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
    setTimeout(() => {
      this.statusMessage = '';
    }, 4000);
  }
  
}