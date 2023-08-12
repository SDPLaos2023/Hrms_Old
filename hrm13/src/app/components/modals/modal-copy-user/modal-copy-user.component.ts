import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { FpFingerprintMappingService } from 'src/app/Services/fp-fingerprint-mapping.service';
import { FpService } from 'src/app/Services/fp.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-modal-copy-user',
  templateUrl: './modal-copy-user.component.html',
  styleUrls: ['./modal-copy-user.component.css']
})
export class ModalCopyUserComponent implements OnInit {
  list: any[] = [];
  fpId: any;

  constructor(public dialogRef: MatDialogRef<ModalCopyUserComponent>,
    private service: FpFingerprintMappingService, private spinner: NgxSpinnerService,
    @Inject(MAT_DIALOG_DATA) public data: any, private page: PageDataService,
    private fpService: FpService) {
    this.fpId = "FM00002"// this.page.param1

    if (data != null) {
      this.fpId = data.fpId

    }

    console.log('fpid', this.fpId)
  }

  ngOnInit(): void {
    this.fpService.GetList().subscribe((resp: any) => {
      console.log('tag', resp)
      if (resp != null) {
        resp.forEach((element: any) => {
          if (element.id !== 'FM') {
            if (element.id !== this.fpId)
              this.list.push(element)
          }
        });
      }
    })
    if (this.data != null) {
      console.log('tag', this.data)

    }
  }

  doCopy(newFpId: any) {
    if (newFpId != this.fpId) {
      Swal.fire({
        title: 'ຢຶນຢັນການບັນທຶກ?',
        text: "ກົດປຸ່ມດຳເນີນການຕໍ່ເພື່ອເພິ່ມຊື່ໄປເຄື່ອງປ້ຳໂມງໃຫມ່",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'ດຳເນີນການຕໍ່'
      }).then((result) => {
        if (result.isConfirmed) {
          console.log('.', newFpId)
          this.fpService.transferUser(this.data, newFpId)
            .subscribe((resp: any) => {
              console.log('transfer', resp)
              Swal.fire(
                'Success!',
                'ບັນທຶກສຳເລັດ',
                'success'
              );
              this.dialogRef.close(resp);
            })
        }
      })

    }
  }

}
