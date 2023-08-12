import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { FpService } from 'src/app/Services/fp.service';

@Component({
  selector: 'app-modal-fp-manager',
  templateUrl: './modal-fp-manager.component.html',
  styleUrls: ['./modal-fp-manager.component.css']
})
export class ModalFpManagerComponent implements OnInit {

  form: FormGroup
  isUpdate: boolean;
  constructor(public dialogRef: MatDialogRef<ModalFpManagerComponent>,
    private service: FpService, private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) {

    console.log('tag', data)
    this.initForm(data)
    if (data != null)
      this.isUpdate = true;
  }

  ngOnInit(): void {
  }

  initForm(data: any) {
    this.form = new FormGroup({
      id: new FormControl(data != null ? data.id : '0'),
      name: new FormControl(data != null ? data.name : "", Validators.required),
      ipAddress: new FormControl(data != null ? data.ipAddress : "", Validators.required),
      port: new FormControl(data != null ? data.port : "", Validators.required),
      mac: new FormControl(data != null ? data.mac : "", Validators.required),
      sn: new FormControl(data != null ? data.sn : "", Validators.required),
      status: new FormControl(data != null ? data.status : "ACTIVE", Validators.required),
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
}

