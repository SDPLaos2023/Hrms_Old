import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { NgxSpinnerService } from 'ngx-spinner';
import { EncrDecrService } from 'src/app/Services/encr-decr.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { UitlsService } from 'src/app/Services/shared/uitls.service';
import { UserService } from 'src/app/Services/user.service';
import Swal from 'sweetalert2'
import { JwtHelperService } from "@auth0/angular-jwt";
const helper = new JwtHelperService();
@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {
  newPassword: string = "";
  authUser: any;
  constructor(private page: PageDataService,
    private spinner: NgxSpinnerService,
    private encrdecr: EncrDecrService,
    private user: UserService, private util: UitlsService, private cookies: CookieService) {

    this.page.pagename = "ປ່ຽນລະຫັດຜ່ານ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> ຂໍ້ມູນຜູ້ໃຊ້ລະບົບ </li> <li class="breadcrumb-item active" > ' + this.page.pagename + ' </li>'
    // let usernamekey = this.util.encryptUsingAES256("token")
    // let u = this.cookies.get(usernamekey)

    let tokenkey = this.util.encryptUsingAES256("token");
    const token = this.cookies.get(tokenkey);

    if (!helper.isTokenExpired(token)) {
      const decodedToken = helper.decodeToken(token);
      this.authUser = decodedToken.user
    }

    // let userCookies = this.util.decryptUsingAES256(u)// JSON.parse(JSON.parse(this.util.decryptUsingAES256(u)));
    // console.log(userCookies);


  }

  ngOnInit(): void {
  }

  SaveChangePassword() {
    Swal.fire({
      title: 'ຢືນຢັນການປ່ຽນລະຫັດຜ່ານ',
      text: "",
      icon: 'question',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'ຕົກລົງ',
      cancelButtonText: 'ປິດ'
    }).then((result) => {
      if (result.isConfirmed) {
        this.spinner.show();

        if (this.authUser != null) {
          let encr = this.encrdecr.encryptData(this.newPassword)
          this.authUser.password = encr
          this.user.ChangePassword(this.authUser).subscribe((resp: any) => {
            console.log('(user)', resp)
            this.spinner.hide()
          })
        }
      }
    })

  }

}
