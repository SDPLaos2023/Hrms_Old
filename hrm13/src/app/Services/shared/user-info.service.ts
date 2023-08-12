import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CookieService } from 'ngx-cookie-service';
import { UitlsService } from './uitls.service';
const helper = new JwtHelperService();

@Injectable({
  providedIn: 'root'
})
export class UserInfoService {
  emp: any;

  constructor(private cookies: CookieService, private util: UitlsService) { }

  username: string
  displayname: string
  displayPositionName: string = ""
  homebranch: string = "C00001"

  GetUsername() {
    let usernamekey = this.util.encryptUsingAES256("username")
    let username = this.cookies.get(usernamekey)
    return JSON.parse(JSON.parse(this.util.decryptUsingAES256(username)));
  }



  GetLogginInfo() {

    let session = null;

    let jwt = this.cookies.get(this.util.encryptUsingAES256("token"))
    if (jwt != null) {

      const decodedToken = helper.decodeToken(jwt);
      this.emp = decodedToken.employee
      session = decodedToken.employee
    }

    return session
  }

  GetUserLoginInfo() {

    let session = null;

    let jwt = this.cookies.get(this.util.encryptUsingAES256("token"))
    if (jwt != null) {
      const decodedToken = helper.decodeToken(jwt);
      session = decodedToken.username
    }

    return session
  }

  GetEmployeeIdInfo() {

    let session = null;

    let jwt = this.cookies.get(this.util.encryptUsingAES256("token"))
    if (jwt != null) {
      const decodedToken = helper.decodeToken(jwt);
      let emp = decodedToken.employee
      let role = decodedToken.role
      console.log('role?', role)
      session = emp//.employee
    }

    return session
  }

  GetRoleID() {

    let session = null;

    let jwt = this.cookies.get(this.util.encryptUsingAES256("token"))
    if (jwt != null) {
      const decodedToken = helper.decodeToken(jwt);
      let role = decodedToken.role
      session = role//.employee
    }

    return session
  }

  GetNameLa() {
    let session = null;
    let jwt = this.cookies.get(this.util.encryptUsingAES256("token"))
    if (jwt != null) {
      const decodedToken = helper.decodeToken(jwt);
      let name = decodedToken.employeefullnamela
      session = name//.employee
    }

    return session
  }

  GetNameEn() {
    let session = null;
    let jwt = this.cookies.get(this.util.encryptUsingAES256("token"))
    if (jwt != null) {
      const decodedToken = helper.decodeToken(jwt);
      let name = decodedToken.employeefullnameen
      session = name//.employee
    }

    return session
  }

  GetDeptCode() {
    let session = "D";
    let jwt = this.cookies.get(this.util.encryptUsingAES256("token"))
    if (jwt != null) {
      const decodedToken = helper.decodeToken(jwt);
      let dept = decodedToken.dept
      if (dept != null)
        session = dept.Department//.employee
    }

    return session
  }

  GetSectionCode() {
    let session = "S";
    let jwt = this.cookies.get(this.util.encryptUsingAES256("token"))
    if (jwt != null) {
      const decodedToken = helper.decodeToken(jwt);
      let dept = decodedToken.dept
      if (dept != null)
        session = dept.Section//.employee
    }

    return session
  }
  GetUserInfo() {
    let session = null;
    let jwt = this.cookies.get(this.util.encryptUsingAES256("token"))
    if (jwt != null) {
      const decodedToken = helper.decodeToken(jwt);
      let user = decodedToken.user
      if (user != null)
        session = user
    }

    return session
  }
  GetFpUserId() {
    let session = null;
    let jwt = this.cookies.get(this.util.encryptUsingAES256("token"))
    if (jwt != null) {
      const decodedToken = helper.decodeToken(jwt);
      let user = decodedToken.fpuser
      if (user != null)
        session = user
    }

    return session
  }

}
