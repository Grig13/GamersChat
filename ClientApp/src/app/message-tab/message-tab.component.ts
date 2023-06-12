import { Component, Input, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { Subject, take } from 'rxjs';
import { AuthorizeService, IUser } from 'src/api-authorization/authorize.service';
import { Message } from 'src/models/message.model';
import { User } from 'src/models/user.model';
import { SignalrService } from 'src/services/signalr.service';

@Component({
  selector: 'app-message-tab',
  templateUrl: './message-tab.component.html',
  styleUrls: ['./message-tab.component.css']
})
export class MessageTabComponent implements OnInit {

  private connection: HubConnection;
  public messages: string[] = [];
  public user: string = '';
  public message: string = '';

  constructor(){
    this.connection = new HubConnectionBuilder()
      .withUrl('https://localhost:7143/chat')
      .build();
  }

  async ngOnInit() {
    this.connection.on('ReceiveMessage', (user, message) => {
      this.messages.push(`${user}: ${message}`);
    });

    try {
      await this.connection.start();
      console.log('Connected to SignalR hub');
    } catch (error) {
      console.error('Failed to connect to SignalR hub', error);
    }
  }

  async sendMessage(user: string, message: string) {
    if (!user || !message) return;
    await this.connection.invoke('SendMessage', user, message);
  }

 
}
