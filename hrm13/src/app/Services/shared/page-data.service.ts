import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { UitlsService } from './uitls.service';
import { UserInfoService } from './user-info.service';

@Injectable({
  providedIn: 'root'
})
export class PageDataService {
  //userxxx: any;

  constructor(private cookies: CookieService, private router: Router, private util: UitlsService, private user: UserInfoService) {

    //this.userxxx = this.user.GetLogginInfo()

  }

  pagename: string = ""
  breadcrumb: string = ""

  param1: any
  param2: any
  param3: any
  param4: any
  param5: any



  clearSession() {

    let usernamekey = this.util.encryptUsingAES256("username")
    let displaynamekey = this.util.encryptUsingAES256("displayname")
    let tokenkey = this.util.encryptUsingAES256("token")
    let homebranch = this.util.encryptUsingAES256("homebranch")
    this.cookies.deleteAll();
    // this.cookies.delete(tokenkey)
    // this.cookies.delete(usernamekey)
    // this.cookies.delete(displaynamekey)
    // this.cookies.delete(homebranch)

    setTimeout(() => {
      this.router.navigate(["/login"]);
    }, 200);
  }
}
