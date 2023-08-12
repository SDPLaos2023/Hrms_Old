import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { NationlityAndRaceService } from 'src/app/Services/nationlity-and-race.service';

@Component({
  selector: 'app-modal-race',
  templateUrl: './modal-race.component.html',
  styleUrls: ['./modal-race.component.css']
})
export class ModalRaceComponent implements OnInit {

  formRace: FormGroup
  isUpdate: boolean;

  constructor(public dialogRef: MatDialogRef<ModalRaceComponent>, private service: NationlityAndRaceService,
    private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) {
    this.initForm(data)
    if (data != null)
      this.isUpdate = true;


  }
  initForm(data: any) {
    this.formRace = new FormGroup({
      id: new FormControl(data != null ? data.id : '0'),
      name: new FormControl(data != null ? data.name : "", Validators.required),
      nameEn: new FormControl(data != null ? data.nameEn : "", Validators.required),
      code: new FormControl(data != null ? data.code : "", Validators.required),
      status: new FormControl(data != null ? data.status : "ACTIVE", Validators.required),
    });
  }
  ngOnInit(): void {
  }

  confirmCreateRace() {
    this.spinner.show()
    if (this.isUpdate) {
      this.service.Update("Races", this.formRace.value).subscribe((resp: any) => {
        if (resp === "SUCCESS") {
          this.onNoClick('OK');
          this.spinner.hide();
        }
      }, error => {
        this.spinner.hide();
        this.onNoClick('NOK');
      })
    } else {
      this.service.Create("Races", this.formRace.value).subscribe((resp: any) => {
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
