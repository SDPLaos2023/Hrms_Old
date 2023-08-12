import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { ModalSelectEmployeeComponent } from 'src/app/modals/modal-select-employee/modal-select-employee.component';
import { DepartmentService } from 'src/app/Services/department.service';
import { DivisionService } from 'src/app/Services/division.service';
import { EmployeeService } from 'src/app/Services/employee.service';
import { EncrDecrService } from 'src/app/Services/encr-decr.service';
import { RoleService } from 'src/app/Services/role.service';
import { RuleItemService } from 'src/app/Services/rule-item.service';
import { RuleService } from 'src/app/Services/rule.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { UserService } from 'src/app/Services/user.service';
import Swal from 'sweetalert2'

import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';


export interface Roles {
  id: string;
  user: string;
  role: string;
}

const ELEMENT_DATA: Roles[] = []

@Component({
  selector: 'app-form-user',
  templateUrl: './form-user.component.html',
  styleUrls: ['./form-user.component.css']
})
export class FormUserComponent implements OnInit, AfterViewInit {
  roles: any[] = [];
  rules: any[] = [];
  list: any[] = [];
  departments: any[] = [];
  divisions: any[] = [];
  displayedColumns: string[] = ['rolename'];
  dataSource = new MatTableDataSource<Roles>(ELEMENT_DATA);

  @ViewChild(MatPaginator) paginator: MatPaginator;

  form: FormGroup = new FormGroup({});
  isUpdate: any;
  user_id: any = "";
  randomPassword: string;
  authUser: any;

  initForm() {
    this.form = new FormGroup({
      id: new FormControl("0"),
      username: new FormControl("", Validators.required),
      password: new FormControl("", Validators.required),
      employee: new FormControl("", Validators.required),
      role: new FormControl("ROLE_USERS", Validators.required),
      division: new FormControl({ value: "DV", disabled: true }),
      status: new FormControl("ACTIVE"),
      isChangePwd: new FormControl(true),
      department: new FormControl({ value: "D", disabled: true }),
      name: new FormControl(""),
    })

  }

  constructor(private page: PageDataService,
    private user: UserService, public dialog: MatDialog,
    private spinner: NgxSpinnerService, private divisionService: DivisionService,
    private route: ActivatedRoute,
    private roleService: RoleService,
    private dept: DepartmentService, private encrdecr: EncrDecrService,
    private ruleItemService: RuleItemService, private emp: EmployeeService

  ) {
    const routeParams = this.route.snapshot.paramMap;
    this.user_id = routeParams.get('user_id')
    if (this.user_id != '' && this.user_id != null && this.user_id != undefined) {
      this.LoadUserInfo(this.user_id);
    }

  }

  LoadUserInfo(user_id: string) {

    this.user.Get(user_id).subscribe((resp: any) => {
      console.log('(user info)', resp)
      this.isUpdate = true;
      this.initForm();

      this.LoadEmployeeInfo(resp.employee)
      this.form.patchValue({
        id: resp.id,
        username: resp.username,
        password: "**************",
        employee: resp.employee,
        role: resp.role,
        rule: resp.rule,
        status: resp.status,
        isChangePwd: false
      })

      // this.RuleChange(resp.rule)

    })

  }
  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;

  dtOptions: any = {}//DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();
  ngOnInit(): void {

    this.dtElement


    this.page.pagename = "ເພິ່ມຜູ້ໃຊ້ໃຫມ່"
    if (this.user_id != '' && this.user_id != null && this.user_id != undefined) {
      this.page.pagename = "ອັບເດດຂໍ້ມູນຜູ້ໃຊ້"
      this.isUpdate = true;


    }

    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> ຂໍ້ມູນຜູ້ໃຊ້ລະບົບ </li> <li class="breadcrumb-item active" > ' + this.page.pagename + ' </li>'
    this.initForm()
    this.LoadRoles();
    this.LoadDivisions();
    this.LoadDepartment()

  }

  LoadDepartment() {
    this.dept.GetList().subscribe((resp: any) => {
      this.departments.length = 0
      resp.forEach((e: any) => {
        if (e.id != 'D') { this.departments.push(e) }
      })
    })
  }

  LoadDivisions() {
    this.divisionService.GetList().subscribe((resp: any) => {
      this.divisions.length = 0;
      let divisionResp = resp
      divisionResp.forEach((e: any) => {
        if (e.id != 'DV') { this.divisions.push(e) }
      })
    })
  }

  LoadRoles() {
    this.roleService.GetList().subscribe((resp: any) => {
      this.roles = [];
      this.roles = resp
    });
  }

  openDialog() {
    const dialogRef = this.dialog.open(ModalSelectEmployeeComponent, {
      width: '1080px'
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result != "CLOSE" && result != undefined) {
        this.LoadEmployeeInfo(result)
      }
    });
  }

  LoadEmployeeInfo(empId: any) {

    this.emp.GetEmployee(empId).subscribe((resp: any) => {

      let employment: any = ""
      if (resp.tbemployeeEmployments.length > 0) {
        employment = resp.tbemployeeEmployments[0].department
      }
      this.form.patchValue({
        employee: resp.id,
        name: resp.name,
        department: employment,
        username: empId,
        password: "1234"
      })
    })
  }

  Create() {
    this.spinner.hide()
    Swal.fire({
      title: 'ຢືນຢັນການສ້າງຜູ້ໃຊ້ໃຫມ່',
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

        let l = this.form.value
        let encr = this.encrdecr.encryptData(l.password)

        let param = {
          id: l.id,
          username: l.username,
          password: encr,
          employee: l.employee,
          rule: l.rule,
          role: l.role,
          isChangePwd: true,
          status: l.status
        }
        this.user.Create(param).subscribe((resp: any) => {
          this.spinner.hide()
          Swal.fire({
            title: 'ສ້າງຜູ້ໃຊ້ໃຫມ່ສຳເລັດ',
            text: "",
            icon: 'success',

          })
        })
      }
    })

  }
  Update() {

    this.spinner.hide()
    Swal.fire({
      title: 'ຢືນຢັນການອັບເດດຂໍ້ມູນຜູ້ໃຊ້',
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

        let l = this.form.value

        let param = {
          id: l.id,
          username: l.username,
          password: "",
          employee: l.employee,
          rule: l.rule,
          role: l.role,
          isChangePwd: false,
          status: l.status
        }

        this.user.Update(param).subscribe((resp: any) => {
          this.spinner.hide()

          Swal.fire({
            title: 'ການອັບເດດຂໍ້ມູນຜູ້ໃຊ້ສຳເລັດ',
            text: "",
            icon: 'success',

          })
        })
      }
    })


  }

  SaveChangePassword() {
    Swal.fire({
      title: 'ຢືນຢັນການປ່ຽນລະຫັດຜ່ານ',
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

        this.user.Get(this.user_id).subscribe((resp: any) => {
          this.authUser = resp;
          let newPassword = this.form.value.password;
          if (this.authUser != null) {
            let encr = this.encrdecr.encryptData(newPassword)
            this.authUser.password = encr
            this.user.ChangePassword(this.authUser).subscribe((resp: any) => {
              this.spinner.hide()

              Swal.fire({
                title: 'ການປ່ຽນລະຫັດຜ່ານສຳເລັດ',
                text: "",
                icon: 'success',
              })
            })
          }
        });


      }
    })

  }


  makeid() {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < 8; i++) {
      result += characters.charAt(Math.floor(Math.random() *
        charactersLength));
    }
    this.randomPassword = result;
    this.form.patchValue({
      password: result
    })
  }



}
