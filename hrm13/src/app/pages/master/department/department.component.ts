import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Subject } from 'rxjs';
import { Department } from 'src/app/models/department.model';
import { DepartmentService } from 'src/app/Services/department.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { MatDialog } from '@angular/material/dialog';
import { ModalDepartmentComponent } from 'src/app/components/modals/modal-department/modal-department.component';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements AfterViewInit, OnDestroy, OnInit {
  dtOptions: any = {};
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;
  departments: Department[] = [];
  dtTrigger: Subject<any> = new Subject();
  constructor(public page: PageDataService, private departmentService: DepartmentService, public dialog: MatDialog,
    private spinner: NgxSpinnerService) { }
  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();

  }

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

  openDialog() {
    const dialogRef = this.dialog.open(ModalDepartmentComponent, {
      width: '600px',
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result === "OK") {
        this.LoadAll()
      }
    });
  }

  ngOnInit(): void {

    this.page.pagename = "ຂໍ້ມູນພະແນກການ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> ການຈັດການຂໍ້ມູນພື້ນຖານ </li> <li class="breadcrumb-item active" > ຂໍ້ມູນພະແນກການ </li>'
    this.LoadAll();
  }

  LoadAll() {

    this.departmentService.GetList().pipe(this.extractData).subscribe((resp: any) => {
      this.departments.length = 0;
      if (resp != undefined) {
        resp.forEach((element: any) => {
          if (element.id != 'D') {
            this.departments.push(element)
          }
        });
      }
      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.dtTrigger.next(this.dtOptions);
        setTimeout(() => {
          this.spinner.hide()
        }, 1500);
      });

    })
  }

  private extractData(res: any) {
    const body = res;
    return body || {};
  }

  ShowUpdate(dept: any) {
    const dialogRef = this.dialog.open(ModalDepartmentComponent, {
      width: '600px', data: dept
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result === "OK") {
        this.LoadAll()
      }
    });
  }


  Delete(item: any) {
    const dailogSwal = Swal.mixin({
      customClass: {
        title: 'laoweb',
        confirmButton: 'btn btn-success',
        cancelButton: 'btn btn-danger'
      },
      buttonsStyling: true
    });

    dailogSwal.fire({
      title: "ຕ້ອງການລຶບອອກຈາກລະບົບຫລືບໍ່",
      text: 'ກົດປຸ່ມ ດຳເນີນການຕໍ່ ເພື່ອຢືນຢັນການລຶບອອກຈາກລະບົບ',
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'ດຳເນີນການຕໍ່',
      cancelButtonText: 'ຍົກເລີກ'
    }).then((result: any) => {
      if (result.value) {
        console.log("Confirm")
        this.spinner.show();
        this.doDelete(item.id);
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        console.log("cancel");
      }
    });


  }

  doDelete(id: any) {
    this.departmentService.Delete(id).subscribe((resp: any) => {
      this.spinner.hide()
      if (resp == "SUCCESS") {
        this.LoadAll();
      }
    })
  }

}
