import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { UserDTO } from 'src/models/UserDTO.model';
import { Message } from 'src/models/message.model';
import { MessagingService } from 'src/services/message.service';
import { UserAttributesService } from 'src/services/user-attributes.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  userDetails!: UserDTO;
  userProfilePicture$!: string;
  defaultUserProfile$!: string;
  userId!: string;
  followedUserId!: string;
  followerUserId!: string;
  isFollowing!: boolean;
  isFriends: boolean = false;
  messages: Message[] = [];
  newMessageContent = '';
  displayName: string = '';

  constructor(
    private route: ActivatedRoute,
    private userAttributesService: UserAttributesService,
    private messageService: MessageService,
    private messagingService: MessagingService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.userId = params.id;
      this.followedUserId = this.userId;
      this.userAttributesService.getUserAttributesById(this.userId).subscribe((user) => {
        this.userDetails = user;
        this.userProfilePicture$ = this.userDetails.profileImageUrl;
      });
    });
    this.userAttributesService.getLoggedInUserData().subscribe((user) => {
      this.followerUserId = user.userId;
      this.isFollowing = this.userAttributesService.checkFriendStatus(this.userId);
      this.isFriends = this.isFollowing;
    });
    this.isFollowing = this.userAttributesService.checkFriendStatus(this.userId);
    this.loadMessages();
    console.log(this.followedUserId);
    console.log(this.followerUserId);

    window.addEventListener('storage', this.storageEventListener.bind(this));
  }

  ngOnDestroy(): void {
    window.removeEventListener('storage', this.storageEventListener.bind(this));
  }

  storageEventListener(event: StorageEvent): void {
    if (event.key === 'newMessage') {
      this.loadMessages();
    }
  }

  loadMessages(): void {
    this.messages = this.messagingService.getMessagesByRecipient(this.followedUserId);
  }

  addFriend(): void {
    const friend: UserDTO = {
      userId: this.followedUserId,
      email: this.userDetails.email,
      profileImageUrl: this.userDetails.profileImageUrl,
      firstName: this.userDetails.firstName,
      lastName: this.userDetails.lastName,
      age: this.userDetails.age,
      city: this.userDetails.city
    };

    if (!this.userAttributesService.checkFriendStatus(this.followedUserId)) {
      this.show();
      this.userAttributesService.addFriend(friend);
      this.isFriends = true;
    }
  }
  show() {
    this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Friend added successfully' });
  }

  sendMessage(): void {
    if (this.newMessageContent) {
      const message: Message = {
        senderId: this.followerUserId,
        recipientId: this.followedUserId,
        content: this.newMessageContent,
        timestamp: new Date()
      };

      this.messagingService.sendMessage(message);
      const uniqueKey = `newMessage_${this.followedUserId}`;
      localStorage.setItem(uniqueKey, JSON.stringify(message));

      this.newMessageContent = '';
    }
    location.reload();
  }

  setDisplayName(userId: string){
    if(userId == '17b7cdc2-5774-4c72-9de1-cab5d195e55e') {
      this.displayName = 'Grig Mazureanu';
    }
    if(userId = '37059408-f35b-4e2a-9723-ecc903ca3452'){
      this.displayName = 'Iuliana Aristap';
    }
    if(userId = '55f85253-8722-44ed-b78d-2e2e12603e48'){
      this.displayName = 'ADMIN';
    }
    if(userId = 'aa479116-7193-49d6-acde-a28b4c0e81a3'){
      this.displayName = 'Oana Roman';
    }
  }

}
