import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { ModalShiftmanagementComponent } from 'src/app/components/modals/modal-shiftmanagement/modal-shiftmanagement.component';
import { TimetableService } from 'src/app/Services/attendances/timetable.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-shiftmanagement',
  templateUrl: './shiftmanagement.component.html',
  styleUrls: ['./shiftmanagement.component.css']
})
export class ShiftmanagementComponent implements OnInit, AfterViewInit {
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;

  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject();
  list: any[] = []
  constructor(private page: PageDataService,
    public dialog: MatDialog, private spinner: NgxSpinnerService,
    private user: UserInfoService,
    private service: TimetableService) { }

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
    this.page.pagename = "ການຈັດການຕາລາງເວລາ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> Attendances </li> <li class="breadcrumb-item active" >' + this.page.pagename + ' </li>'


    this.LoadAll()
  }


  openDialog() {
    const dialogRef = this.dialog.open(ModalShiftmanagementComponent, {
      width: '400px'
    });
    dialogRef.afterClosed().subscribe(result => {
      // console.log('The dialog was closed ' + result);
      console.log('tag', result)
      if (result != 'CANCEL') {
        console.log('tag', result)
        this.LoadAll()
      }
    });
  }
  LoadAll() {

    let params = {
      company: "C00001"
    }
    this.service.GetAllShift(params).subscribe((resp: any) => {
      console.log("response", resp);
      this.list.length = 0;
      this.list = resp;

      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.dtTrigger.next(this.dtOptions);
        setTimeout(() => {
          this.spinner.hide()
        }, 1500);
      });
    })
  }

  ShowUpdate(data: any) {
    const dialogRef = this.dialog.open(ModalShiftmanagementComponent, {
      width: '400px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result != 'CANCEL') {
        console.log('The dialog was closed ' + result);
        this.LoadAll();
      }
    });
  }

  DeleteItem(item: any) {


    const dailogSwal = Swal.mixin({
      customClass: {
        title: 'laoweb',
        confirmButton: 'btn btn-success',
        cancelButton: 'btn btn-danger right'
      },
      buttonsStyling: false
    })

    dailogSwal.fire({
      title: "ຕ້ອງການຂໍ້ມູນແທ້ບໍ່",
      text: 'ກົດປຸ່ມ ດຳເນີນການຕໍ່ ເພື່ອຢືນຢັນການລຶບ',
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'ດຳເນີນການຕໍ່',
      cancelButtonText: 'ຍົກເລີກ'
    }).then((result: any) => {
      if (result.value) {
        console.log("Confirm")
        this.spinner.show()
        let params = {
          status: "DELETED",
          updatedAt: new Date(),
          updatedBy: this.user.GetUsername(),
        }
        this.service.DeleteShift(params).subscribe((resp: any) => {
          if (resp == "SUCCESS") {
            let index = this.list.indexOf(item)
            this.list.splice(index, 1)
          }
        })
      }
    })


  }

}
