import { Component, OnInit, NgModule} from '@angular/core';
import { SignalRService } from '../service/signalrservice';
import { FormsModule } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatFormField, MatInput, MatLabel } from '@angular/material/input';
import { MatDivider } from '@angular/material/divider';
import { MatList, MatListItem } from '@angular/material/list';

@Component({
  selector: 'app-component-signal-r',
  imports: [FormsModule, MatInput, MatButton, MatFormField, MatLabel, MatDivider, MatList, MatListItem],
  templateUrl: './component-signal-r.html',
  styleUrl: './component-signal-r.scss',
})
export class ComponentSignalR implements OnInit {
  message: string = '';
  messages: string[] = [];

  constructor(private signalRService: SignalRService) { }

  ngOnInit(): void {
    this.signalRService.startConnection();
    this.signalRService.addWinnerNotificationListener((message: string) => {
      this.messages.push(message);
    });
  }

  sendMessage(): void {
    if (this.message.trim() !== '') {
      this.signalRService.sendWinnerNotification(this.message);
      this.message = '';
    }
  }
 
}
