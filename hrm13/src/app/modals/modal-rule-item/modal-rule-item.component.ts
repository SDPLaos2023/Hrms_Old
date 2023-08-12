import { AfterViewInit, Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DataTableDirective } from 'angular-datatables';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { PageMaster } from 'src/app/models/page-master.model';
import { RuleItem } from 'src/app/models/rule-item.model';
import { PageMasterService } from 'src/app/Services/page-master.service';
import { RuleItemService } from 'src/app/Services/rule-item.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-modal-rule-item',
  templateUrl: './modal-rule-item.component.html',
  styleUrls: ['./modal-rule-item.component.css']
})
export class ModalRuleItemComponent implements OnInit, AfterViewInit {
  form: FormGroup;

  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;

  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject();
  list: any[] = []
  rule_id: any;

  constructor(public dialogRef: MatDialogRef<ModalRuleItemComponent>,
    private item: RuleItemService, private master: PageMasterService,
    private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) {
    this.rule_id = data;
    console.log('rule_id', data)
  }

  ngAfterViewInit(): void {
    this.dtTrigger.next({});
  }

  ngOnInit(): void {
    this.item.GetList(this.rule_id).subscribe((respItem: any) => {
      // console.log('listItem', respItem)
      this.master.GetAll().subscribe((resp: any) => {
        // console.log('all', resp)
        let listPages = resp
        let pages: PageMaster[] = []
        listPages.forEach((e: any) => {
          let page = new PageMaster();
          page.id = e.id;
          page.name = e.name;
          page.uri = e.uri;
          page.description = e.description;
          page.pageGroup = e.pageGroup;
          page.isCanSelect = true;
          pages.push(page)
        })

        pages.forEach(p => {
          respItem.forEach((i: any) => {
            if (p.id == i.pageId) { p.isCanSelect = false }
          })
        })
        console.log('(pages)', pages)
        this.list = pages

        this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
          dtInstance.destroy();
          this.dtTrigger.next({});
          setTimeout(() => {
            this.spinner.hide();
          }, 1000);
        })
      })
    })


  }

  onNoClick(rs: any): void {
    this.dialogRef.close(rs);
  }

  addRuleItem(item: any) {
    this.item.AddRuleItem(this.rule_id, item.id).subscribe((resp: any) => {
      console.log('rule item', resp)
      this.list.forEach(e => {
        if (e.id == item.id) {
          e.isCanSelect = false;
        }
      })
    })
  }

  AddBySelectAll() {


    Swal.fire({
      title: 'ຢືນຢັນການເລືອກເພິ່ມສິດທັງຫມົດນີ້',
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
        this.item.AddBySelectAll(this.rule_id).subscribe((resp: any) => {
          if (resp != null) {
            setTimeout(() => {
              this.spinner.hide()
              this.onNoClick("OK")

            }, 1000);
          }
        })
      }
    })


  }

}
