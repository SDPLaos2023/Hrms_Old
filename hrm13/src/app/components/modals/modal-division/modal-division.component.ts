import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { DivisionService } from 'src/app/Services/division.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';

@Component({
  selector: 'app-modal-division',
  templateUrl: './modal-division.component.html',
  styleUrls: ['./modal-division.component.css']
})
export class ModalDivisionComponent implements OnInit {
  fromDivision: FormGroup
  isUpdate: boolean;

  constructor(public dialogRef: MatDialogRef<ModalDivisionComponent>,
    private user: UserInfoService,
    private divisionService: DivisionService, private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) {
    this.initForm(data)
    if (data != null)
      this.isUpdate = true;


  }
  initForm(data: any) {
    this.fromDivision = new FormGroup({
      id: new FormControl(data != null ? data.id : '0'),
      name: new FormControl(data != null ? data.name : "", Validators.required),
      nameEn: new FormControl(data != null ? data.nameEn : "", Validators.required),
      code: new FormControl(data != null ? data.code : "", Validators.required),
      status: new FormControl(data != null ? data.status : "ACTIVE", Validators.required),
      company: new FormControl(data != null ? data.company : this.user.homebranch),
      parent: new FormControl(null),
    });
  }

  ngOnInit(): void {
  }
  onNoClick(rs: any): void {
    this.dialogRef.close(rs);
  }

  confirmCreateDepartment() {
    this.spinner.show()
    if (this.isUpdate) {
      this.divisionService.Update(this.fromDivision.value).subscribe((resp: any) => {
        if (resp === "SUCCESS") {
          this.onNoClick('OK');
          this.spinner.hide();
        }
      }, error => {
        this.spinner.hide();
        this.onNoClick('NOK');
      })
    } else {
      this.divisionService.Create(this.fromDivision.value).subscribe((resp: any) => {
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
