import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { UitlsService } from 'src/app/Services/shared/uitls.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-top',
  templateUrl: './top.component.html',
  styleUrls: ['./top.component.css']
})
export class TopComponent implements OnInit {

  constructor(private util: UitlsService, private cookies: CookieService, private user: UserInfoService) { }
  username: any
  displayName: any

  ngOnInit(): void {

    let usernamekey = this.util.encryptUsingAES256("username")
    this.username = this.cookies.get(usernamekey)
    this.user.displayname = JSON.parse(JSON.parse(this.util.decryptUsingAES256(this.username))) + "::" + this.user.GetNameLa();
    this.displayName = this.user.displayname
  }

}
