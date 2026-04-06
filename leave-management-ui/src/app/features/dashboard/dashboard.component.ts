import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { UpcomingHolidaysComponent } from '../upcoming-holidays/upcoming-holidays.component';
import { LeaveApplyComponent } from '../leave-apply/leave-apply.component';
import { LeaveService } from '../../core/Services/leaveservice';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, RouterModule, UpcomingHolidaysComponent,LeaveApplyComponent], 
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  associateId: string = '';
  employeeName: string = ''; 
  showApplyLeaveModal: boolean = false;


  leaveBalances = {
    sickLeave: 0,
    casualLeave: 0,
    earnedLeave: 0
  };

  constructor(private leaveService: LeaveService) {}

  // NEW: Dummy data for recent leave history
  pastLeaves = [
    { date: '10 Mar 2026', type: 'Sick Leave', status: 'Approved', days: 1 },
    { date: '15 Feb 2026', type: 'Casual Leave', status: 'Approved', days: 2 },
    { date: '02 Jan 2026', type: 'Earned Leave', status: 'Approved', days: 5 }
  ];

  ngOnInit() {
    this.associateId = localStorage.getItem('loggedInUser') || '';
    this.employeeName = localStorage.getItem('employeeName') || 'Employee';

    // 4. Fetch the real balances from C#!
    if (this.associateId) {
      this.leaveService.getLeaveBalances(this.associateId).subscribe({
        next: (realBalances) => {
          // Replace the 0s with the real data from SQL Server!
          this.leaveBalances = realBalances; 
        },
        error: (err) => {
          console.error('Failed to fetch leave balances from the database', err);
        }
      });
    }  
  }

  // NEW: Methods to open and close the popup
  openLeaveModal() {
    this.showApplyLeaveModal = true;
  }

  closeLeaveModal() {
    this.showApplyLeaveModal = false;
  }
}