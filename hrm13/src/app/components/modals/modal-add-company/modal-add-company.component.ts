import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { CompanyService } from 'src/app/Services/company.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-modal-add-company',
  templateUrl: './modal-add-company.component.html',
  styleUrls: ['./modal-add-company.component.css']
})
export class ModalAddCompanyComponent implements OnInit {
  form: FormGroup
  isUpdate: boolean;
  constructor(public dialogRef: MatDialogRef<ModalAddCompanyComponent>,
    private service: CompanyService, private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) {

    this.initForm(data)
    console.log('(tag)', data)
    if (data != null)
      this.isUpdate = true;
  }


  initForm(data: any) {
    this.form = new FormGroup({
      id: new FormControl(data != null ? data.id : '0'),
      name: new FormControl(data != null ? data.name : "", Validators.required),
      nameEn: new FormControl(data != null ? data.nameEn : "", Validators.required),
      code: new FormControl(data != null ? data.code : "", Validators.required),
      status: new FormControl(data != null ? data.status : "ACTIVE", Validators.required),
      homebranch: new FormControl(data != null ? data.homebranch : "", Validators.required),
      address: new FormControl(data != null ? data.address : "", Validators.required),
      controller: new FormControl("LA", Validators.required),
    });
  }

  onNoClick(rs: any): void {
    this.dialogRef.close(rs);
  }

  ngOnInit(): void {

  }

  ConfirmUpdateCompany() {
    Swal.fire({
      title: 'ບັນທຶກຂໍ້ມູນການປ່ຽນແປງ',
      text: 'ກົດປຸ່ມ ດຳເນີນການຕໍ່ ເພື່ອຢືນຢັນການບັນທຶກຂໍ້ມູນ',
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'ດຳເນີນການຕໍ່',
      cancelButtonText: 'ຍົກເລີກ'

    }).then((result: any) => {
      if (result.value) {
        console.log("Confirm")
        this.doSave()
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        console.log("cancel")
        this.onNoClick('NOK');

      }
    })
  }
  doSave() {
    this.service.saveUpdate(this.form.value).subscribe((resp: any) => {
      console.log('update', resp);
      if (resp === 'SUCCESS') {
        this.onNoClick('OK');

        // Swal.fire('ບັນທຶກຂໍ້ມູນການປ່ຽນແປງ', 'ການບັນທຶກຂໍ້ມູນສຳເລັດ', 'info')
      }
    }, error => {

      console.error('error update', error)
      Swal.fire('ຂໍອະໄພ', 'ການບັນທຶກຂໍ້ມູນບໍ່ສຳເລັດ ກະລຸນລອງໃຫມ່ອີກຄັ້ງ', 'warning')
      this.onNoClick('NOK');

    })
  }

}
