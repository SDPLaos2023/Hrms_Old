import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { Province } from 'src/app/models/province.model';
import { DistrictService } from 'src/app/Services/district.service';
import { ProvinceService } from 'src/app/Services/province.service';

@Component({
  selector: 'app-modal-district',
  templateUrl: './modal-district.component.html',
  styleUrls: ['./modal-district.component.css']
})
export class ModalDistrictComponent implements OnInit {

  form: FormGroup
  isUpdate: boolean;
  provinces: Province[] = []
  constructor(public dialogRef: MatDialogRef<ModalDistrictComponent>,
    private service: DistrictService, private provService: ProvinceService, private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) {

    this.initForm(data)
    if (data.action == null || data.action == undefined)
      this.isUpdate = true;
  }

  ngOnInit(): void {
    this.provService.GetList().subscribe((resp: any) => {
      this.provinces = resp as Province[]


    })
  }

  initForm(data: any) {
    this.form = new FormGroup({
      id: new FormControl(data != null ? data.id : '0'),
      name: new FormControl(data != null ? data.name : "", Validators.required),
      nameEn: new FormControl(data != null ? data.nameEn : "", Validators.required),
      code: new FormControl(data != null ? data.code : "", Validators.required),
      status: new FormControl(data != null ? data.status : "ACTIVE", Validators.required),
      province: new FormControl(data != null ? data.province : "0", Validators.required),
    });
  }

  onNoClick(rs: any): void {
    this.dialogRef.close(this.form.value.province);
  }

  confirmCreate() {
    this.spinner.show()
    if (this.isUpdate) {
      this.service.Update(this.form.value).subscribe((resp: any) => {
        if (resp === "SUCCESS") {
          this.onNoClick(this.form.value.province);
          this.spinner.hide();
        }
      }, error => {
        this.spinner.hide();
        this.onNoClick(this.form.value.province);
      })
    } else {
      this.service.Create(this.form.value).subscribe((resp: any) => {
        if (resp === "SUCCESS") {
          this.onNoClick(this.form.value.province);
          this.spinner.hide();
        }
      }, error => {
        this.spinner.hide();
        this.onNoClick(this.form.value.province);
      })
    }

  }
}
