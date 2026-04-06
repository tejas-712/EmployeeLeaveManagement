import { Routes } from '@angular/router';
import { LoginComponent } from './features/login/login.component';
import { LeaveApplyComponent } from './features/leave-apply/leave-apply.component';
import { TeamViewComponent } from './features/team-view/team-view.component';
import { AddEmployeeComponent } from './features/add-employee/add-employee.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';

export const routes: Routes = [
    // Redirect empty path to login by default
  { path: '', redirectTo: '/login', pathMatch: 'full' }, 
  
  // Define the main routes
  { path: 'login', component: LoginComponent },
  { path: 'apply', component: LeaveApplyComponent },
  { path: 'team', component: TeamViewComponent },
  { path: 'add-employee', component: AddEmployeeComponent },
  { path: 'dashboard', component: DashboardComponent },


  
  { path: '**', redirectTo: '/login' }
];
