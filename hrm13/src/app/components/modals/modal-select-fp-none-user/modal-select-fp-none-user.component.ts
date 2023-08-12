import { AfterViewInit, Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { FpUserService } from 'src/app/Services/fp-user.service';

@Component({
  selector: 'app-modal-select-fp-none-user',
  templateUrl: './modal-select-fp-none-user.component.html',
  styleUrls: ['./modal-select-fp-none-user.component.css']
})
export class ModalSelectFpNoneUserComponent implements OnInit, AfterViewInit {
  list: any = [];
  dtOptions: DataTables.Settings = {};
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;
  dtTrigger: Subject<any> = new Subject();
  constructor(public dialog: MatDialog,
    private deviceService: FpUserService, @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<ModalSelectFpNoneUserComponent>) { }
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
    this.dtTrigger.next(this.dtOptions)
  }

  ngOnInit(): void {
    this.LoadEmployee();
  }

  LoadEmployee() {
    this.deviceService.GetListNoneUser(this.data.fpId).pipe(this.extractData).subscribe((resp: any) => {
      let emp = resp;
      this.list = resp;
      console.log("list emp none user", emp)

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
