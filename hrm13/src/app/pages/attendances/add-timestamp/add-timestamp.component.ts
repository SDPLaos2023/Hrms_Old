import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { TimesheetService } from 'src/app/Services/timesheet.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-add-timestamp',
  templateUrl: './add-timestamp.component.html',
  styleUrls: ['./add-timestamp.component.css']
})
export class AddTimestampComponent implements OnInit {
  form: any
  formaddtime: any

  clockIn: any
  clockOut: any
  attDate: any
  fpUserId: any
  fpId: any
  attCode: any
  department: any
  departmentName: any
  section: any
  sectionName: any
  employee: any
  employeeName: any
  list: any[] = []


  constructor(private page: PageDataService,
    private timesheetService: TimesheetService,
    private spinner: NgxSpinnerService,
    private datePipe: DatePipe,
  ) { }

  ngOnInit(): void {

    this.page.pagename = "ປ້ຳໂມງແທນ "// + this.employeeId //+ " " + resp.name
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> Attendances </li> <li class="breadcrumb-item active" >' + this.page.pagename + ' </li>'
    var date = new Date;
    this.form = new FormGroup({
      fpUserId: new FormControl("", Validators.required),
      attDate: new FormControl(date, Validators.required)
    });

    this.formaddtime = new FormGroup({
      clockIn: new FormControl("00:00:00"),
      clockOut: new FormControl("00:00:00"),
      attDate: new FormControl(date),
      fpUserId: new FormControl(""),
      fpId: new FormControl(""),
      attCode: new FormControl("999"),
      department: new FormControl(""),
      departmentName: new FormControl(""),
      section: new FormControl(""),
      sectionName: new FormControl(""),
      employee: new FormControl(""),
      employeeName: new FormControl("")
    });
  }

  inquiry() {
    this.spinner.show()
    this.timesheetService.AddTimeInq(this.form.value).subscribe((resp: any) => {
      console.log("resp", resp)
      this.spinner.hide()
      var today = this.datePipe.transform(resp.attDate, 'yyyy-MM-dd');
      resp.attDate = today
      this.formaddtime = resp


      this.clockIn = resp.clockIn;
      this.clockOut = resp.clockOut;
      this.attDate = today;
      this.fpUserId = resp.fpUserId;
      this.fpId = resp.fpId;
      this.attCode = resp.attCode;
      this.department = resp.department;
      this.departmentName = resp.departmentName;
      this.section = resp.section;
      this.sectionName = resp.sectionName;
      this.employee = resp.employee;
      this.employeeName = resp.employeeName;
      // };

      this.list.push({
        clockIn: resp.clockIn,
        clockOut: resp.clockOut,
        attDate: today,
        fpUserId: resp.fpUserId,
        fpId: resp.fpId,
        attCode: resp.attCode,
        department: resp.department,
        departmentName: resp.departmentName,
        section: resp.section,
        sectionName: resp.sectionName,
        employee: resp.employee,
        employeeName: resp.employeeName,
      })

    }, error => {
      setTimeout(() => {
        this.spinner.hide()
      }, 1000);

    })

  }

  save() {
    // var params = {
    //   clockIn: this.clockIn,
    //   clockOut: this.clockOut,
    //   attDate: this.attDate,
    //   fpUserId: this.fpUserId,
    //   fpId: this.fpId,
    //   attCode: this.attCode,
    //   department: this.department,
    //   departmentName: this.departmentName,
    //   section: this.section,
    //   sectionName: this.sectionName,
    //   employee: this.employee,
    //   employeeName: this.employeeName,
    // }

    const dailogSwal = Swal.mixin({
      customClass: {
        title: 'laoweb',
        confirmButton: 'btn btn-success',
        cancelButton: 'btn btn-danger'
      },
      buttonsStyling: true
    });

    dailogSwal.fire({
      title: "ການເພິ່ມປ້ຳໂມງແທນ",
      text: 'ຕ້ອງການບັນທຶກການປ້ຳໂມງນີ້ບໍ່',
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'ບັນທຶກ',
      cancelButtonText: 'ຍົກເລີກ'
    }).then((result: any) => {
      if (result.value) {
        console.log("Confirm")
        this.timesheetService.AddTime(this.list).subscribe((resp: any) => {
          console.log(resp)
          dailogSwal.fire({
            title: "ການບັນທຶກປ້ຳໂມງສຳເລັດ",
            text: '',
            icon: 'success',
            showCancelButton: false,
            confirmButtonText: 'OK',
            cancelButtonText: 'ຍົກເລີກ'
          }).then((rs) => {
            this.clockIn = "";
            this.clockOut = "";
            this.attDate = "";
            this.fpUserId = "";
            this.fpId = "";
            this.attCode = "";
            this.department = "";
            this.departmentName = "";
            this.section = "";
            this.sectionName = "";
            this.employee = "";
            this.employeeName = "";
            this.list = [];
          });



        })
      }
    });
  }

  delete(item: any) {
    this.list.splice(item, 1)
  }

}
