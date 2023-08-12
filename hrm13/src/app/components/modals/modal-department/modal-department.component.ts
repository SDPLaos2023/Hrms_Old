import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { DepartmentService } from 'src/app/Services/department.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-modal-department',
  templateUrl: './modal-department.component.html',
  styleUrls: ['./modal-department.component.css']
})
export class ModalDepartmentComponent implements OnInit {
  ok = 'OK'
  formDept: FormGroup
  isUpdate: boolean;
  constructor(public dialogRef: MatDialogRef<ModalDepartmentComponent>,
    private user: UserInfoService,
    private departmentService: DepartmentService, private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) {
    this.initForm(data)
    if (data != null)
      this.isUpdate = true;

    console.log('(tag)', data)
  }
  initForm(data: any) {
    this.formDept = new FormGroup({
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
      this.departmentService.Update(this.formDept.value).subscribe((resp: any) => {
        if (resp === "SUCCESS") {
          this.onNoClick('OK');
          this.spinner.hide();
        }
      }, error => {
        this.spinner.hide();
        this.onNoClick('NOK');
      })
    } else {
      this.departmentService.Create(this.formDept.value).subscribe((resp: any) => {
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
