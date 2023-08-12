import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { NationlityAndRaceService } from 'src/app/Services/nationlity-and-race.service';

@Component({
  selector: 'app-modal-nationality',
  templateUrl: './modal-nationality.component.html',
  styleUrls: ['./modal-nationality.component.css']
})
export class ModalNationalityComponent implements OnInit {
  formNationality: FormGroup
  isUpdate: boolean;

  constructor(public dialogRef: MatDialogRef<ModalNationalityComponent>, private service: NationlityAndRaceService,
    private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) {
    this.initForm(data)
    if (data != null)
      this.isUpdate = true;


  }
  initForm(data: any) {
    this.formNationality = new FormGroup({
      id: new FormControl(data != null ? data.id : '0'),
      name: new FormControl(data != null ? data.name : "", Validators.required),
      nameEn: new FormControl(data != null ? data.nameEn : "", Validators.required),
      code: new FormControl(data != null ? data.code : "", Validators.required),
      status: new FormControl(data != null ? data.status : "ACTIVE", Validators.required),
    });
  }
  ngOnInit(): void {
  }

  confirmCreateNationality() {
    this.spinner.show()
    if (this.isUpdate) {
      this.service.Update("Nationalities", this.formNationality.value).subscribe((resp: any) => {
        if (resp === "SUCCESS") {
          this.onNoClick('OK');
          this.spinner.hide();
        }
      }, error => {
        this.spinner.hide();
        this.onNoClick('NOK');
      })
    } else {
      this.service.Create("Nationalities", this.formNationality.value).subscribe((resp: any) => {
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
