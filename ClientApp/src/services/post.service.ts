import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, forkJoin, map, switchMap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserDTO } from 'src/models/UserDTO.model';
import { PostComments } from 'src/models/post-comments.model';
import { Post } from 'src/models/post.model';
import { UserAttributesService } from './user-attributes.service';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  private readonly url = "Post";

  constructor(private httpClient: HttpClient, private userAttributesService: UserAttributesService) { }

  public getAllPosts(): Observable<Post[]> {
    return this.httpClient.get<Post[]>(`${environment.apiUrl}/${this.url}`).pipe(
      switchMap(posts => {
        const userIds = posts.map(post => post.userId);
        const uniqueUserIds = Array.from(new Set(userIds)); 
        const userRequests = uniqueUserIds.map(userId =>
          this.userAttributesService.getUserAttributesById(userId)
        );
        return forkJoin(userRequests).pipe(
          map(users => {
            // Create a map of user ids to user objects
            const userMap = new Map<string, UserDTO>();
            users.forEach(user => userMap.set(user.userId, user));
  
            // Assign the user details to each post
            posts.forEach(post => {
              const user = userMap.get(post.userId);
              if (user) {
                post.user = user;
              }
            });
  
            return posts;
          })
        );
      })
    );
  }
  

  public getPostById(id: string): Observable<Post> {
    return this.httpClient.get<Post>(`${environment.apiUrl}/${this.url}/${id}`);
  }

  public getCommentsForPost(postId: string): Observable<PostComments[]> {
    return this.httpClient.get<PostComments[]>(`${environment.apiUrl}/${this.url}/${postId}/comments`);
  }

  public createPost(postToAdd: Post): Observable<Post> {
    return this.httpClient.post<Post>(`${environment.apiUrl}/${this.url}`, postToAdd);
  }

  public updatePost(id: string, updatedPost: Post): Observable<Post> {
    return this.httpClient.put<Post>(`${environment.apiUrl}/${this.url}/${id}`, updatedPost);
  }

  public deletePost(id: string): Observable<void> {
    return this.httpClient.delete<void>(`${environment.apiUrl}/${this.url}/${id}`);
  }

}
