import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserDTO } from 'src/models/UserDTO.model';

@Injectable({
  providedIn: 'root'
})
export class UserAttributesService {

  private readonly url = "User";

  constructor(private httpClient: HttpClient) { }

  public getLoggedInUserData(): Observable<UserDTO>{
    return this.httpClient.get<UserDTO>(`${environment.apiUrl}/${this.url}`);
  }

  public getUserAttributesById(userId: string): Observable<UserDTO> {
    return this.httpClient.get<UserDTO>(`${environment.apiUrl}/${this.url}/${userId}`);
  }

}
