import { Injectable } from '@angular/core';
import { Message } from 'src/models/message.model';


@Injectable({
  providedIn: 'root'
})
export class MessagingService {
  private readonly storageKey = 'messages';

  constructor() { }

  sendMessage(message: Message): void {
    const messages = this.getMessagesFromStorage();
    messages.push(message);
    this.saveMessagesToStorage(messages);
  }

  getMessagesByRecipient(recipientId: string): Message[] {
    const messages = this.getMessagesFromStorage();
    return messages.filter(msg => msg.recipientId === recipientId);
  }

  private getMessagesFromStorage(): Message[] {
    const messagesString = localStorage.getItem(this.storageKey);
    return messagesString ? JSON.parse(messagesString) : [];
  }

  private saveMessagesToStorage(messages: Message[]): void {
    const messagesString = JSON.stringify(messages);
    localStorage.setItem(this.storageKey, messagesString);
  }
}
