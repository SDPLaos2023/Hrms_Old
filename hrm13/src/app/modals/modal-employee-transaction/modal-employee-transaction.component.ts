import { DatePipe } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { TransactionType } from 'src/app/models/transaction-type.model';
import { TransactionTypeService } from 'src/app/Services/transaction-type.service';

@Component({
  selector: 'app-modal-employee-transaction',
  templateUrl: './modal-employee-transaction.component.html',
  styleUrls: ['./modal-employee-transaction.component.css']
})
export class ModalEmployeeTransactionComponent implements OnInit {
  form: FormGroup
  constructor(private transType: TransactionTypeService,
    private datepipe: DatePipe,
    public dialogRef: MatDialogRef<ModalEmployeeTransactionComponent>,
    private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) {

  }
  ngOnInit(): void {
    this.LoadTransactionType();
    this.initForm(this.data)
  }

  transactionTypes: TransactionType[] = []
  LoadTransactionType() {
    this.transType.GetSections()
    this.transType._transactionTypeList.subscribe((resp: any) => {
      this.transactionTypes.push(resp)
    })
  }

  GetDate(today: any) {
    let actionDate = this.datepipe.transform(today, 'yyyy-MM-dd');
    return actionDate;
  }

  initForm(data: any) {
    let date = new Date()
    this.form = new FormGroup({
      id: new FormControl(data.id != undefined ? data.id : "0"),
      employee: new FormControl(data.employee != undefined ? data.employee : "0"),
      transactionType: new FormControl(data.transactionType != undefined ? data.transactionType : ""),
      effectiveDate: new FormControl(data.effectiveDate != undefined ? this.GetDate(data.effectiveDate) : this.GetDate(date)),
      description: new FormControl(data.description != undefined ? data.description : ""),
      createdAt: new FormControl(data.createdAt != undefined ? this.GetDate(data.createdAt) : this.GetDate(date)),
      createdBy: new FormControl(data.createdBy != undefined ? data.createdBy : "admin"),
      updatedAt: new FormControl(data.updatedAt != undefined ? this.GetDate(data.updatedAt) : this.GetDate(date)),
      updatedBy: new FormControl(data.updatedBy != undefined ? data.updatedBy : "admin"),
      transactionTypeNavigation: new FormControl()
    });
  }

  confirmCreate() {
    this.spinner.show()
    let f = this.form.value
    let ei = JSON.stringify(this.form.value)
    this.onNoClick(ei);
    this.spinner.hide();
  }

  onNoClick(rs: any): void {
    this.dialogRef.close(rs);
  }

}
