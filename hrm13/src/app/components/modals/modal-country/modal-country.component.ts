import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { CountryService } from 'src/app/Services/country.service';

@Component({
  selector: 'app-modal-country',
  templateUrl: './modal-country.component.html',
  styleUrls: ['./modal-country.component.css']
})
export class ModalCountryComponent implements OnInit {

  formCountry: FormGroup
  isUpdate: boolean;

  constructor(public dialogRef: MatDialogRef<ModalCountryComponent>, private service: CountryService,
    private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) {
    this.initForm(data)
    if (data != null)
      this.isUpdate = true;


  }
  initForm(data: any) {
    this.formCountry = new FormGroup({
      id: new FormControl(data != null ? data.id : '0'),
      name: new FormControl(data != null ? data.name : "", Validators.required),
      nameEn: new FormControl(data != null ? data.nameEn : "", Validators.required),
      code: new FormControl(data != null ? data.code : "", Validators.required),
      status: new FormControl(data != null ? data.status : "ACTIVE", Validators.required),
    });
  }
  ngOnInit(): void {
  }

  confirmCreate() {
    this.spinner.show()
    if (this.isUpdate) {
      this.service.Update(this.formCountry.value).subscribe((resp: any) => {
        if (resp === "SUCCESS") {
          this.onNoClick('OK');
          this.spinner.hide();
        }
      }, error => {
        this.spinner.hide();
        this.onNoClick('NOK');
      })
    } else {
      this.service.Create(this.formCountry.value).subscribe((resp: any) => {
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
  onNoClick(rs: any): void {
    this.dialogRef.close(rs);
  }
}
