import { UpperCasePipe } from '@angular/common';
import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CookieService } from 'ngx-cookie-service';
import { NgxSpinnerService } from 'ngx-spinner';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { UitlsService } from 'src/app/Services/shared/uitls.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';
import Swal from 'sweetalert2'
// import * as $ from 'jquery';
// import * as AdminLte from 'admin-lte';

const helper = new JwtHelperService();

@Component({
  selector: 'app-left',
  templateUrl: './left.component.html',
  styleUrls: ['./left.component.css']
})
export class LeftComponent implements OnInit, AfterViewInit {
  body = document.getElementsByTagName('body')[0];
  username: any
  uu: any
  emp: any;
  constructor(public user: UserInfoService,
    private router: Router,
    private page: PageDataService, private util: UitlsService, private cookies: CookieService, private spinner: NgxSpinnerService) { }
  ngAfterViewInit(): void {

  }

  ngOnInit(): void {

    this.body.classList.add("hold-transition");

    let usernamekey = this.util.encryptUsingAES256("username")
    this.username = this.cookies.get(usernamekey)
    this.user.displayname = JSON.parse(JSON.parse(this.util.decryptUsingAES256(this.username)));
    this.uu = this.user.GetEmployeeIdInfo()
    console.log('(this.uu)', this.uu)

  }

  confirmSignOut() {
    const dailogSwal = Swal.mixin({
      customClass: {
        title: 'laoweb',
        confirmButton: 'btn btn-success',
        cancelButton: 'btn btn-danger right'
      },
      buttonsStyling: false
    })

    dailogSwal.fire({
      title: "ຕ້ອງການອອກຈາກລະບົບຫລືບໍ່",
      text: 'ກົດປຸ່ມ ດຳເນີນການຕໍ່ ເພື່ອຢືນຢັນການອອກຈາກລະບົບ',
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'ດຳເນີນການຕໍ່',
      cancelButtonText: 'ຍົກເລີກ'
    }).then((result: any) => {
      if (result.value) {
        console.log("Confirm")
        this.spinner.show()
        this.doSignOut()
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        console.log("cancel")
      }
    })
  }
  doSignOut() {
    this.page.clearSession();
    this.spinner.hide();
    this.cookies.deleteAll();
    this.router.navigate(["login"]);
  }
}
