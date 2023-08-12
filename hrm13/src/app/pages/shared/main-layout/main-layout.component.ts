import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.css']
})
export class MainLayoutComponent implements OnInit {
  body = document.getElementsByTagName('body')[0];
  role: any;



  constructor(private spinner: NgxSpinnerService, private user: UserInfoService) {
    // this.body.classList.add("hold-transition");
    //this.spinner.show();
    this.role = this.user.GetRoleID()
    console.log('this.role in left', this.role)
  }

  ngOnInit(): void {
    // this.spinner.show()
    window.addEventListener("keyup", disableF5);
    window.addEventListener("keydown", disableF5);
    function disableF5(e: any) {
      if ((e.which || e.keyCode) == 116) e.preventDefault();
    };

    setTimeout(() => {
      this.spinner.hide()
    }, 4000);
  }

}
