import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CookieService } from 'ngx-cookie-service';
import { UitlsService } from './shared/uitls.service';
const helper = new JwtHelperService();

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private util: UitlsService, private cookies: CookieService) { }

  public isAuthenticated(): boolean {
    let tokenkey = this.util.encryptUsingAES256("token");
    const token = this.cookies.get(tokenkey);
    // console.log("is token ?", token)
    return !helper.isTokenExpired(token);
  }
}
