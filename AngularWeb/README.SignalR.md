## SignalR

SignalR is used in the Math28 game to display winner message that are sent from the API.

### Set up SignalR on Angular App 
You need to install npm package for SignalR

```bash
npm install @microsoft/signalr
```

### Add Service to create connection

Create a service that connects to SignalR Hub you created in the API. This is done using the *signalR.HubConnection* class from SignalR package.

View Sample code below:
```javascript
 public startConnection(): void {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5138/winnerNotificationHub') // Adjust URL as needed
      .withAutomaticReconnect()
      .build();

    this.hubConnection.start()
      .then(() => console.log('SignalR Connection Started'))
      .catch(err => console.log('Error while starting SignalR connection: ' + err));
  }
```

## Subscribe to Notification
Once you have connect you can subscribe to receive and send notification. 

Component can the
```csharp
  public addWinnerNotificationListener(callback: (message: string) => void): void {
    if (this.hubConnection) {
      this.hubConnection.on('ReceiveWinnerNotification', (message: string) => {
        callback(message);
      });
    } else {
      console.error('Hub connection is not established.');
    } 
  }
```
If the Hub exposes an api endpoint to send messages, this endpoint can be invoked in the client application.
```csharp
public sendWinnerNotification(message: string): void {
    if (this.hubConnection) {
      this.hubConnection.invoke('SendWinnerNotification', message)
        .catch(err => console.error('Error while sending winner notification: ' + err));
    } else {
      console.error('Hub connection is not established.');
    } 
  }
```

## To test SignalR

Navigate to [http://localhost:4200/test](http://localhost:4200/test), on this page you can send message and view received messages.