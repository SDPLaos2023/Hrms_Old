import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { ModalSelectEmployeeComponent } from 'src/app/modals/modal-select-employee/modal-select-employee.component';
import { TimetableService } from 'src/app/Services/attendances/timetable.service';

@Component({
  selector: 'app-modal-time-table',
  templateUrl: './modal-time-table.component.html',
  styleUrls: ['./modal-time-table.component.css']
})
export class ModalTimeTableComponent implements OnInit {

  formWt: FormGroup
  isUpdate: boolean;
  constructor(public dialogRef: MatDialogRef<ModalTimeTableComponent>,
    private sectionService: TimetableService, private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) {

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
      name: new FormControl(data != null ? data.name : "", Validators.required),
      startIn: new FormControl(data != null ? data.startIn : "08:00", Validators.required),
      startOut: new FormControl(data != null ? data.startOut : "17:00", Validators.required),
      breakIn: new FormControl(data != null ? data.breakIn : "13:00", Validators.required),
      breakOut: new FormControl(data != null ? data.breakOut : "12:00", Validators.required),
      lateIn: new FormControl(data != null ? data.lateIn : "15", Validators.required),
      earlyOut: new FormControl(data != null ? data.earlyOut : "15", Validators.required),
      dayOfWeek: new FormControl(data != null ? data.dayOfWeek : "0123456", Validators.required),
      status: new FormControl(data != null ? data.status : "ACTIVE", Validators.required),
    });
  }
  onNoClick(rs: any): void {
    this.dialogRef.close(rs);
  }

  confirmCreate() {
    this.spinner.show()
    console.log('isUpdate', this.isUpdate)
    if (this.isUpdate) {
      this.sectionService.Update(this.formWt.value).subscribe((resp: any) => {
        if (resp === "SUCCESS") {
          this.onNoClick('OK');
          this.spinner.hide();
        }
      }, error => {
        this.spinner.hide();
        this.onNoClick('NOK');
      })
    } else {
      this.sectionService.Create(this.formWt.value).subscribe((resp: any) => {
        if (resp === "SUCCESS") {
          this.onNoClick('OK');
          this.spinner.hide();
        }
      }, error => {
        this.spinner.hide();
        this.onNoClick('NOK');
      })
    }

  }


}
