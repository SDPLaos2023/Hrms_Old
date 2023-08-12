import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { EmployeeService } from 'src/app/Services/employee.service';

import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { FpUserService } from 'src/app/Services/fp-user.service';
export interface emplist {
  no: number;
  id: string;
  employee_name: string;
  division_name: string;
  department_name: string;
  select: string;
}

const ELEMENT_DATA: emplist[] = []

@Component({
  selector: 'app-modal-select-employee',
  templateUrl: './modal-select-employee.component.html',
  styleUrls: ['./modal-select-employee.component.css']
})
export class ModalSelectEmployeeComponent implements OnInit, AfterViewInit {
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;

  displayedColumns: string[] = ['no', 'id', 'employee_name', 'division_name', 'department_name', 'select'];
  dataSource = new MatTableDataSource<emplist>(ELEMENT_DATA);

  @ViewChild(MatPaginator) paginator: MatPaginator;


  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject();
  list: emplist[] = []

  constructor(public dialog: MatDialog, private employeeService: EmployeeService,
    public dialogRef: MatDialogRef<ModalSelectEmployeeComponent>) { }
  ngAfterViewInit(): void {
    // this.dataSource.paginator = this.paginator;
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
    this.dtTrigger.next(this.dtOptions)
  }

  ngOnInit(): void {
    this.LoadEmployee()
  }

  LoadEmployee() {
    this.employeeService.GetListNoneUser().pipe(this.extractData).subscribe((resp: any) => {
      let emp = resp;
      console.log("list emp none user", emp)
      this.list = resp
      // let i = 1;
      // ELEMENT_DATA.length = 0

      // emp.forEach((element: any) => {
      //   let e = {
      //     no: i,
      //     id: element.id,
      //     employee_name: element.employee_name,
      //     department_name: element.department_name,
      //     division_name: element.division_name,
      //     select: element.id
      //   };
      //   i++;
      //   ELEMENT_DATA.push(e)
      // })
      // this.dataSource.data = ELEMENT_DATA;

      // console.log("ELEMENT_DATA", ELEMENT_DATA)
      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.dtTrigger.next(this.dtOptions);
      });
    })
  }

  private extractData(res: any) {
    const body = res;
    return body || {};
  }

  SelectEmployee(item: any) {
    console.log(item)
    this.onNoClick(item.id)
  }

  onNoClick(rs: any): void {
    this.dialogRef.close(rs);
  }
}
