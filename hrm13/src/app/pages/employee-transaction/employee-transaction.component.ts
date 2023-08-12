import { DatePipe } from '@angular/common';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { ModalEmployeeTransactionComponent } from 'src/app/modals/modal-employee-transaction/modal-employee-transaction.component';
import { EmployeeTransaction } from 'src/app/models/employee-transaction.model';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeTransactionService } from 'src/app/Services/employee-transaction.service';
import { EmployeeService } from 'src/app/Services/employee.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-employee-transaction',
  templateUrl: './employee-transaction.component.html',
  styleUrls: ['./employee-transaction.component.css']
})
export class EmployeeTransactionComponent implements OnInit, AfterViewInit {
  list: Employee[] = []
  dtOptions: DataTables.Settings = {};

  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;
  dtTrigger: Subject<any> = new Subject();

  constructor(private page: PageDataService,
    public dialog: MatDialog,
    private datepipe: DatePipe,
    private empTransactionService: EmployeeTransactionService,
    private employeeService: EmployeeService, private spinner: NgxSpinnerService) {

    this.page.pagename = "ຂໍ້ມູນພະນັກງານ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> ການຈັການຂໍ້ມູນບຸຄະລາກອນ </li> <li class="breadcrumb-item active" > ການເຄື່ອນໄຫວ </li>'
    this.LoadAll();
  }

  LoadAll() {
    this.employeeService.GetList().pipe(this.extractData).subscribe((resp: any) => {
      this.list = resp
      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.dtTrigger.next(this.dtOptions);
        setTimeout(() => {
          this.spinner.hide()
        }, 1500);
      });
    })
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

  GetDate(today: any) {
    let actionDate = this.datepipe.transform(today, 'dd/MM/yyyy');
    return actionDate;
  }

  private extractData(res: any) {
    const body = res;
    return body || {};
  }


  ngOnInit(): void {
  }


  openDialog(row: any) {
    console.log('roe', row)
    let data = new EmployeeTransaction();
    data.id = this.employeeService.DummyEmpId();
    data.employee = row.id
    const dialogRef = this.dialog.open(ModalEmployeeTransactionComponent, {
      width: '600px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      console.log('tag', result)
      if (result != 'CANCEL') {
        console.log('tag', result)
        let ei = JSON.parse(result)
        console.log('tag', ei)
        this.empTransactionService.Create(ei).subscribe((resp: any) => {
          Swal.fire({
            title: 'ບັນທຶກສຳເລັດ',
            text: 'ການບັນທຶກຂໍ້ມູນການເຄື່ອນໄຫວສຳເລັດ',
            icon: 'info',
            showCancelButton: false,
            confirmButtonText: 'ປິດ'
          })
        })
      }
    });
  }

}
