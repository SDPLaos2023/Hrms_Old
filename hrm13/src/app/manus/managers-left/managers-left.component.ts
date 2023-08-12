import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { NgxSpinnerService } from 'ngx-spinner';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { UitlsService } from 'src/app/Services/shared/uitls.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-managers-left',
  templateUrl: './managers-left.component.html',
  styleUrls: ['./managers-left.component.css']
})
export class ManagersLeftComponent implements OnInit {
  body = document.getElementsByTagName('body')[0];
  username: any
  uu: any
  emp: any;
  constructor(public user: UserInfoService,
    private router: Router,
    private page: PageDataService, private util: UitlsService, private cookies: CookieService,
    private spinner: NgxSpinnerService) { }
  ngAfterViewInit(): void {

  }

  ngOnInit(): void {
    this.body.classList.add("hold-transition");
    let usernamekey = this.util.encryptUsingAES256("username")
    this.username = this.cookies.get(usernamekey)
    this.user.displayname = JSON.parse(JSON.parse(this.util.decryptUsingAES256(this.username))) + "::" + this.user.GetNameLa();
    this.uu = this.user.GetEmployeeIdInfo()
  }

  confirmSignOut() {
    const dailogSwal = Swal.mixin({
      customClass: {
        title: 'laoweb',
        confirmButton: 'btn btn-success',
        cancelButton: 'btn btn-danger'
      },
      buttonsStyling: true
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
        this.cookies.deleteAll();

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
    this.router.navigate(["/"]);
  }


}
