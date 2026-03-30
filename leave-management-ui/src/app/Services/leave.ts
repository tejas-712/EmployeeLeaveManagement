import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';
import { LeaveRequest } from '../Models/leave-req'; // Adjust path if needed

@Injectable({
  providedIn: 'root'
})
export class LeaveService {
  private authUrl = 'https://localhost:7068/api/Auth'; 
  private leaveUrl = 'https://localhost:7068/api/leave'; 

  // --- STATE MANAGEMENT ---
  private loggedIn = new BehaviorSubject<boolean>(!!localStorage.getItem('loggedInUser'));
  isLoggedIn$ = this.loggedIn.asObservable();

  constructor(private http: HttpClient, private router: Router) { }

  // --- AUTH ENDPOINTS ---
  login(associateId: string, password: string): Observable<any> {
    const params = new HttpParams()
      .set('associateId', associateId)
      .set('password', password);

    return this.http.post(`${this.authUrl}/login`, null, { params });
  }

  setLoginState(associateId: string) {
    localStorage.setItem('loggedInUser', associateId);
    this.loggedIn.next(true); 
  }

  logout() {
    localStorage.removeItem('loggedInUser');
    this.loggedIn.next(false); 
    this.router.navigate(['/login']); 
  }

  // --- LEAVE ENDPOINTS ---
  applyLeave(leave: LeaveRequest): Observable<any> {
    return this.http.post(`${this.leaveUrl}/apply`, leave, { responseType: 'text' });
  }

  getAllLeaves(): Observable<LeaveRequest[]> {
    return this.http.get<LeaveRequest[]>(`${this.leaveUrl}/all`);
  }

  downloadExcel(): Observable<Blob> {
    return this.http.get(`https://localhost:7068/api/leave/download`, { responseType: 'blob' });
  }
}