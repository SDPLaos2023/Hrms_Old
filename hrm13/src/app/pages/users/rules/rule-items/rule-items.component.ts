import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { ModalRuleItemComponent } from 'src/app/modals/modal-rule-item/modal-rule-item.component';
import { RuleItemService } from 'src/app/Services/rule-item.service';
import { RuleService } from 'src/app/Services/rule.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-rule-items',
  templateUrl: './rule-items.component.html',
  styleUrls: ['./rule-items.component.css']
})
export class RuleItemsComponent implements OnInit, AfterViewInit {
  rule_id: any;

  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;

  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject();
  list: any[] = []
  rule_name: any = "";
  constructor(private page: PageDataService,
    private route: ActivatedRoute,
    public dialog: MatDialog, private spinner: NgxSpinnerService, private item: RuleItemService, private rule: RuleService) {

    const routeParams = this.route.snapshot.paramMap;
    this.rule_id = routeParams.get('rule_id')
    this.rule.GetOne(this.rule_id).subscribe((resp: any) => {
      console.log('name', resp)
      this.rule_name = resp.name
      this.page.pagename = "ສິດທິທັງຫມົດ [ " + resp.name + " ]"
      this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> ຂໍ້ມູນຜູ້ໃຊ້ລະບົບ </li> <li class="breadcrumb-item active" > ' + this.page.pagename + ' </li>'

    })
    console.log('rule_id', this.rule_id)
  }

  ngAfterViewInit(): void {

    this.dtTrigger.next({});
  }

  ngOnInit(): void {

    this.spinner.show();


    this.LoadRuleItems();
  }

  LoadRuleItems() {
    this.item.GetList(this.rule_id).pipe(this.extractData).subscribe((resp: any) => {
      this.list = [];
      this.list = resp;
      console.log('(list)', this.list)
      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.dtTrigger.next({});
        setTimeout(() => {
          this.spinner.hide();
        }, 1000);
      })

    });
  }
  private extractData(res: any) {
    const body = res;
    return body || {};
  }

  openDialog() {
    const dialogRef = this.dialog.open(ModalRuleItemComponent, {
      width: '900px', data: this.rule_id
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      console.log('tag', result)
      if (result != 'CANCEL') {
        console.log('tag', result)
        this.LoadRuleItems()
      }
    });
  }

  DeleteItem(item: any) {


    Swal.fire({
      title: 'ຢືນຢັນການລຶບສິດນີ້ອອກ',
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
        this.item.Delete(item.id).subscribe((resp: any) => {
          if (resp != null) {
            setTimeout(() => {
              this.spinner.hide()
              this.LoadRuleItems()
            }, 1000);
          }
        })
      }
    })




  }
}
