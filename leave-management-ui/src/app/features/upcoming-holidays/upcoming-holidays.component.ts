import { Component, Input, OnInit } from '@angular/core';
import { LeaveService } from '../../core/Services/leaveservice';
import { Holiday } from '../../shared/Models/Holidays';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-upcoming-holidays',
  standalone: true, // Make sure this is here!
  imports: [CommonModule],
  templateUrl: './upcoming-holidays.component.html',
  styleUrls: ['./upcoming-holidays.component.css'] // Make sure it is plural: styleUrls
})
export class UpcomingHolidaysComponent implements OnInit {

  @Input() associateId: string = ''; 
  holidays: Holiday[] = [];

  constructor(private leaveService: LeaveService) {}

  ngOnInit() {
    // Grab the logged-in user's ID from local storage
    if (!this.associateId) {
       this.associateId = localStorage.getItem('loggedInUser') || '';
    }
    
    if (this.associateId) {
      this.leaveService.getUpcomingHolidays(this.associateId).subscribe({
        next: (data) => this.holidays = data,
        error: (err) => console.error('Failed to fetch holidays', err)
      });
    }
  }
}