import { Component, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { LeaveService } from '../../../Services/leaveservice';


@Component({
  selector: 'app-chat',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ChatComponent {
  isOpen = false;
  userInput = '';
  selectedDate = '';
  leaveType = 'C'; 
  
  // Starting message
  messages: any[] = [{ text: "Hi! I am your Leave Assistant. Try asking me to 'plan leave'.", isUser: false }];

  constructor(
    private http: HttpClient, 
    private leaveService: LeaveService,
    private cdr: ChangeDetectorRef 
  ) {}

  toggleChat() {
    this.isOpen = !this.isOpen;
  }

  sendMessage() {
    if (!this.userInput.trim()) return;

    
    this.messages.push({ text: this.userInput, isUser: true });
    
    const payload = { 
       associateId: localStorage.getItem('loggedInUser') || '9090', 
       message: this.userInput 
    };

    this.userInput = ''; 

    
    this.http.post('https://localhost:7068/api/chat/message', payload).subscribe((res: any) => {
       
       this.messages.push({ 
          text: res.botReply, 
          isUser: false, 
          action: res.actionRequired 
       });
       this.cdr.detectChanges(); 
    });
  }

  // Runs when they click the Confirm button inside the chat
  submitLeaveFromChat() {
    const request = {
      associateId: localStorage.getItem('loggedInUser') || '9090',
      leaveDate: this.selectedDate,
      absenceType: this.leaveType
    };

    // Use your exact existing service!
    this.leaveService.applyLeave(request).subscribe({
      next: (res) => {
        this.messages.push({ text: "✅ Success! I booked your leave and updated your balances.", isUser: false });
        this.cdr.detectChanges();
      },
      error: (err) => {
        this.messages.push({ text: "❌ Sorry, I couldn't book that. You might already have leave on that day.", isUser: false });
        this.cdr.detectChanges();
      }
    });
  }
}