import { DatePipe } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { HolidaySeittingService } from 'src/app/Services/holiday-seitting.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-modal-public-holiday',
  templateUrl: './modal-public-holiday.component.html',
  styleUrls: ['./modal-public-holiday.component.css']
})
export class ModalPublicHolidayComponent implements OnInit {
  form: FormGroup
  isUpdate: boolean = false;
  constructor(private datepipe: DatePipe,
    public dialogRef: MatDialogRef<ModalPublicHolidayComponent>, private holidayService: HolidaySeittingService,
    private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) {
    this.initForm(this.data)

    if (data != null) {
      console.log("daa", data.id)
      if (data.id != undefined)
        this.isUpdate = true;
    }


  }

  ngOnInit(): void {
    console.log('data', this.data)

  }

  confirmCreate() {
    let f = this.form.value
    if (this.isUpdate) {
      this.doUpdate();
    } else {
      this.doCreate();
    }
  }

  doUpdate() {
    Swal.fire({
      title: 'ຢືນຢັນບັນທຶກການປ່ຽນແປງ',
      text: "",
      icon: 'question',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'ຕົກລົງ',
      cancelButtonText: 'ປິດ'
    }).then((result) => {
      if (result.isConfirmed) {
        this.spinner.show();
        this.holidayService.Update(this.form.value).subscribe((resp: any) => {
          if (resp === "SUCCESS") {
            setTimeout(() => {
              this.spinner.hide()
              this.onNoClick("OK")
            }, 1000);
          }
        })
      }
    })
  }

  doCreate() {


    Swal.fire({
      title: 'ຢືນຢັນເພິ່ມວັນພັກໃຫມ່',
      text: "",
      icon: 'question',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'ຕົກລົງ',
      cancelButtonText: 'ປິດ'
    }).then((result) => {
      if (result.isConfirmed) {
        this.spinner.show();
        this.holidayService.Create(this.form.value).subscribe((resp: any) => {
          if (resp === "SUCCESS") {
            setTimeout(() => {
              this.spinner.hide()
              this.onNoClick("OK")

            }, 1000);
          }
        })
      }
    })


  }
  onNoClick(rs: any): void {
    this.dialogRef.close(rs);
  }

  GetDate(today: any) {
    let actionDate = this.datepipe.transform(today, 'yyyy-MM-dd');
    return actionDate;
  }

  initForm(data: any) {
    let date = new Date()
    this.form = new FormGroup({
      id: new FormControl(data.id != undefined ? data.id : "0"),
      date: new FormControl(data.date != undefined ? this.GetDate(data.date) : this.GetDate(date)),
      description: new FormControl(data.description != undefined ? data.description : ""),
      name: new FormControl(data.name != undefined ? data.name : "ວັນພັກລັດຖະການ"),
      isDraft: new FormControl(data.isDraft != undefined ? data.isDraft : false)
    });
  }



}
