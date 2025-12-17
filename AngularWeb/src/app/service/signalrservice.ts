import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection: signalR.HubConnection | null = null;

  constructor() { }

  public startConnection(): void {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5138/winnerNotificationHub') // Adjust URL as needed
      .withAutomaticReconnect()
      .build();

    this.hubConnection.start()
      .then(() => console.log('SignalR Connection Started'))
      .catch(err => console.log('Error while starting SignalR connection: ' + err));
  }

  public addWinnerNotificationListener(callback: (message: string) => void): void {
    if (this.hubConnection) {
      this.hubConnection.on('ReceiveWinnerNotification', (message: string) => {
        callback(message);
      });
    } else {
      console.error('Hub connection is not established.');
    } 
  }

  public sendWinnerNotification(message: string): void {
    if (this.hubConnection) {
      this.hubConnection.invoke('SendWinnerNotification', message)
        .catch(err => console.error('Error while sending winner notification: ' + err));
    } else {
      console.error('Hub connection is not established.');
    } 
  }
}
