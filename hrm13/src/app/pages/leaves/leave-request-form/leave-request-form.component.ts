import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { AnnualLeaveTypeService } from 'src/app/Services/annual-leave-type.service';
import { DepartmentService } from 'src/app/Services/department.service';
import { EmployeeLeaveSettingService } from 'src/app/Services/employee-leave-setting.service';
import { HolidaySeittingService } from 'src/app/Services/holiday-seitting.service';
import { SectionService } from 'src/app/Services/section.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-leave-request-form',
  templateUrl: './leave-request-form.component.html',
  styleUrls: ['./leave-request-form.component.css']
})
export class LeaveRequestFormComponent implements OnInit {
  condition: string | null;
  departments: any[] = [];
  sections: any[] = [];
  form: FormGroup
  leavetypes: any[] = [];

  constructor(private page: PageDataService,
    private service: EmployeeLeaveSettingService,
    private user: UserInfoService,
    private dservice: DepartmentService,
    private sservice: SectionService,
    private lservice: AnnualLeaveTypeService,
    private hservice: HolidaySeittingService,
    private route: ActivatedRoute,
    private router: Router,
    private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    this.page.pagename = "ການຂໍລາພັກ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> Attendances </li> <li class="breadcrumb-item active" >' + this.page.pagename + ' </li>'
    const routeParams = this.route.snapshot.paramMap;
    this.condition = routeParams.get('condition');
    this.initForm()

    if (this.condition == 'employee') {
      this.form.patchValue({
        employee: this.user.GetUserInfo().Employee,
        employeeName: this.user.GetNameLa(),
      })
    }
    this.dservice.GetList().subscribe((resp: any) => {
      this.departments.length = 0;
      this.departments = resp;

      let d = this.user.GetDeptCode();
      if (this.condition == 'employee') {
        let dept = this.departments.filter(x => x.id == d);

        this.form.patchValue({
          department: d,
          departmentName: dept[0].name,
        })

      }
    });
    this.sservice.GetList().subscribe((resp: any) => {
      this.sections.length = 0;
      this.sections = resp;
      if (this.condition == 'employee') {
        let s = this.user.GetSectionCode();
        let section = this.sections.filter(x => x.id == s);
        this.form.patchValue({
          section: s,
          sectionName: section[0].name,
        })
      }
    });

    this.lservice.GetList().subscribe((resp: any) => {
      this.leavetypes.length = 0
      this.leavetypes = resp
    });

  }
  initForm() {
    this.form = new FormGroup({
      employee: new FormControl(""),
      employeeName: new FormControl("", Validators.required),
      nameEn: new FormControl("", Validators.required),
      departmentName: new FormControl(""),
      department: new FormControl(""),
      section: new FormControl(""),
      sectionName: new FormControl(""),
      leavetype: new FormControl("LP"),
      dateFrom: new FormControl(""),
      dateTo: new FormControl(""),
      remark: new FormControl(""),
      status: new FormControl("ACTIVE", Validators.required),
    });
  }


  testSave() {

    Swal.fire({
      title: 'ຕ້ອງການບັນທຶກຂໍ້ມູນແທ້ບໍ່',
      text: 'ກົດປຸ່ມດຳເນີນການຕໍເພື່ອບັນທຶກ',
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'ດຳເນີນການຕໍ່',
      cancelButtonText: 'ຍົກເລີກ'

    }).then((result: any) => {
      if (result.value) {
        this.spinner.show();
        let form = {
          id: null,
          employee: this.form.value.employee,
          leaveType: this.form.value.leavetype,
          datefrom: this.form.value.dateFrom,
          dateto: this.form.value.dateTo,
          total: 0,
          needApproval: 1,
          needHrApproval: 1,
          approvedBy: "",
          hrApprovedBy: "",
          approvalNote: "",
          hrApprovalNote: "",
          createdAt: new Date(),
          createdBy: this.user.GetUsername(),
          updatedAt: new Date(),
          updatedBy: this.user.GetUsername(),
          remark: this.form.value.remark,
          fpUserId: "",
          company: "C00001",
          status: this.form.value.status,
        }
        this.service.CreateLeaveRequest(form).subscribe((resp: any) => {
          this.spinner.hide();
          console.log(resp)
          if (this.condition == 'employee')
            this.router.navigate(["leave-request/employee"])
        })

      }

    })



  }




}
