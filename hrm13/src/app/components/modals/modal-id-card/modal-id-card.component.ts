import { DatePipe } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { IdCard } from 'src/app/models/id-card.model';
import { IdentityType } from 'src/app/models/identity-type.model';
import { EmployeeIdentityService } from 'src/app/Services/employee-identity.service';
import { EmployeeService } from 'src/app/Services/employee.service';
import { IdentityTypeService } from 'src/app/Services/identity-type.service';

@Component({
  selector: 'app-modal-id-card',
  templateUrl: './modal-id-card.component.html',
  styleUrls: ['./modal-id-card.component.css']
})
export class ModalIdCardComponent implements OnInit {
  form: FormGroup


  constructor(public dialogRef: MatDialogRef<ModalIdCardComponent>,
    private datepipe: DatePipe,
    private idTypeService: IdentityTypeService,
    private empIdentityService: EmployeeIdentityService,
    private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this.LoadIdType();
    this.initForm(this.data)
  }

  GetDate(today: any) {
    let actionDate = this.datepipe.transform(today, 'yyyy-MM-dd');
    return actionDate;
  }
  initForm(data: any) {
    let date = new Date()
    let dated = date.toLocaleDateString()
    this.form = new FormGroup({
      id: new FormControl(data.id != undefined ? data.id : "0"),
      employee: new FormControl(data.employee != undefined ? data.employee : "0"),
      idNumber: new FormControl(data.idNumber != undefined ? data.idNumber : ""),
      idType: new FormControl(data.idType != undefined ? data.idType : "IDT"),
      idExpiryDate: new FormControl(data.idExpiryDate != undefined ? this.GetDate(data.idExpiryDate) : this.GetDate(date)),
      idIssuedBy: new FormControl(data.idIssuedBy != undefined ? data.idIssuedBy : ""),
      idTypeNavigation: new FormControl(),
    });
  }

  idTypes: IdentityType[] = []
  LoadIdType() {
    this.idTypeService.GetListIdentity();
    this.idTypeService._idTypeList.subscribe(element => {
      this.idTypes.push(element)
    })
  }

  confirmCreate() {

    this.spinner.show()
    let f = this.form.value
    this.idTypeChange(f.idType)

    if (f.employee.startsWith("TEMP") && f.id.startsWith("TEMP")) {
      let ei = JSON.stringify(this.form.value)
      this.onNoClick(ei);
      this.spinner.hide();
    } else {
      console.log('9', f)
      if (f.employee.startsWith("E") && f.id.startsWith("TEMP")) {
        this.empIdentityService.Create(this.form.value).subscribe((resp: any) => {
          console.log('resp', resp)
          let ei = JSON.stringify(this.form.value)
          this.onNoClick(ei);
          this.spinner.hide();
        }, error => {
          console.log('error', error)
        });
      } else if (f.employee.startsWith("E") && f.id.startsWith("IDN")) {
        this.empIdentityService.Update(this.form.value).subscribe((resp: any) => {
          console.log('resp', resp)
          let ei = JSON.stringify(this.form.value)
          this.onNoClick(ei);
          this.spinner.hide();
        }, error => {
          console.log('error', error)
        });
      }
    }
  }

  onNoClick(rs: any): void {
    this.dialogRef.close(rs);
  }


  idTypeChange(id: any) {

    this.idTypes.forEach(element => {
      if (element.id == id) {
        this.form.patchValue({ idTypeNavigation: element })
      }
    })

  }

}
