import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserDTO } from 'src/models/UserDTO.model';

@Injectable({
  providedIn: 'root'
})
export class UserAttributesService {

  private readonly url = "UserAttributes";

  constructor(private httpClient: HttpClient) { }

  public getAttributes(userId: string): Observable<UserDTO>{
    return this.httpClient.get<UserDTO>(`${environment.apiUrl}/${this.url}/${userId}`);
  }

  public setAttributes(attributes: UserDTO): Observable<UserDTO>{
    return this.httpClient.post<UserDTO>(`${environment.apiUrl}/${this.url}`, attributes);
  }

  public updateAttributes(userId: string, attributes: UserDTO): Observable<UserDTO>{
    return this.httpClient.patch<UserDTO>(`${environment.apiUrl}/{this.url}/${userId}`, attributes);
  }
}
