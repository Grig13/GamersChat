import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserDTO } from 'src/models/UserDTO.model';

@Injectable({
  providedIn: 'root'
})
export class UserAttributesService {

  private readonly url = 'User';
  private readonly friendListKey = 'friends';

  private friendsSubject: BehaviorSubject<UserDTO[]> = new BehaviorSubject<UserDTO[]>([]);
  public friends$: Observable<UserDTO[]> = this.friendsSubject.asObservable();

  constructor(private httpClient: HttpClient) {
    const storedFriends = localStorage.getItem(this.friendListKey);
    if (storedFriends) {
      const friends = JSON.parse(storedFriends);
      this.friendsSubject.next(friends);
    }
  }

  public getLoggedInUserData(): Observable<UserDTO> {
    return this.httpClient.get<UserDTO>(`${environment.apiUrl}/${this.url}`);
  }

  public getUserAttributesById(userId: string): Observable<UserDTO> {
    return this.httpClient.get<UserDTO>(`${environment.apiUrl}/${this.url}/${userId}`);
  }

  public addFriend(friend: UserDTO): void {
    const currentFriends = this.friendsSubject.getValue();
    const updatedFriends = [...currentFriends, friend];
    this.friendsSubject.next(updatedFriends);

    this.saveFriendsToStorage(updatedFriends);
  }

  public checkFriendStatus(userId: string): boolean {
    const friendList = this.getFriendListFromStorage();
    return friendList.some((friend) => friend.userId === userId);
  }

  private saveFriendsToStorage(friends: UserDTO[]): void {
    localStorage.setItem(this.friendListKey, JSON.stringify(friends));
  }

  private getFriendListFromStorage(): UserDTO[] {
    const friendList = localStorage.getItem(this.friendListKey);
    return friendList ? JSON.parse(friendList) : [];
  }
}
