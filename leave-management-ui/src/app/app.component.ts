import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet, RouterModule } from '@angular/router';
import { LeaveService } from './Services/leave';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterModule],
  template: `
    <nav class="top-nav">
      <div class="nav-brand">
        <strong>LeaveManager</strong> Pro
      </div>
      
      <div class="nav-actions">
        <ng-container *ngIf="leaveService.isLoggedIn$ | async; else loggedOut">
          <div class="nav-links">
            <a routerLink="/apply" routerLinkActive="active-link" class="nav-item">Apply Leave</a>
            <a routerLink="/team" routerLinkActive="active-link" class="nav-item">Team View</a>
          </div>
          <button class="btn-outline" (click)="leaveService.logout()">Logout</button>
        </ng-container>
        
        <ng-template #loggedOut>
          <a routerLink="/login" class="btn-primary" style="text-decoration: none;">Login</a>
        </ng-template>
      </div>
    </nav>
    
    <main class="main-content">
      <router-outlet></router-outlet>
    </main>
  `,
  styles: [`
    .nav-actions { display: flex; align-items: center; gap: 20px; }
    .nav-links { display: flex; gap: 15px; }
    .nav-item { text-decoration: none; color: #495057; font-weight: 500; padding: 0.5rem; transition: color 0.2s; }
    .nav-item:hover { color: #0056b3; }
    .active-link { color: #0056b3; border-bottom: 2px solid #0056b3; }
  `]
})
export class AppComponent {
  constructor(public leaveService: LeaveService) {}
}