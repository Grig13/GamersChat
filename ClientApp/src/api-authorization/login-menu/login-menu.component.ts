import { Component, HostListener, OnInit } from '@angular/core';
import { AuthorizeService } from '../authorize.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-login-menu',
  templateUrl: './login-menu.component.html',
  styleUrls: ['./login-menu.component.css']
})
export class LoginMenuComponent implements OnInit {
  public isAuthenticated?: Observable<boolean>;
  public userName?: Observable<string | null | undefined>;
  public userProfilePicture?: Observable<string | null>;
  public isDropdownOpen = false;

  constructor(private authorizeService: AuthorizeService) { }

  ngOnInit() {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
    this.userProfilePicture = this.authorizeService.getUserProfilePicture()
      .pipe(map(imagePath => imagePath || 'assets/profile-placeholder.png'));
  }


  toggleDropdown(): void {
    this.isDropdownOpen = !this.isDropdownOpen;
  }
  
}
