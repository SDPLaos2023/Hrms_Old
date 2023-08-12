import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { Allowance } from 'src/app/models/allowance.model';
import { AllowanceService } from 'src/app/Services/allowance.service';
import { EmployeeAllowanceService } from 'src/app/Services/employee-allowance.service';

@Component({
  selector: 'app-modal-employee-allownce',
  templateUrl: './modal-employee-allownce.component.html',
  styleUrls: ['./modal-employee-allownce.component.css']
})
export class ModalEmployeeAllownceComponent implements OnInit {
  form: FormGroup
  constructor(private allowanceService: AllowanceService, private empAllowanceService: EmployeeAllowanceService,
    public dialogRef: MatDialogRef<ModalEmployeeAllownceComponent>,
    private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) {

  }

  ngOnInit(): void {
    this.LoadIdType()
    this.initForm(this.data)
  }

  initForm(data: any) {
    let date = new Date()
    let dated = date.toLocaleDateString()
    this.form = new FormGroup({
      id: new FormControl(data.id != undefined ? data.id : "0"),
      employee: new FormControl(data.employee != undefined ? data.employee : "0"),
      allowance: new FormControl(data.allowance != undefined ? data.allowance : "AL"),
      rate: new FormControl(data.rate != undefined ? data.rate : "0"),
      status: new FormControl(data.status != undefined ? data.status : "ACTIVE"),
      createdAt: new FormControl(data.createdAt != undefined ? data.createdAt : date),
      createdBy: new FormControl(data.createdBy != undefined ? data.createdBy : "admin"),
      updatedAt: new FormControl(data.updatedAt != undefined ? data.updatedAt : date),
      updatedBy: new FormControl(data.updatedBy != undefined ? data.updatedBy : "admin"),
      allowanceNavigation: new FormControl(),
    });
  }

  allowances: Allowance[] = []
  LoadIdType() {
    this.allowanceService.GetListAllowance();
    this.allowanceService._allowanceList.subscribe(element => {
      this.allowances.push(element)
    })
  }
  confirmCreate() {
    this.spinner.show()
    let f = this.form.value
    this.allowanceChange(f.allowance)


    if (f.employee.startsWith("TEMP") && f.id.startsWith("TEMP")) {
      let ei = JSON.stringify(this.form.value)
      this.onNoClick(ei);
      this.spinner.hide();
    } else {
      console.log('9', f)
      if (f.employee.startsWith("E") && f.id.startsWith("TEMP")) {
        this.empAllowanceService.Create(this.form.value).subscribe((resp: any) => {
          console.log('resp', resp)
          let ei = JSON.stringify(this.form.value)
          this.onNoClick(ei);
          this.spinner.hide();
        }, error => {
          console.log('error', error)
        });
      } else if (f.employee.startsWith("E") && f.id.startsWith("EA")) {
        this.empAllowanceService.Update(this.form.value).subscribe((resp: any) => {
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
  allowanceChange(id: any) {
    this.allowances.forEach(element => {
      if (element.id == id) {
        this.form.patchValue({ allowanceNavigation: element })
      }
    })
  }

  onNoClick(rs: any): void {
    this.dialogRef.close(rs);
  }

}
