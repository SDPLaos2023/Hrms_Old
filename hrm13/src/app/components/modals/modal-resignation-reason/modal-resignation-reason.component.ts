import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { ResignationReasonService } from 'src/app/Services/resignation-reason.service';

@Component({
  selector: 'app-modal-resignation-reason',
  templateUrl: './modal-resignation-reason.component.html',
  styleUrls: ['./modal-resignation-reason.component.css']
})
export class ModalResignationReasonComponent implements OnInit {
  formWt: FormGroup
  isUpdate: boolean;
  constructor(public dialogRef: MatDialogRef<ModalResignationReasonComponent>,
    private services: ResignationReasonService, private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) {

    this.initForm(data)
    if (data != null)
      this.isUpdate = true;
  }

  ngOnInit(): void {
  }
  initForm(data: any) {
    this.formWt = new FormGroup({
      id: new FormControl(data != null ? data.id : '0'),
      name: new FormControl(data != null ? data.name : "", Validators.required),
      nameEn: new FormControl(data != null ? data.nameEn : "", Validators.required),
      code: new FormControl(data != null ? data.code : "", Validators.required),
      status: new FormControl(data != null ? data.status : "ACTIVE", Validators.required),
    });
  }
  onNoClick(rs: any): void {
    this.dialogRef.close(rs);
  }

  confirmCreate() {
    this.spinner.show()
    if (this.isUpdate) {
      this.services.Update(this.formWt.value).subscribe((resp: any) => {
        if (resp === "SUCCESS") {
          this.onNoClick('OK');
          this.spinner.hide();
        }
      }, error => {
        this.spinner.hide();
        this.onNoClick('NOK');
      })
    } else {
      this.services.Create(this.formWt.value).subscribe((resp: any) => {
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
