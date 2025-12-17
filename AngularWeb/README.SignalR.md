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