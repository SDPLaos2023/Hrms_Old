import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { MaritalStatus } from 'src/app/models/marital-status.model';
import { EmployeeFamilyContactService } from 'src/app/Services/employee-family-contact.service';
import { MaritalStatusService } from 'src/app/Services/marital-status.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';

@Component({
  selector: 'app-employee-marriage-info',
  templateUrl: './employee-marriage-info.component.html',
  styleUrls: ['./employee-marriage-info.component.css']
})
export class EmployeeMarriageInfoComponent implements OnInit {
  form: FormGroup = new FormGroup({
    Id: new FormControl(""),
    Employee: new FormControl("", Validators.required),
    FatherName: new FormControl(""),
    FatherDob: new FormControl(""),
    FatherAge: new FormControl(""),
    FatherContactNumber: new FormControl(""),
    MotherName: new FormControl(""),
    MotherDob: new FormControl(""),
    MotherAge: new FormControl(""),
    MotherContactNumber: new FormControl(""),
    SpouseName: new FormControl(""),
    SpouseDob: new FormControl(""),
    SpouseAge: new FormControl(""),
    SpouseContactNumber: new FormControl(""),
    NoChildren: new FormControl(""),
    NoDaughter: new FormControl(""),
  })
  constructor(private user: UserInfoService, private contact: EmployeeFamilyContactService,
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
