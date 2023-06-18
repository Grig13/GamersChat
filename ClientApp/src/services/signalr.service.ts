import { EventEmitter, Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { take } from 'rxjs';
import { AuthorizeService, IUser } from 'src/api-authorization/authorize.service';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {

  private hubConnection!: HubConnection;

  constructor(private authorizeService: AuthorizeService) {
    this.authorizeService.getAccessToken().subscribe((accessToken: string) => {
      if (accessToken) {
        this.hubConnection = new HubConnectionBuilder()
          .withUrl('https://localhost:7143/chat', {
            accessTokenFactory: () => accessToken
          })
          .build();
      }
    });
  }
  

  startConnection(): Promise<void> {
    return this.hubConnection.start();
  }

  stopConnection(): Promise<void> {
    return this.hubConnection.stop();
  }

  onReceiveMessage(callback: (user: string, message: string) => void): void {
    this.hubConnection.on('ReceiveMessage', callback);
  }

  sendMessage(message: string): Promise<void> {
    return this.hubConnection.invoke('SendMessage', message);
  }
}
