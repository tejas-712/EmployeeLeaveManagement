import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class AddEmployeeComponent {
  employee = {
    associateId: '',
    name: '',
    password: '',
    roleId: 0,      
    locationId: 0   
  };
  
  message = '';
  errorMessage = '';

  constructor(private http: HttpClient) {}

  onSubmit() {
    this.message = '';
    this.errorMessage = '';
    
    this.http.post<any>('https://localhost:7068/api/Auth/add', this.employee)
      .subscribe({
        next: (res) => {
          this.message = res.message || 'Employee added successfully!';
          
          // Reset the form with default numbers
          this.employee = { 
            associateId: '', 
            name: '', 
            password: '', 
            roleId: 0, 
            locationId: 0 
          };
        },
        error: (err) => {
          this.errorMessage = err.error?.message || 'Failed to add employee.';
        }
      });
  }
}