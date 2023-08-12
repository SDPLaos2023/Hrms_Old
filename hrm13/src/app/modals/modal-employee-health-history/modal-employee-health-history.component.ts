import { DatePipe } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { EmployeeHealthHistoryService } from 'src/app/Services/employee-health-history.service';

@Component({
  selector: 'app-modal-employee-health-history',
  templateUrl: './modal-employee-health-history.component.html',
  styleUrls: ['./modal-employee-health-history.component.css']
})
export class ModalEmployeeHealthHistoryComponent implements OnInit {
  form: FormGroup
  constructor(private healthService: EmployeeHealthHistoryService,
    private datepipe: DatePipe,
    public dialogRef: MatDialogRef<ModalEmployeeHealthHistoryComponent>,
    private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) {

  }
  ngOnInit(): void {
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
      location: new FormControl(data.location != undefined ? data.location : ""),
      description: new FormControl(data.description != undefined ? data.description : ""),
      status: new FormControl(data.status != undefined ? data.status : "ACTIVE"),
      filePath: new FormControl(data.filePath != undefined ? data.filePath : ""),
      dateLog: new FormControl(data.dateLog != undefined ? this.GetDate(data.dateLog) : this.GetDate(date)),
    });
  }


  confirmCreate() {
    this.spinner.show()
    let f = this.form.value

    if (f.employee.startsWith("TEMP") && f.id.startsWith("TEMP")) {
      let ei = JSON.stringify(this.form.value)
      this.onNoClick(ei);
      this.spinner.hide();
    } else {
      console.log('9', f)
      if (f.employee.startsWith("E") && f.id.startsWith("TEMP")) {
        this.healthService.Create(this.form.value).subscribe((resp: any) => {
          console.log('resp', resp)
          let ei = JSON.stringify(this.form.value)
          this.onNoClick(ei);
          this.spinner.hide();
        }, error => {
          console.log('error', error)
        });
      } else if (f.employee.startsWith("E") && f.id.startsWith("EHS")) {
        this.healthService.Update(this.form.value).subscribe((resp: any) => {
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

}
