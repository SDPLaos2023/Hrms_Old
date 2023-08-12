import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { ModalRuleComponent } from 'src/app/modals/modal-rule/modal-rule.component';
import { RuleService } from 'src/app/Services/rule.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';

@Component({
  selector: 'app-rules',
  templateUrl: './rules.component.html',
  styleUrls: ['./rules.component.css']
})
export class RulesComponent implements OnInit, AfterViewInit {
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;

  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject();
  list: any[] = []

  constructor(private page: PageDataService, private ruleService: RuleService,
    public dialog: MatDialog, private spinner: NgxSpinnerService,) { }

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
    }

    this.dtTrigger.next(this.dtOptions)
  }


  ngOnInit(): void {


    this.page.pagename = "ກຳຫນົດສິດເຂົ້າເຖິງຕ່າງໆ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> ຂໍ້ມູນຜູ້ໃຊ້ລະບົບ </li> <li class="breadcrumb-item active" >' + this.page.pagename + ' </li>'

    this.LoadRule()
  }
  LoadRule() {
    // this.spinner.show()
    this.ruleService.Get().pipe(this.extractData).subscribe((resp: any) => {

      this.list.length = 0
      this.list = resp;

      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.dtTrigger.next(this.dtOptions);
        setTimeout(() => {
          this.spinner.hide();
        }, 1000);
      })

    })

  }

  private extractData(res: any) {
    const body = res;
    return body || {};
  }

  openDialog() {
    const dialogRef = this.dialog.open(ModalRuleComponent, {
      width: '600px'
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      console.log('tag', result)
      if (result != 'CANCEL') {
        console.log('tag', result)
        this.LoadRule()
      }
    });
  }

  ShowUpdate(item: any) {
    const dialogRef = this.dialog.open(ModalRuleComponent, {
      width: '600px', data: item
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      console.log('tag', result)
      if (result != 'CANCEL') {
        console.log('tag', result)
        this.LoadRule()
      }
    });
  }
}
