import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PostComments } from 'src/models/post-comments.model';

@Injectable({
  providedIn: 'root'
})
export class PostCommentsService {

  private readonly url = "PostComment";

  constructor(private httpClient: HttpClient) { }

  public getCommentById(id: string): Observable<PostComments> {
    return this.httpClient.get<PostComments>(`${environment.apiUrl}/${this.url}/${id}`);
  }

  public createComment(commentToAdd: PostComments): Observable<PostComments> {
    return this.httpClient.post<PostComments>(`${environment.apiUrl}/${this.url}`, commentToAdd);
  }

  public deleteComment(id: string): Observable<void> {
    return this.httpClient.delete<void>(`${environment.apiUrl}/${this.url}/${id}`);
  }
}
