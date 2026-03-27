import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LeaveRequest } from '../Models/leave-req';


@Injectable({
  providedIn: 'root'
})
export class LeaveService {
  // 1. Split the URLs to point to the correct C# controllers
  private authUrl = 'https://localhost:7068/api/Auth'; 
  private leaveUrl = 'https://localhost:7068/api/leave'; // Points to LeaveController

  constructor(private http: HttpClient) { }

  // Auth endpoint uses authUrl
  login(associateId: string, password: string): Observable<any> {
    const params = new HttpParams()
      .set('associateId', associateId)
      .set('password', password);

    return this.http.post(`${this.authUrl}/login`, null, { params });
  }

  // Leave endpoints use leaveUrl
  applyLeave(leave: LeaveRequest): Observable<any> {
    // We remove the <LeaveRequest> type and add { responseType: 'text' }
    return this.http.post(`${this.leaveUrl}/apply`, leave, { responseType: 'text' });
  }

  getAllLeaves(): Observable<LeaveRequest[]> {
    return this.http.get<LeaveRequest[]>(`${this.leaveUrl}/all`);
  }

 downloadExcel(): Observable<Blob> {
    // Change this to point to your new 'getleaves' controller
    return this.http.get(`https://localhost:7068/api/getleaves/download`, { responseType: 'blob' });
  }
}