import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { ModalSelectEmployeeComponent } from 'src/app/modals/modal-select-employee/modal-select-employee.component';
import { FpUserService } from 'src/app/Services/fp-user.service';
import { ModalSelectFpNoneUserComponent } from '../modal-select-fp-none-user/modal-select-fp-none-user.component';

@Component({
  selector: 'app-modal-fp-user',
  templateUrl: './modal-fp-user.component.html',
  styleUrls: ['./modal-fp-user.component.css']
})
export class ModalFpUserComponent implements OnInit {

  form: FormGroup
  isUpdate: boolean;
  constructor(public dialogRef: MatDialogRef<ModalFpUserComponent>,
    public dialog: MatDialog,

    private service: FpUserService, private spinner: NgxSpinnerService,
    @Inject(MAT_DIALOG_DATA) public data: any) {

    this.initForm(data)
    if (data != null) {
      this.isUpdate = data.id != "0" ? true : false;
    }
  }

  ngOnInit(): void {
  }
  initForm(data: any) {


    this.form = new FormGroup({
      id: new FormControl(data != null ? data.id : '0'),
      fpId: new FormControl(data != null ? data.fpId : "FM", Validators.required),
      fpUserName: new FormControl(data != null ? data.fpUserName : "", Validators.required),
      fpUserId: new FormControl(data != null ? data.fpUserId : "0", Validators.required),
      fpRole: new FormControl(data != null ? data.fpRole : "0", Validators.required),
      employee: new FormControl(data != null ? data.employee : "E", Validators.required),
    });
  }
  onNoClick(rs: any): void {
    this.dialogRef.close(rs);
  }

  confirmCreate() {
    this.spinner.show()
    if (this.isUpdate) {
      this.service.Update(this.form.value).subscribe((resp: any) => {
        if (resp === "SUCCESS") {
          this.onNoClick('OK');
          this.spinner.hide();
        }
      }, error => {
        this.spinner.hide();
        this.onNoClick('NOK');
      })
    } else {
      this.service.Create(this.form.value).subscribe((resp: any) => {
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

  openDialog() {
    let data = { fpId: this.form.value.fpId };

    const dialogRef = this.dialog.open(ModalSelectFpNoneUserComponent, {
      width: '1080px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result != "CLOSE" && result != undefined) {
        this.form.patchValue({
          employee: result
        })
      }
    });
  }

}
