import { DatePipe } from '@angular/common';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { ModalEmployeeTransactionComponent } from 'src/app/modals/modal-employee-transaction/modal-employee-transaction.component';
import { EmployeeTransaction } from 'src/app/models/employee-transaction.model';
import { EmployeeTransactionService } from 'src/app/Services/employee-transaction.service';
import { EmployeeService } from 'src/app/Services/employee.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-employee-transation-timeline',
  templateUrl: './employee-transation-timeline.component.html',
  styleUrls: ['./employee-transation-timeline.component.css']
})
export class EmployeeTransationTimelineComponent implements OnInit, AfterViewInit {
  employee: any;
  dtOptions: DataTables.Settings = {};

  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;
  dtTrigger: Subject<any> = new Subject();

  constructor(private page: PageDataService,
    private route: ActivatedRoute,
    public dialog: MatDialog,
    private datepipe: DatePipe,
    private emp: EmployeeService,
    private empTransactionService: EmployeeTransactionService, private spinner: NgxSpinnerService) {
    const routeParams = this.route.snapshot.paramMap;
    this.employee = routeParams.get('empid')

    this.page.pagename = "ຂໍ້ມູນການເຄື່ອນໄຫວທັງຫມົດ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> ການຈັການຂໍ້ມູນບຸຄະລາກອນ </li> <li class="breadcrumb-item active" > ການເຄື່ອນໄຫວທັງຫມົດ </li>'
    this.LoadTransaction(this.employee)

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

  transactions: EmployeeTransaction[] = []
  LoadTransaction(employee: string) {
    this.empTransactionService.GetList(employee).pipe(this.extractData)
      .subscribe((resp: any) => {
        this.transactions = resp
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

  ngOnInit(): void {
  }

  openDialog() {
    let data = new EmployeeTransaction();
    data.id = this.emp.DummyEmpId();
    data.employee = this.employee
    const dialogRef = this.dialog.open(ModalEmployeeTransactionComponent, {
      width: '600px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      console.log('tag', result)
      if (result != 'CANCEL') {
        console.log('tag', result)
        let ei = JSON.parse(result)
        this.empTransactionService.Create(ei).subscribe((resp: any) => {
          this.LoadTransaction(this.employee)
        })
      }
    });
  }


  ShowUpdate(data: any) {
    const dialogRef = this.dialog.open(ModalEmployeeTransactionComponent, {
      width: '600px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result != 'CANCEL') {
        console.log('The dialog was closed ' + result);
        let ei = JSON.parse(result)
        this.empTransactionService.Update(ei).subscribe((resp: any) => {
          this.LoadTransaction(this.employee)
        })
      }
    });
  }

  removeTransaction(row: any) {
    console.log('tag', row)
    Swal.fire({
      title: 'ຢືນຢັນການລຶບ',
      text: 'ຕ້ອງການລຶບຂໍ້ມູນນີ້ອອກແທ້ບໍ່',
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'ດຳເນີນການຕໍ່',
      cancelButtonText: 'ຍົກເລີກ'

    }).then((result: any) => {
      if (result.value) {
        this.empTransactionService.Delete(row.id).subscribe((resp: any) => {
          this.LoadTransaction(this.employee)
        })
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        this.spinner.hide();
      }
    })
  }

}
