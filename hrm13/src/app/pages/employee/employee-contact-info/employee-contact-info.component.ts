import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { EmployeeContactService } from 'src/app/Services/employee-contact.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';

@Component({
  selector: 'app-employee-contact-info',
  templateUrl: './employee-contact-info.component.html',
  styleUrls: ['./employee-contact-info.component.css']
})
export class EmployeeContactInfoComponent implements OnInit {
  form: FormGroup = new FormGroup({
    Id: new FormControl(""),
    Employee: new FormControl("", Validators.required),
    Mobile: new FormControl(""),
    Home: new FormControl(""),
    Email: new FormControl(""),
    Wa: new FormControl(""),
    Line: new FormControl(""),
    Wechat: new FormControl(""),
    Facebook: new FormControl(""),
    Twitter: new FormControl(""),
    ContactPerson: new FormControl(""),
    ContactNumber: new FormControl(""),
    ContactRelation: new FormControl(""),
    CreatedBy: new FormControl(""),
    CreatedAt: new FormControl(""),
    UpdatedBy: new FormControl(""),
    UpdatedAt: new FormControl(""),
  })


  constructor(private user: UserInfoService, private contact: EmployeeContactService,
    private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
  }

  SaveInfo(emp_id: any) {
    let date = new Date();
    this.form.patchValue({
      Employee: emp_id,
      CreatedAt: date,
      CreatedBy: this.user.GetUsername(),
      UpdatedAt: date,
      UpdatedBy: this.user.GetUsername(),
    })

    this.contact.NewContact(this.form.value).subscribe((resp: any) => {
      console.log('NewContact', resp)
      this.form.patchValue({ Id: resp.id })
    }, error => {
      this.spinner.hide();
    })
  }

}
