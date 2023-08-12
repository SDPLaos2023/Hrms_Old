import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Location } from '@angular/common'
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { NgxSpinnerService } from 'ngx-spinner';
// import { utils } from 'protractor';
import { Jwt } from 'src/app/models/shared/jwt.model';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { UitlsService } from 'src/app/Services/shared/uitls.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2'
import { EncrDecrService } from 'src/app/Services/encr-decr.service';
import { JwtHelperService } from "@auth0/angular-jwt";
const helper = new JwtHelperService();
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  possible = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
  lengthOfCode = 40;
  baseUrl = environment.baseUrlApi;

  constructor(public user: UserInfoService,
    private spinner: NgxSpinnerService,
    private router: Router,
    private http: HttpClient,
    private cookies: CookieService,
    private util: UitlsService,
    private page: PageDataService,
    private _location: Location,
    private encrdecr: EncrDecrService
  ) {

    let tokenkey = this.util.encryptUsingAES256("token");
    const token = this.cookies.get(tokenkey);
    if (!helper.isTokenExpired(token)) {
      this._location.back();
      return;
    }
  }
  loginForm: FormGroup = new FormGroup({});
  ngOnInit(): void {



    let usernamekey = this.util.encryptUsingAES256("username")
    let browserkey = this.util.encryptUsingAES256("browser_id")
    let browser_id = this.cookies.check(browserkey) ? this.cookies.get(browserkey) : this.makeRandom(this.lengthOfCode, this.possible);
    let username = this.cookies.check(usernamekey) ? JSON.parse(JSON.parse(this.util.decryptUsingAES256(this.cookies.get(usernamekey)))) : "";

    console.log('userkey', usernamekey);
    console.log('browserkey', browserkey);
    console.log('username', username);

    this.loginForm = new FormGroup({
      username: new FormControl(username, Validators.required),
      password: new FormControl("", Validators.required),
      rememberMe: new FormControl(false),
      browser_id: new FormControl(browser_id)
    });
  }


  makeRandom(lengthOfCode: number, possible: string) {
    let text = "";
    for (let i = 0; i < lengthOfCode; i++) {
      text += possible.charAt(Math.floor(Math.random() * possible.length));
    }
    return text;
  }

  login() {
    let l = this.loginForm.value
    let encr = this.encrdecr.encryptData(l.username + ',' + l.password)
    let param = {
      strRequest: encr
    }
    this.spinner.show();
    this.http.post(this.baseUrl + "api/Authentication/authenticate1/", param).subscribe((resp: any) => {
      this.cookies.set("testss", resp)
      this.spinner.hide();
      let jwt: Jwt = resp as Jwt
      console.log('(jwt)', jwt)
      if (jwt != null) {
        if (!helper.isTokenExpired(jwt.result)) {
          this.cookies.set(this.util.encryptUsingAES256("token"), jwt.result)//jwt.result
          this.cookies.set(this.util.encryptUsingAES256("homebranch"), "C00001")
          this.cookies.set(this.util.encryptUsingAES256("browser_id"), this.loginForm.value.browser_id)
          this.cookies.set(this.util.encryptUsingAES256("username"), this.util.encryptUsingAES256(JSON.stringify(this.loginForm.value.username)))
          this.cookies.set(this.util.encryptUsingAES256("displayname"), this.util.encryptUsingAES256(JSON.stringify(this.loginForm.value.username)))
          const decodedToken = helper.decodeToken(jwt.result);
          let role = decodedToken.role
          if (role === 'ROLE_USERS') {
            this.router.navigate(["user-profile"]).then(
              () => {
                window.location.reload();
              }
            );
          } else {
            this.router.navigate(["user-profile"]).then(
              () => {
                window.location.reload();
              }
            );
          }

        } else {

          const dailogSwal = Swal.mixin({
            customClass: {
              title: 'laoweb',
              confirmButton: 'btn btn-success',
              cancelButton: 'btn btn-danger'
            },
            buttonsStyling: true
          });

          dailogSwal.fire({
            title: "ບໍ່ສາມາດເຂົ້າສູ່ລະບົບໄດ້",
            text: 'ຊື່ຜູ້ໃຊ້ຫລືລະຫັດຜ່ານບໍ່ຖືກຕ້ອງກະລຸນາກວດສອບ',
            icon: 'warning',
            showCancelButton: false,
            confirmButtonText: 'OK',
            cancelButtonText: 'ຍົກເລີກ'
          }).then((result: any) => {
            if (result.value) {
              console.log("Confirm")
            }

          });

        }

      }
    }, error => {
      this.spinner.hide();
      const dailogSwal = Swal.mixin({
        customClass: {
          title: 'laoweb',
          confirmButton: 'btn btn-success',
          cancelButton: 'btn btn-danger'
        },
        buttonsStyling: true
      });

      dailogSwal.fire({
        title: "ບໍ່ສາມາດເຂົ້າສູ່ລະບົບໄດ້",
        text: 'ການເຊື່ອມຕໍ່ຂັດຂ້ອງ ກະລຸນາຕິດຕໍ່ຜູ້ດູແລລະບົບ',
        icon: 'warning',
        showCancelButton: false,
        confirmButtonText: 'OK',
        cancelButtonText: 'ຍົກເລີກ'
      }).then((result: any) => {
        if (result.value) {
          console.log("OK")
        }

      });
      console.error('login error', error)
      this.page.clearSession();
    })
  }

}
