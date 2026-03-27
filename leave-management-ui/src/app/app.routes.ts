import { Routes } from '@angular/router';
import { LoginComponent } from './Components/login/login.component';
import { LeaveApplyComponent } from './Components/leave-apply/leave-apply.component';
import { TeamViewComponent } from './Components/team-view/team-view.component';

export const routes: Routes = [
    // Redirect empty path to login by default
  { path: '', redirectTo: '/login', pathMatch: 'full' }, 
  
  // Define the main routes
  { path: 'login', component: LoginComponent },
  { path: 'apply', component: LeaveApplyComponent },
  { path: 'team', component: TeamViewComponent },

  // Wildcard route for a 404 page (optional, redirects to login if URL is unknown)
  { path: '**', redirectTo: '/login' }
];
