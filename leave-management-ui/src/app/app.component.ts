import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from './core/layout/navbar/navbar/navbar.component';
import { ChatComponent } from './core/shared/components/chat/chat.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent,ChatComponent], // Add Navbar here
  templateUrl: './app.component.html',      // Notice it is templateUrl!
  styleUrls: ['./app.component.css']        // Notice it is styleUrls!
})
export class AppComponent {

}