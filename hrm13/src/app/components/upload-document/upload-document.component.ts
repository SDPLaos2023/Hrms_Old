import { HttpClient, HttpEventType, HttpRequest } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { EmployeeService } from 'src/app/Services/employee.service';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-upload-document',
  templateUrl: './upload-document.component.html',
  styleUrls: ['./upload-document.component.css']
})
export class UploadDocumentComponent implements OnInit {

  public list: any[] = []

  public progress: number;
  public message: string;
  @Input("empID") _empid: string = ""
  @Output() public onUploadFinished = new EventEmitter();
  baseUrl = environment.baseUrlApi;
  constructor(private http: HttpClient, public emp: EmployeeService) { }
  ngOnInit() {
    this.loaddocument();
  }
  loaddocument() {
    this.http.get(this.baseUrl + "api/FileUpload/documents/" + this._empid).subscribe((resp: any) => {
      this.list = resp;

      console.log('(tag)', this.list)
    })
  }

  public uploadFile = (files: any) => {
    if (files.length === 0) {
      return;
    }

    // let fileToUpload = <File>files[0];
    const formData = new FormData();
    for (const file of files) {
      formData.append(file.name, file);
    }
    formData.append('empID', this._empid);

    const uploadReq = new HttpRequest('POST', this.baseUrl + 'api/FileUpload/documents/' + this._empid, formData, {
      reportProgress: true
    });

    this.http.request(uploadReq).subscribe((event: any) => {
      console.log('tag', event)
      console.log('tag', event.body)
      this.list = event.body

      if (event.type === HttpEventType.UploadProgress) {
        this.progress = Math.round(100 * event.loaded / event.total);
        this.message = "Image Ok";
      };
    });


  }

  deleteFile(fileId: any) {
    if (fileId == null)
      return

    Swal.fire({
      title: 'ຕ້ອງການລຶບຟາຍທີ່ເລືອກນີ້ບໍ່?',
      text: "ຟາຍຈະຖືກລຶບຖາວອນ",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'ດຳເນີນການຕໍ່!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.http.delete(this.baseUrl + 'api/FileUpload/' + fileId, {
          reportProgress: true
        }).subscribe((resp: any) => {


          this.list = resp
          console.log('tag', this.list)
          Swal.fire(
            'Deleted!',
            'ການລຶບສຳເລັດ',
            'success'
          )
        })
      }
    })




  }

  DownloadFile(filename: any) {
    this.http.get(this.baseUrl + filename).subscribe((resp: any) => {
      console.log('(tag)', resp)
    })
  }
}
