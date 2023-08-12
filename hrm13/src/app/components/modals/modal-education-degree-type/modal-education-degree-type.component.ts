import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { EducationDegreeTypeService } from 'src/app/Services/education-degree-type.service';

@Component({
  selector: 'app-modal-education-degree-type',
  templateUrl: './modal-education-degree-type.component.html',
  styleUrls: ['./modal-education-degree-type.component.css']
})
export class ModalEducationDegreeTypeComponent implements OnInit {
  form: FormGroup
  isUpdate: boolean;
  constructor(public dialogRef: MatDialogRef<ModalEducationDegreeTypeComponent>,
    private service: EducationDegreeTypeService, private spinner: NgxSpinnerService,
    @Inject(MAT_DIALOG_DATA) public data: any) {

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
