import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { RuleService } from 'src/app/Services/rule.service';

@Component({
  selector: 'app-modal-rule',
  templateUrl: './modal-rule.component.html',
  styleUrls: ['./modal-rule.component.css']
})
export class ModalRuleComponent implements OnInit {
  form: FormGroup
  isUpdate: boolean;

  constructor(
    public dialogRef: MatDialogRef<ModalRuleComponent>, private ruleService: RuleService,
    private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) {

    if (data != null) {
      if (data.id != undefined)
        this.isUpdate = true;
    }
  }

  ngOnInit(): void {
    this.initForm(this.data)
  }
  initForm(data: any) {
    this.form = new FormGroup({
      id: new FormControl(data != undefined ? data.id : "0"),
      name: new FormControl(data != undefined ? data.name : "", Validators.required),
      status: new FormControl(data != undefined ? data.status : "ACTIVE")
    });
  }

  onNoClick(rs: any): void {
    this.dialogRef.close(rs);
  }

  confirmCreate() {
    if (this.isUpdate) {
      this.Update();
    } else {
      this.Create();
    }
  }

  Create() {
    this.spinner.show()
    this.ruleService.Create(this.form.value).subscribe((resp: any) => {
      this.spinner.hide
      this.onNoClick("OK")
    })

  }

  Update() {
    this.spinner.show();
    this.ruleService.Update(this.form.value).subscribe((resp: any) => {
      this.spinner.hide
      this.onNoClick("OK")
    })
  }

}
