import { Component } from '@angular/core';
import { MessageService } from 'primeng/api';
import * as signalR from '@aspnet/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [MessageService]
})
export class AppComponent {

  constructor(private messageService: MessageService) { }

  ngOnInit(): void {
    const connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Information)
      .withUrl('http://localhost:5000/chat')
      .build();

    connection.start().then(() => {
      console.log('connected');
    })
      .catch((err) => {
        return console.error(err.toString());
      });

    connection.on('BroadcastMessage', (type: string, payload: string) => {
      this.messageService.add({severity: type, summary: payload, detail: 'via SignalR on Angular'});
    });
  }
}
