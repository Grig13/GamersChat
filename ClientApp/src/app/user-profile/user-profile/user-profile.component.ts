import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserDTO } from 'src/models/UserDTO.model';
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

  constructor(private route: ActivatedRoute, private userAttributesService: UserAttributesService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.userId = params.id;
      this.userAttributesService.getUserAttributesById(this.userId).subscribe((user) => {
        this.userDetails = user;
        this.userProfilePicture$ = this.userDetails.profileImageUrl;
      });
    });
  }

}
