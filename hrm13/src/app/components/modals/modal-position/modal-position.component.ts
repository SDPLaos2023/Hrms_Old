import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { Position } from 'src/app/models/position.model';
import { PositionService } from 'src/app/Services/position.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';

@Component({
  selector: 'app-modal-position',
  templateUrl: './modal-position.component.html',
  styleUrls: ['./modal-position.component.css']
})
export class ModalPositionComponent implements OnInit {
  positoins: Position
  isUpdate: boolean;
  formPosition: FormGroup

  constructor(public dialogRef: MatDialogRef<ModalPositionComponent>,
    private user: UserInfoService,
    private positionService: PositionService, private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) {
    this.initForm(data)
    if (data != null)
      this.isUpdate = true;


  }
  initForm(data: any) {
    this.formPosition = new FormGroup({
      id: new FormControl(data != null ? data.id : '0'),
      name: new FormControl(data != null ? data.name : "", Validators.required),
      nameEn: new FormControl(data != null ? data.nameEn : "", Validators.required),
      code: new FormControl(data != null ? data.code : "", Validators.required),
      status: new FormControl(data != null ? data.status : "ACTIVE", Validators.required),
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
      this.positionService.Update(this.formPosition.value).subscribe((resp: any) => {
        if (resp === "SUCCESS") {
          this.onNoClick('OK');
          this.spinner.hide();
        }
      }, error => {
        this.spinner.hide();
        this.onNoClick('NOK');
      })
    } else {
      this.positionService.Create(this.formPosition.value).subscribe((resp: any) => {
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
