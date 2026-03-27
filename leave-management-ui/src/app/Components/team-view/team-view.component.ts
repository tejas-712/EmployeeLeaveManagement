import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LeaveRequest } from '../../Models/leave-req';
import { LeaveService } from '../../Services/leave';


@Component({
  selector: 'app-team-view',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './team-view.component.html',
  styleUrls: ['./team-view.component.css']
})
export class TeamViewComponent implements OnInit {
  leaves: LeaveRequest[] = [];
  isLoading: boolean = true;

  constructor(private leaveService: LeaveService) {}

  ngOnInit() {
    this.fetchLeaves();
  }

  fetchLeaves() {
    this.leaveService.getAllLeaves().subscribe({
      next: (data) => {
        this.leaves = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Failed to fetch leaves', err);
        this.isLoading = false;
      }
    });
  }

  // Maps the single letter codes to full words for the UI
  getAbsenceTypeName(code: string): string {
    switch(code) {
      case 'V': return 'Vacation';
      case 'S': return 'Sick Leave';
      case 'P': return 'Personal Day';
      default: return code;
    }
  }

  downloadReport() {
    this.leaveService.downloadExcel().subscribe((blob: Blob) => {
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = 'LeaveTracker.xlsx';
      document.body.appendChild(a);
      a.click();
      window.URL.revokeObjectURL(url);
      a.remove();
    });
  }
}