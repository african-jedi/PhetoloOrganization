import { ChangeDetectorRef, Component, OnInit, signal } from '@angular/core';
import { SignalRService } from '../service/signalrservice';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatFormField, MatInput, MatLabel } from '@angular/material/input';
import { MatDivider } from '@angular/material/divider';
import { MatList, MatListItem } from '@angular/material/list';
import { toSignal } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-component-signal-r',
  imports: [FormsModule, MatInput, MatButton, MatFormField, MatLabel, MatDivider, MatList, MatListItem, ReactiveFormsModule],
  templateUrl: './component-signal-r.html',
  styleUrl: './component-signal-r.scss',
})
export class ComponentSignalR implements OnInit {
  //message= signal<string>('');
  messages = signal<string[]>([]);
  nameControl = new FormControl('');
  message = toSignal(this.nameControl.valueChanges, { initialValue: '' });

  constructor(private signalRService: SignalRService, private cdr: ChangeDetectorRef) {
    this.nameControl.valueChanges.subscribe(() => {
      this.cdr.markForCheck();
    });
  }

  ngOnInit(): void {
    this.signalRService.startConnection();
    this.signalRService.addWinnerNotificationListener((message: string) => {
      const value = this.message() ?? '';
      this.messages().push(value); 
      this.cdr.markForCheck();

      console.log('Received message=' + value);
    });
  }

  sendMessage(): void {
    const value = this.message() ?? '';
    if (value.trim() !== '') {
      this.signalRService.sendWinnerNotification(value);
      //this.message='';
      console.log('message=' + value);
    }
  }

}
