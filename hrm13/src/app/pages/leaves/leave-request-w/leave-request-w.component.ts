import { AfterViewInit, Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { EmployeeLeaveSettingService } from 'src/app/Services/employee-leave-setting.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-leave-request-w',
  templateUrl: './leave-request-w.component.html',
  styleUrls: ['./leave-request-w.component.css']
})
export class LeaveRequestWComponent implements OnInit, AfterViewInit {
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;

  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject();
  list: any[] = []
  condition: string | null;
  leaveid: string | null;
  item: any

  timetables: any[] = [];
  form: FormGroup;
  constructor(private page: PageDataService,
    private service: EmployeeLeaveSettingService,
    private user: UserInfoService,
    private router: Router,
    private route: ActivatedRoute,
    public dialogRef: MatDialogRef<LeaveRequestWComponent>,
    private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  ngAfterViewInit(): void {
    this.dtOptions = {
      language: {
        processing: "Procesando...",
        search: "ຄົ້ນຫາ:",
        lengthMenu: "ສະແດງ _MENU_ ລາຍການ",
        info: "ສະແດງ _START_ ເຖີງ _END_ ຂອງ _TOTAL_ ລາຍການ",
        infoEmpty: "ສະແດງ 0 ເຖິງ 0 ຂອງ 0 ລາຍການ",
        infoFiltered: "(ຈາກທັງຫມົດ _MAX_ ລາຍການ)",
        infoPostFix: "",
        loadingRecords: "ກຳລັງໂຫລດຂໍ້ມູນ...",
        zeroRecords: "ບໍ່ພົບຂໍ້ມູນທີ່ຄົ້ນຫາ",
        emptyTable: "ບໍ່ມີຂໍ້ມູນສະແດງ",
        paginate: {
          first: "ເລີ່ມຕົ້ນ",
          previous: "ກ່ອນຫນ້າ",
          next: "ຖັດໄປ",
          last: "ສຸດທ້າຍ"
        },
        aria: {
          sortAscending: ": ຈັດລຽງຂໍ້ມູນຈາກນ້ອຍໄປໃຫຍ່",
          sortDescending: ": ຈັດລຽງຂໍ້ມູນຈາກໃຫຍ່ໄປນ້ອຍ"
        }
      }
    };
    this.dtTrigger.next(this.dtOptions);
  }

  ngOnInit(): void {
    //this.item = this.data
    this.initForm(this.data)
  }


  initForm(data: any) {
    this.form = new FormGroup({
      hrNote: new FormControl(data.hrApprovalNote),
      supervisorNote: new FormControl(data.approvalNote)
    });


  }
  async LoadAll(condition: any) {
    let user = this.user.GetUserInfo()
    let params = {
      company: "C00001",
      employee: user.Employee
    }


    console.log(params, this.user.GetUserInfo())


    this.spinner.show()
    // await this.service.GetAllHistoryLeaveByEmployee(params).subscribe((resp: any) => {
    //   this.list.length = 0;
    //   this.list = resp;
    //   this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
    //     dtInstance.destroy();
    //     this.dtTrigger.next(this.dtOptions);
    //     setTimeout(() => {
    //       this.spinner.hide()
    //     }, 1500);
    //   });
    // });

  }

  statusDetail(status: any) {
    //ACTIVE CANCELED S-APPROVED S-REJECTED H-APPROVED H-REJECTEDbadge-danger
    if (status == 'ACTIVE') return "<span class='badge badge-warning'>ລໍຖ້າອະນຸມັດ</span>"
    else if (status == 'CANCELED') return "<span class='badge badge-success'>ຖືກຍົກເລີກ (ຜູ້ສ້າງ)</span>"
    else if (status == 'S-APPROVED') return "<span class='badge badge-success'>ສາຍງານອະນຸມັດ</span>"
    else if (status == 'H-REJECTED') return "<span class='badge badge-danger'>ຖືກຍົກເລີກ (HR)</span>"
    else if (status == 'H-APPROVED') return "<span class='badge badge-success'>ສາຍງານອະນຸມັດ</span>"
    else if (status == 'S-REJECTED') return "<span class='badge badge-danger'>ຖືກຍົກເລີກ (ສາຍງານ)</span>"
    else return "<span class='badge badge-success'>ອະນຸມັດແລ້ວ</span>"
  }

  saveApprove() {
    Swal.fire({
      title: 'ບັນທຶກອະນຸມັດການລາພັກ',
      text: 'ກົດປຸ່ມດຳເນີນການຕໍ່ເພື່ອບັນທຶກ',
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'ດຳເນີນການຕໍ່',
      cancelButtonText: 'ຍົກເລີກ'

    }).then((result: any) => {
      if (result.value) {

        let user = this.user.GetUserInfo()
        console.log(this.data.condition, this.data, this.form.value)


        if (this.data.condition == 'hr') {
          this.data.hrApprovedBy = user.Employee;
          this.data.hrApprovalNote = this.form.value.hrNote;
          this.data.status = this.data.approvalBy != '' && this.data.approvalBy != null ? "SUCCESS" : "H-APPROVED"


        } else {
          this.data.approvalNote = this.form.value.supervisorNote;
          this.data.approvedBy = user.Employee;
          this.data.status = this.data.hrApprovedBy != '' && this.data.hrApprovedBy != null ? "SUCCESS" : "S-APPROVED"

        }
        console.log(this.data)
        this.service.UpdateLeaveRequest(this.data).subscribe((resp: any) => {
          console.log(resp)

          this.onNoClick("OK")
        })


      } else if (result.dismiss === Swal.DismissReason.cancel) {

        return
      }
    })
  }
  saveReject() {
    Swal.fire({
      title: 'ບັນທຶກບໍ່ອະນຸມັດການລາພັກ',
      text: 'ກົດປຸ່ມດຳເນີນການຕໍ່ເພື່ອບັນທຶກ',
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'ດຳເນີນການຕໍ່',
      cancelButtonText: 'ຍົກເລີກ'

    }).then((result: any) => {
      if (result.value) {

        let user = this.user.GetUserInfo()
        console.log(this.data.condition, this.data, this.form.value)


        if (this.data.condition == 'hr') {
          this.data.hrApprovedBy = user.Employee;
          this.data.hrApprovalNote = this.form.value.hrNote;
          this.data.status = this.data.approvalBy != '' && this.data.approvalBy != null ? "REJECTED" : "H-REJECTED"
        } else {
          this.data.approvalNote = this.form.value.supervisorNote;
          this.data.approvedBy = user.Employee;
          this.data.status = this.data.hrApprovedBy != '' && this.data.hrApprovedBy != null ? "REJECTED" : "S-REJECTED"
        }
        console.log(this.data)
        this.service.UpdateLeaveRequest(this.data).subscribe((resp: any) => {
          console.log(resp)

          this.onNoClick("OK")
        })


      } else if (result.dismiss === Swal.DismissReason.cancel) {

        return
      }
    })
  }
  onNoClick(rs: any): void {
    this.dialogRef.close(rs);
  }

}
