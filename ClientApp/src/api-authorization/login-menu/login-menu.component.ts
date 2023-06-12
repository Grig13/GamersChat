import { Component, HostListener, OnInit } from '@angular/core';
import { AuthorizeService, IUser } from '../authorize.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { UserAttributesService } from 'src/services/user-attributes.service';
import { UserDTO } from 'src/models/UserDTO.model';

@Component({
  selector: 'app-login-menu',
  templateUrl: './login-menu.component.html',
  styleUrls: ['./login-menu.component.css']
})
export class LoginMenuComponent implements OnInit {
  public isAuthenticated?: Observable<boolean>;
  public userName?: Observable<string | null | undefined>;
  public userProfilePicture?: string;
  public isDropdownOpen = false;
  user$!: Observable<IUser | null>;
  defaultProfilePicture!: string;
  userDetails!: UserDTO;

  constructor(private authorizeService: AuthorizeService, private userService: UserAttributesService) { }

  ngOnInit() {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
    this.user$ = this.authorizeService.getUser();
    this.defaultProfilePicture = 'https://cdn.dribbble.com/users/6142/screenshots/5679189/media/1b96ad1f07feee81fa83c877a1e350ce.png?compress=1&resize=400x300&vertical=top';
    this.userService.getLoggedInUserData()
      .subscribe(user => {
        this.userDetails = user;
        this.userProfilePicture = this.userDetails.profileImageUrl;
      });
  }


  toggleDropdown(): void {
    this.isDropdownOpen = !this.isDropdownOpen;
  }
  
}
