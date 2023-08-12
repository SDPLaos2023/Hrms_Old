import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { TimetableService } from 'src/app/Services/attendances/timetable.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';

@Component({
  selector: 'app-modal-shiftmanagement',
  templateUrl: './modal-shiftmanagement.component.html',
  styleUrls: ['./modal-shiftmanagement.component.css']
})
export class ModalShiftmanagementComponent implements OnInit {


  formWt: FormGroup
  isUpdate: boolean;
  constructor(public dialogRef: MatDialogRef<ModalShiftmanagementComponent>,
    private service: TimetableService, private spinner: NgxSpinnerService,
    @Inject(MAT_DIALOG_DATA) public data: any, private usres: UserInfoService) {

    this.initForm(data)
    if (data != null) {
      console.log(data)
      this.isUpdate = true;
    }
  }

  ngOnInit(): void {
  }

  initForm(data: any) {

    this.formWt = new FormGroup({
      id: new FormControl(data != null ? data.id : '0'),
      shiftname: new FormControl(data != null ? data.shiftname : "", Validators.required),
      workingday: new FormControl(data != null ? data.workingday : ""),
      status: new FormControl(data != null ? data.status : "ACTIVE", Validators.required),
      createdAt: new FormControl(data != null ? data.createdAt : new Date()),
      createdBy: new FormControl(data != null ? data.createdBy : this.usres.GetUsername()),
      updatedAt: new FormControl(data != null ? data.updatedAt : new Date()),
      updatedBy: new FormControl(this.usres.GetUsername()),
      company: new FormControl("C00001"),
    });
  }
  onNoClick(rs: any): void {
    this.dialogRef.close(rs);
  }

  confirmCreate() {
    this.spinner.show()
    console.log('isUpdate', this.isUpdate)
    if (this.isUpdate) {
      this.service.UpdateShift(this.formWt.value).subscribe((resp: any) => {
        if (resp === "SUCCESS") {
          this.onNoClick('OK');
          this.spinner.hide();
        }
      }, error => {
        this.spinner.hide();
        this.onNoClick('NOK');
      })
    } else {
      this.service.CreateShift(this.formWt.value).subscribe((resp: any) => {
        console.log(resp)
        if (resp === "SUCCESS") {
          this.spinner.hide();
        }
      })
    }

  }


}
